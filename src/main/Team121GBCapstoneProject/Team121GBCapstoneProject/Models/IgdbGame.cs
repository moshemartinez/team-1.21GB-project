using Newtonsoft.Json;

namespace Team121GBCapstoneProject.Models
{
    public class IgdbGame
    {
        public int Id { get; set; }
        public string GameTitle { get; set; }
        public string GameCoverArt { get; set; } 
        public string GameWebsite { get; set; }
        public string GameDescription { get; set; }
        public int? FirstReleaseDate { get; set; }
        public double AverageRating { get; set; }
        //old constructor
        public IgdbGame(int id, string gameTitle, string gameCoverArt, string gameWebsite)
        {
            Id = id;
            GameTitle = gameTitle;
            GameCoverArt = gameCoverArt;
            GameWebsite = gameWebsite;
        }
        // * new updated constructor for improved caching.
        public IgdbGame(int id,
                        string gameTitle,
                        string gameCoverArt,
                        string gameWebsite,
                        string gameDescription,
                        int? firstReleaseDate,
                        double averageRating)
        {
            Id = id;
            GameTitle = gameTitle;
            GameCoverArt = gameCoverArt;
            GameWebsite = gameWebsite;
            GameDescription = gameDescription;
            FirstReleaseDate = firstReleaseDate;
            AverageRating = averageRating;
        }
    }
}
