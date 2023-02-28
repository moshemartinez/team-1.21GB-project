using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.Services
{
    public interface IGameService
    {
        void SetCredentials(string clientId, string clientSecret, string token);
        IEnumerable<IgdbGame> SearchGames(string query);
    }
}
