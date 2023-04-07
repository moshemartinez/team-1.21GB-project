using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Abstract
{
    public interface IGameRecommender : IRepository<PersonGame>
    {
        public List<Game> recommendGames(List<PersonGame> games, int numberOfRecommendations, int genreCount);
    }
}
