using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Concrete
{
    public class GameRecommender : IGameRecommender
    {
        private int[] genreCount = new int[23] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

        private DbSet<Game> _game;
        public GameRecommender(GPDbContext context)
        {
            _game = context.Games;
        }
        public PersonGame AddOrUpdate(PersonGame entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PersonGame entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public PersonGame FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PersonGame> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<PersonGame> GetAll(params Expression<Func<PersonGame, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        //counting genres
        private void genreCounter(Game gameToCheckGenres)
        {
            foreach (var genre in gameToCheckGenres.GameGenres) 
            {
                int genreID = (int)genre.GenreId;
                genreCount[genreID - 1]++;
            }
        }

        private int[] findTopGenres()
        {
            int[] topGenresToReturn = new int[3];

            for (int i = 0; i < 3; i++)
            {
                int largest = genreCount.Max();
                for (int j = 0; j < genreCount.Length; j++)
                {
                    if (genreCount[j] == largest)
                    {
                        int test = j;
                        topGenresToReturn[i] = test + 1;
                        genreCount[j] = -1;
                    }
                }
            }

            return topGenresToReturn;
        }

        //function to currate list of games
        private List<Game> currateGames(int numberOfGames)
        {
            List<Game> curratedGames = new List<Game>();
            int topGenreGameCount = numberOfGames / 2;
            int SecondGenreGameCount = numberOfGames / 3;
            int thirdGenreGameCount = numberOfGames - (topGenreGameCount + SecondGenreGameCount);

            //find top x games
            int[] TopGenres = findTopGenres();
            int first = TopGenres[0];
            int second = TopGenres[1];
            int third = TopGenres[2];

            //Top 3 Lists
            curratedGames = _game.Where(g => g.GameGenres.Any(genre => genre.GenreId == first)).Take(topGenreGameCount).ToList();
            List<Game> secondPlaceGames = _game.Where(g => g.GameGenres.Any(genre => genre.GenreId == second)).Take(SecondGenreGameCount).ToList();
            List<Game> thirdPlaceGames = _game.Where(g => g.GameGenres.Any(genre => genre.GenreId == third)).Take(thirdGenreGameCount).ToList();

            curratedGames.AddRange(secondPlaceGames);
            curratedGames.AddRange(thirdPlaceGames);

            return curratedGames;
        }

        //Setting up Array
        private void SetUpGenreCountArray(int numberOfGenres)
        {
            genreCount = new int[numberOfGenres];

            for (int i = 0; i < numberOfGenres; i++)
            {
                genreCount[i] = 0;
            }
        }

        public List<Game> recommendGames(List<PersonGame> games, int numberOfRecommendations, int genreCount)
        {
            List<Game> gamesToReturn= new List<Game>();
            //SetUpGenreCountArray(genreCount);

            if (games.Count > 0)
            {
                //checking for each game in the library
                foreach (var game in games)
                {
                    //Grab the game itself for checking
                    Game gameToCheck = game.Game;

                    //iterate through games genres and count them up
                    genreCounter(gameToCheck);
                }

                //generate currated list
                gamesToReturn = currateGames(numberOfRecommendations);
            }


            return gamesToReturn;
        }
    }
}

//Note: When you see this tomarrow, you will need to make it display on the page as well as adding it to the vm