using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;
using Team121GBCapstoneProject.Services.Concrete;


namespace Team121GBCapstoneProject.DAL.Concrete
{
    public class SpeedSearch : ISpeedSearch
    {
        private DbSet<Game> _game;
        private IIgdbService _idgbService;

        public SpeedSearch(GPDbContext context, IIgdbService igdbService)
        {
            _game = context.Games;
            _idgbService = igdbService;
        }
        public async Task<IgdbGame> GetFirstSearchResultAsync(string title)
        {
            try
            {
                var igdbGame = await _idgbService.SearchGameWithCachingAsync(1, "", "", 0, title);
                IgdbGame gameToReturn = igdbGame.FirstOrDefault();
                return gameToReturn;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
                //return something helpful
            }
            return null;
        } 

        public List<string> TitleParse(string input)
        {
            List<string> parsedTitles = input.Split('*').ToList();
            parsedTitles.RemoveAt(0);

            List<string> listToReturn = new List<string>();

            foreach (var s in parsedTitles)
            {
                string stringToAdd = s.Trim();
                listToReturn.Add(stringToAdd);
            }
            return listToReturn;
        }

        public async Task<IEnumerable<IgdbGame>> SpeedSearchingAsync(string input)
        {
            List<string> Titles = TitleParse(input);
            List<IgdbGame> speedSearchResults = new List<IgdbGame>();

            foreach(var title in Titles)
            {
                IgdbGame gameToAdd = await GetFirstSearchResultAsync(title);
                if (gameToAdd != null)
                {
                    speedSearchResults.Add(gameToAdd);
                }
            }
            return speedSearchResults;
        }
    }
}
