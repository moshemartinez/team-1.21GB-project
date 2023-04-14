using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Models.DTO;

namespace Team121GBCapstoneProject.Services.Abstract;

public interface IIgdbService
{
    void SetCredentials(string clientId, string token);
    // ! This method might not be needed
    // ! Task<string> ConstructSearchBody(string platform, string genre, int esrbRatingId, string query);
    Task<IEnumerable<IgdbGame>> SearchGames(string query);
    Task<IEnumerable<IgdbGame>> SearchGameWithCachingAsync(int numberOfGames, string platform, string genre, int esrbRating,    string query = "");
    public bool checkGamesFromDatabase(List<Game> gamesToCheck, List<IgdbGame> gamesToReturn, int numberOfGamesToCheck);
    public bool CheckForGame(List<Game> gamesToCheck, string title);
    public void FinishGamesListForView(List<Game> GamesFromOurDB, List<IgdbGame> gameFromAPI, List<IgdbGame> gamesToReturn, int numberOfGamesToCheck);
    /// <summary>
    /// Adds new GameGenres to db after having added a new game to db
    /// </summary>
    /// <param name="gameFromApi">IGDB Game object used to add new Game to db</param>
    /// <param name="addedGame">Game object that was just added to the db</param>
    public void AddGameGenreForNewGames(IgdbGame gamesFromApi, Game addedGame);
}
