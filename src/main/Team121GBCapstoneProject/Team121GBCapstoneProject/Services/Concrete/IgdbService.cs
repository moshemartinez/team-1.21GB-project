using Newtonsoft.Json;
using System.Net;
using Microsoft.Net.Http.Headers;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;
using System.Net.Http.Headers;
using Team121GBCapstoneProject.Models.DTO;
using Microsoft.DotNet.MSIdentity.Shared;
using Team121GBCapstoneProject.DAL.Abstract;
using System.Diagnostics;

namespace Team121GBCapstoneProject.Services.Concrete;

public class IgdbService : IIgdbService
{
    // * Inject the IHttpClientFactory through constructor injection
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IGameRepository _gameRepository;
    private readonly IRepository<Game> _genericGameRepo;
    private readonly IRepository<Esrbrating> _esrbRatingRepository;

    private string _bearerToken;
    private string _clientId;

    public IgdbService(IHttpClientFactory httpClientFactory, IGameRepository gameRepository, IRepository<Game> genericGameRepo, IRepository<Esrbrating> esrbRatingRepository)
    {
        _httpClientFactory = httpClientFactory;
        _gameRepository = gameRepository;
        _genericGameRepo = genericGameRepo;
        _esrbRatingRepository = esrbRatingRepository;
    }

    public async Task<string> GetJsonStringFromEndpoint(string token, string uri, string clientId, string rawBody)
    {

        HttpClient httpClient = _httpClientFactory.CreateClient();

        // Add Headers
        httpClient.BaseAddress = new Uri(uri);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        httpClient.DefaultRequestHeaders.Add("Client-ID", clientId);

        HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(rawBody));

        // This is only a minimum version; make sure to cover all your bases here
        if (response.IsSuccessStatusCode)
        {
            // This is blocking; use ReadAsStreamAsync instead
            string responseText = await response.Content.ReadAsStringAsync();
            return responseText;
        }
        else
        {
            throw new HttpRequestException();
        }
    }
    public void SetCredentials(string clientId, string token)
    {
        _clientId = clientId;
        _bearerToken = token;
    }
    public async Task<string> ConstructSearchBody(string platform, 
                                                  string genre,
                                                  int esrbRatingId,
                                                  string query)
    {   
        if (String.IsNullOrEmpty(query)) return "";
        
        string search = $"search \"{query}\"; ";
        string fields = "fields name, cover.url, url, summary, first_release_date, rating, age_ratings.rating, age_ratings.category";
        string filtering = " where parent_game = null ";
        
        // * Add parameters from search bar to the strings respectively.
        if (!String.IsNullOrEmpty(platform)) fields += ", platforms";
        if (!String.IsNullOrEmpty(genre)) fields += ", genres";
        if (esrbRatingId > 0) filtering += $"& age_ratings.rating = {esrbRatingId} & age_ratings.category = 1 & genres.name = \"{genre}\""; 
        
        // * Finish up string formatting.
        fields += ';';
        filtering += ';';

        // * construct the search body with all of the pieces.
        string body = search + fields + filtering;
        
        return body;
    }
    public async Task<IEnumerable<IgdbGame>> SearchGames(string platform,
                                                         string genre,
                                                         int esrbRating,
                                                         string query = "")
    {
        // * game Endpoint Search
        string gameSearchBody = await ConstructSearchBody(platform,
                                                          genre,
                                                          esrbRating,
                                                          query);
        if (String.IsNullOrEmpty(gameSearchBody)) return Enumerable.Empty<IgdbGame>(); //! If the query was empty don't hit the API cause there is no point in send an empty query.
        string gameSearchUri = "https://api.igdb.com/v4/games/";
        string gameResponse = await GetJsonStringFromEndpoint(_bearerToken, gameSearchUri, _clientId, gameSearchBody);
        IEnumerable<GameJsonDTO> gamesJsonDTO;
        try
        {
            gamesJsonDTO = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GameJsonDTO>>(gameResponse);
        }
        catch (System.Text.Json.JsonException)
        {
            gamesJsonDTO = null;
        }
        if (gamesJsonDTO != null && gamesJsonDTO.Any())
        {  
            return gamesJsonDTO.Select(g => new IgdbGame(g.id,
                                                          g.name,
                                                          g.cover?.url?.ToString(),
                                                          g.url,
                                                          g.summary,
                                                          GameJsonDTO.ConvertFirstReleaseDateFromUnixTimestampToYear(g.first_release_date),
                                                          g.rating,
                                                          GameJsonDTO.ExtractEsrbRatingFromAgeRatingsArray(g.age_ratings)));
        }
        return Enumerable.Empty<IgdbGame>();
    }

    public bool checkGamesFromDatabase(List<Game> gamesToCheck, List<IgdbGame> gamesToReturn, int numberOfGamesToCheck)
    {
        try
        {
            if (gamesToCheck.Count() > 0)
            {
                if (gamesToCheck.Count() >= numberOfGamesToCheck)
                {
                    int i = 0;
                    foreach (var game in gamesToCheck)
                    {
                        if (i == numberOfGamesToCheck)
                        {
                            break;
                        }

                        int? yearPublished =
                            GameJsonDTO.ConvertFirstReleaseDateFromUnixTimestampToYear(game.YearPublished);
// Look into sending null or 0 instead of 1
                        IgdbGame gameToAdd = new IgdbGame(1,
                                                          game.Title,
                                                          game.CoverPicture.ToString(),
                                                          game.Igdburl,
                                                          game.Description,
                                                          game.YearPublished,
                                                          (double)game.AverageRating,
                                                          game.EsrbratingId);
                        gamesToReturn.Add(gameToAdd);
                        i++;
                    }
                    return true;
                }
                else
                {
                    foreach (var game in gamesToCheck)
                    {
                        IgdbGame gameToAdd = new IgdbGame(game.IgdbgameId,
                                      game.Title,
                                      game.CoverPicture.ToString(),
                                      game.Igdburl,
                                      game.Description,
                                      game.YearPublished,
                                      (double)game.AverageRating,
                                      game.EsrbratingId);
                        gamesToReturn.Add(gameToAdd);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
        return false;
    }

    public void FinishGamesListForView(List<Game> GamesFromOurDB, List<IgdbGame> gameFromAPI, List<IgdbGame> gamesToReturn, int numberOfGamesToCheck)
    {
        foreach (var game in gameFromAPI)
        {
            try
            {
                if (gamesToReturn.Count() >= numberOfGamesToCheck)
                {
                    break;
                }
                if (CheckForGame(GamesFromOurDB, game.GameTitle) == true)
                {
                    continue;
                }
                Game gameToAdd = new Game();
                gameToAdd.Title = game.GameTitle.ToString();

                if (game.GameCoverArt == null)
                {
                    gameToAdd.CoverPicture = "https://images.igdb.com/igdb/image/upload/t_thumb/nocover.png";
                }
                else
                {
                    gameToAdd.CoverPicture = game.GameCoverArt.ToString();
                }

                gameToAdd.Igdburl = game.GameWebsite.ToString();
                gameToAdd.Description = game.GameDescription.ToString();
                gameToAdd.YearPublished = game.FirstReleaseDate;
                gameToAdd.AverageRating = game.AverageRating;
                gameToAdd.IgdbgameId = game.Id;

                // * This is here to make sure that esrbrating will always be null or an int.
                // * sometimes game from Igdb do not have an esrbrating so this handles that case
                int? esrbRatingId = null;
                if (game.ESRBRatingValue != null)
                {
                    try
                    {
                        esrbRatingId = _esrbRatingRepository.GetAll()
                                                            .FirstOrDefault(esrbRating => esrbRating.IgdbratingValue == game.ESRBRatingValue)!
                                                            .Id;
                    }
                    catch (NullReferenceException e)
                    {
                        Debug.WriteLine(e);
                    }
                }
                gameToAdd.EsrbratingId = esrbRatingId;

                try
                {
                    _genericGameRepo.AddOrUpdate(gameToAdd);
                }
                catch (NullReferenceException e)
                {
                    Debug.WriteLine(e);
                }
                gamesToReturn.Add(game);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }

    public async Task<IEnumerable<IgdbGame>> SearchGameWithCachingAsync(int numberOfGames, 
                                                                        string platform = "",
                                                                        string genre = "",
                                                                        int esrbRating = 0,
                                                                        string query = "")
    {
        List<IgdbGame> gamesToReturn = new List<IgdbGame>();
        List<Game> gamesFromPersonalDb = _gameRepository.GetGamesByTitle(query);

        bool result = checkGamesFromDatabase(gamesFromPersonalDb, gamesToReturn, numberOfGames);

        if (result == true)
        {
            return gamesToReturn;
        }

        var gamesFromSearch = await SearchGames(platform,
                                                genre,
                                                esrbRating,
                                                query);

        FinishGamesListForView(gamesFromPersonalDb, gamesFromSearch.ToList<IgdbGame>(), gamesToReturn, numberOfGames);


        return gamesToReturn;
    }
    public bool CheckForGame(List<Game> gamesToCheck, string title)
    {
        foreach (var game in gamesToCheck)
        {
            if (game.Title == title)
            {
                return true;
            }
        }
        return false;
    }
}