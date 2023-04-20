using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Abstract
{
    public interface ISpeedSearch
    {
        public List<Game> SpeedSearching(string input);
        public Game GetFirstSearchResult(string title);
        public List<string> TitleParse(string input);
    }
}
