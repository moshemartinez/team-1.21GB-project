namespace Team121GBCapstoneProject.Models.DTO
{
    public class GameJsonDTO
    {
        public int id { get; set; }
        public Cover cover { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string summary { get; set; }
        public int? first_release_date { get; set; }
        public double rating { get; set; }
        //public Rating age_ratings { get; set; }

        public static int? ConvertFirstReleaseDateFromUnixTimestampToYear(int? firstReleaseDate)
        {
            if (firstReleaseDate == null) return null;
            DateTime dateTime = new DateTime(1970, 
                                            1,
                                            1,
                                            0,
                                            0,
                                            0,
                                            DateTimeKind.Utc)
                                            .AddSeconds((double)firstReleaseDate);
            return dateTime.Year;
        }
    }

    public class Cover
    {
        public int id { get; set; }
        public string url { get; set; }
    }

    public class Rating
    {

        public string name { get; set; }
        public int value { get; set; }

    }

    public class Category
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class AgeRatingJsonDTO
    {
        public string rating_cover_url { get; set; }
        public string synopsis { get; set; }
        public string rating { get; set; }
        //public Rating rating { get; set; }
        //public Category category { get; set; }


    }
}