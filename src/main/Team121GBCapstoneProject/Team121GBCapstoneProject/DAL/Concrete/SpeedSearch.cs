using Microsoft.EntityFrameworkCore;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Concrete
{
    public class SpeedSearch : ISpeedSearch
    {
        private DbSet<Game> _game;
        public SpeedSearch(GPDbContext context)
        {
            _game = context.Games;
        }
        public Game GetFirstSearchResult(string title)
        {
            throw new NotImplementedException();
        }

        public List<string> TitleParse(string input)
        {
            throw new NotImplementedException();
        }

        public List<Game> SpeedSearching(string input)
        {
            throw new NotImplementedException();
        }
    }
}
