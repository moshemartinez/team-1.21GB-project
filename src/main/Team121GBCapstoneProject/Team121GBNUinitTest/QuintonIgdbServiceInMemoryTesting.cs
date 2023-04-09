using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;
using Team121GBCapstoneProject.Services.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Team121GBNUnitTest
{
    public class QuintonIgdbServiceInMemoryTesting
    {
        public static readonly string _seedFile = @"..\..\..\Data\seed.sql";
        private InMemoryDbHelper<GPDbContext> _dbHelper = new InMemoryDbHelper<GPDbContext>(_seedFile, DbPersistence.OneDbPerTest);

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGameRepository _gameRepository;
        private readonly IRepository<Game> _genericGameRepo;
        private readonly IRepository<Esrbrating> _esrbratingRepo;

        [Test]
        public void GPDBContextFinishGamesaListForViewSuccessShouldReturnTenGames()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            GameRepository gameRepository = new GameRepository(context);
            Repository<Game> genericGameRepo = new Repository<Game>(context);
            List<IgdbGame> gamesToReturn = new List<IgdbGame>();
            List<Game> GamesFromPersonalDB = gameRepository.GetGamesByTitle("Gears Of War");
            IIgdbService igdbService = new IgdbService(_httpClientFactory, _gameRepository, _genericGameRepo, _esrbratingRepo);
            foreach (var game in GamesFromPersonalDB)
            {
                IgdbGame gameToAdd = new IgdbGame(1, game.Title, game.CoverPicture.ToString(), game.Igdburl);
                gamesToReturn.Add(gameToAdd);   
            }

            List<IgdbGame> gamesFromAPIMocked = new List<IgdbGame>
            {
                new IgdbGame(1, "Gears Of War 2", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(2, "Gears Of War 3", "https://www.igdb.com/games/gears-of-war-3", "https://images.igdb.com/igdb/image/upload/t_thumb/co2a21.png"),
                new IgdbGame(3, "Gears Of War 4", "https://www.igdb.com/games/gears-of-war-4", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(4, "Gears Of War 5", "https://www.igdb.com/games/gears-of-war-5", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(5, "Gears Of War Judgment", "https://www.igdb.com/games/gears-of-war-judgment", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y2a.png"),
                new IgdbGame(6, "Gears Of War ", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(7, "Gears Of War 6", "https://www.igdb.com/games/gears-of-war-6", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(8, "Gears Of War 7", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(9, "Gears Of War 8", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(10, "Gears Of War 9", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
            };

            int numberOfGames = 10;

            //Act
            igdbService.FinishGamesListForView(GamesFromPersonalDB, gamesFromAPIMocked, gamesToReturn, numberOfGames);


            //Assert
            Assert.AreEqual(numberOfGames, gamesToReturn.Count());
        }

        [Test]
        public void GPDBContextFinishGamesaListWithNoGamesInTheDBShouldStillReturnTenGames()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            GameRepository gameRepository = new GameRepository(context);
            Repository<Game> genericGameRepo = new Repository<Game>(context);
            List<IgdbGame> gamesToReturn = new List<IgdbGame>();
            List<Game> GamesFromPersonalDB = gameRepository.GetGamesByTitle("Yoshi's");
            IgdbService igdbService = new IgdbService(_httpClientFactory, gameRepository, genericGameRepo, _esrbratingRepo);
            foreach (var game in GamesFromPersonalDB)
            {
                IgdbGame gameToAdd = new IgdbGame(1, game.Title, game.CoverPicture.ToString(), game.Igdburl);
                gamesToReturn.Add(gameToAdd);
            }

            List<IgdbGame> gamesFromAPIMocked = new List<IgdbGame>
            {
                new IgdbGame(1, "Yoshi's Topsy Turvey", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(2, "Yoshi's Story", "https://www.igdb.com/games/gears-of-war-3", "https://images.igdb.com/igdb/image/upload/t_thumb/co2a21.png"),
                new IgdbGame(3, "Yoshi's Game", "https://www.igdb.com/games/gears-of-war-4", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(4, "Yoshi's Story 2", "https://www.igdb.com/games/gears-of-war-5", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(5, "Yoshi's Story 3", "https://www.igdb.com/games/gears-of-war-judgment", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y2a.png"),
                new IgdbGame(6, "Yoshi's Story 4", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(7, "Yoshi's Story 5", "https://www.igdb.com/games/gears-of-war-6", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(8, "Yoshi's Story 6", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(9, "Yoshi's Story 7", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(10, "Yoshi's Story 8", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
            };

            int numberOfGames = 10;

            //Act
            igdbService.FinishGamesListForView(GamesFromPersonalDB, gamesFromAPIMocked, gamesToReturn, numberOfGames);


            //Assert
            Assert.AreEqual(numberOfGames, gamesToReturn.Count());
        }

        [Test]
        public void GPDBContextFinishGamesaListWithGamesInTheDBCheckingToSeeIfGamesWhereAddedToDatabaseShouldReturnTrue()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            GameRepository gameRepository = new GameRepository(context);
            Repository<Game> genericGameRepo = new Repository<Game>(context);
            List<IgdbGame> gamesToReturn = new List<IgdbGame>();
            List<Game> GamesFromPersonalDB = gameRepository.GetGamesByTitle("Gears Of War");
            IIgdbService igdbService = new IgdbService(_httpClientFactory, _gameRepository, _genericGameRepo, _esrbratingRepo);
            foreach (var game in GamesFromPersonalDB)
            {
                IgdbGame gameToAdd = new IgdbGame(1, game.Title, game.CoverPicture.ToString(), game.Igdburl);
                gamesToReturn.Add(gameToAdd);
            }

            List<IgdbGame> gamesFromAPIMocked = new List<IgdbGame>
            {
                new IgdbGame(1, "Gears Of War 2", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(2, "Gears Of War 3", "https://www.igdb.com/games/gears-of-war-3", "https://images.igdb.com/igdb/image/upload/t_thumb/co2a21.png"),
                new IgdbGame(3, "Gears Of War 4", "https://www.igdb.com/games/gears-of-war-4", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(4, "Gears Of War 5", "https://www.igdb.com/games/gears-of-war-5", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(5, "Gears Of War Judgment", "https://www.igdb.com/games/gears-of-war-judgment", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y2a.png"),
                new IgdbGame(6, "Gears Of War ", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(7, "Gears Of War 6", "https://www.igdb.com/games/gears-of-war-6", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(8, "Gears Of War 7", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(9, "Gears Of War 8", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(10, "Gears Of War 9", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
            };

            int numberOfGames = 10;
            bool expected = true;

            //Act
            igdbService.FinishGamesListForView(GamesFromPersonalDB, gamesFromAPIMocked, gamesToReturn, numberOfGames);


            //Assert
            List<Game> check = gameRepository.GetGamesByTitle("Gears Of War");

            Game gameToCheck = new Game();
            gameToCheck.Id = 103;
            gameToCheck.Title = "Gears Of War 2";
            gameToCheck.CoverPicture = "https://www.igdb.com/games/gears-of-war-2";
            gameToCheck.Igdburl = "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png";

            bool result = check.Any(c => c.Title == "Gears Of War 2");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GPDBContextFinishGamesaListWithGamesNotInTheDBCheckingToSeeIfGamesWhereAddedToDatabaseShouldReturnTrue()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            GameRepository gameRepository = new GameRepository(context);
            Repository<Game> genericGameRepo = new Repository<Game>(context);
            List<IgdbGame> gamesToReturn = new List<IgdbGame>();
            List<Game> GamesFromPersonalDB = gameRepository.GetGamesByTitle("Yoshi's");
            IIgdbService igdbService = new IgdbService(_httpClientFactory, _gameRepository, _genericGameRepo, _esrbratingRepo);
            foreach (var game in GamesFromPersonalDB)
            {
                IgdbGame gameToAdd = new IgdbGame(1, game.Title, game.CoverPicture.ToString(), game.Igdburl);
                gamesToReturn.Add(gameToAdd);
            }

            List<IgdbGame> gamesFromAPIMocked = new List<IgdbGame>
            {
                new IgdbGame(1, "Yoshi's Topsy Turvey", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(2, "Yoshi's Story", "https://www.igdb.com/games/gears-of-war-3", "https://images.igdb.com/igdb/image/upload/t_thumb/co2a21.png"),
                new IgdbGame(3, "Yoshi's Game", "https://www.igdb.com/games/gears-of-war-4", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(4, "Yoshi's Story 2", "https://www.igdb.com/games/gears-of-war-5", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(5, "Yoshi's Story 3", "https://www.igdb.com/games/gears-of-war-judgment", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y2a.png"),
                new IgdbGame(6, "Yoshi's Story 4", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(7, "Yoshi's Story 5", "https://www.igdb.com/games/gears-of-war-6", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(8, "Yoshi's Story 6", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(9, "Yoshi's Story 7", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(10, "Yoshi's Story 8", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
            };

            int numberOfGames = 10;
            bool expected = true;

            //Act
            igdbService.FinishGamesListForView(GamesFromPersonalDB, gamesFromAPIMocked, gamesToReturn, numberOfGames);


            //Assert
            List<Game> check = gameRepository.GetGamesByTitle("Yoshi's");

            Game gameToCheck = new Game();
            gameToCheck.Id = 103;
            gameToCheck.Title = "Yoshi's Story";
            gameToCheck.CoverPicture = "https://www.igdb.com/games/gears-of-war-2";
            gameToCheck.Igdburl = "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png";

            bool result = check.Any(c => c.Title == "Yoshi's Story");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GPDBContextFinishGamesaListWithPartialGamesInDatabaseCheckingForNoDuplicatesShouldReturnOne()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            GameRepository gameRepository = new GameRepository(context);
            Repository<Game> genericGameRepo = new Repository<Game>(context);
            List<IgdbGame> gamesToReturn = new List<IgdbGame>();
            List<Game> GamesFromPersonalDB = gameRepository.GetGamesByTitle("Gears Of War");
            IIgdbService igdbService = new IgdbService(_httpClientFactory, _gameRepository, _genericGameRepo, _esrbratingRepo);
            foreach (var game in GamesFromPersonalDB)
            {
                IgdbGame gameToAdd = new IgdbGame(1, game.Title, game.CoverPicture.ToString(), game.Igdburl);
                gamesToReturn.Add(gameToAdd);
            }

            List<IgdbGame> gamesFromAPIMocked = new List<IgdbGame>
            {
                new IgdbGame(1, "Gears Of War", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(1, "Gears Of War 2", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(2, "Gears Of War 3", "https://www.igdb.com/games/gears-of-war-3", "https://images.igdb.com/igdb/image/upload/t_thumb/co2a21.png"),
                new IgdbGame(3, "Gears Of War 4", "https://www.igdb.com/games/gears-of-war-4", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(4, "Gears Of War 5", "https://www.igdb.com/games/gears-of-war-5", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(5, "Gears Of War Judgment", "https://www.igdb.com/games/gears-of-war-judgment", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y2a.png"),
                new IgdbGame(6, "Gears Of War ", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(7, "Gears Of War 6", "https://www.igdb.com/games/gears-of-war-6", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(8, "Gears Of War 7", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(9, "Gears Of War 8", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(10, "Gears Of War 9", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
            };

            int numberOfGames = 10;
            int expected = 1;
            int result = 0;

            //Act
            igdbService.FinishGamesListForView(GamesFromPersonalDB, gamesFromAPIMocked, gamesToReturn, numberOfGames);


            //Assert
            List<Game> check = gameRepository.GetGamesByTitle("Gears Of War");

            Game gameToCheck = new Game();
            gameToCheck.Id = 103;
            gameToCheck.Title = "Gears Of War 2";
            gameToCheck.CoverPicture = "https://www.igdb.com/games/gears-of-war-2";
            gameToCheck.Igdburl = "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png";

            foreach (var game in check)
            {
                if (game.Title == "Gears Of War")
                {
                    result++;
                }
            }

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GPDBContextFinishGamesaListWithPartialGamesInDBAndLessThenTenAddedShouldReturn5()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            GameRepository gameRepository = new GameRepository(context);
            Repository<Game> genericGameRepo = new Repository<Game>(context);
            List<IgdbGame> gamesToReturn = new List<IgdbGame>();
            List<Game> GamesFromPersonalDB = gameRepository.GetGamesByTitle("Gears Of War");
            IIgdbService igdbService = new IgdbService(_httpClientFactory, _gameRepository, _genericGameRepo, _esrbratingRepo);
            foreach (var game in GamesFromPersonalDB)
            {
                IgdbGame gameToAdd = new IgdbGame(1, game.Title, game.CoverPicture.ToString(), game.Igdburl);
                gamesToReturn.Add(gameToAdd);
            }

            List<IgdbGame> gamesFromAPIMocked = new List<IgdbGame>
            {
                new IgdbGame(1, "Gears Of War 2", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(2, "Gears Of War 3", "https://www.igdb.com/games/gears-of-war-3", "https://images.igdb.com/igdb/image/upload/t_thumb/co2a21.png"),
                new IgdbGame(3, "Gears Of War 4", "https://www.igdb.com/games/gears-of-war-4", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(4, "Gears Of War 5", "https://www.igdb.com/games/gears-of-war-5", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
            };

            int numberOfGames = 5;

            //Act
            igdbService.FinishGamesListForView(GamesFromPersonalDB, gamesFromAPIMocked, gamesToReturn, numberOfGames);


            //Assert
            Assert.AreEqual(numberOfGames, gamesToReturn.Count());
        }

        [Test]
        public void GPDBContextFinishGamesaListWithNoGamesInDBAndLessThenTenAddedShouldReturn4()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            GameRepository gameRepository = new GameRepository(context);
            Repository<Game> genericGameRepo = new Repository<Game>(context);
            List<IgdbGame> gamesToReturn = new List<IgdbGame>();
            List<Game> GamesFromPersonalDB = gameRepository.GetGamesByTitle("Super Man");
            IIgdbService igdbService = new IgdbService(_httpClientFactory, _gameRepository, _genericGameRepo, _esrbratingRepo);
            foreach (var game in GamesFromPersonalDB)
            {
                IgdbGame gameToAdd = new IgdbGame(1, game.Title, game.CoverPicture.ToString(), game.Igdburl);
                gamesToReturn.Add(gameToAdd);
            }

            List<IgdbGame> gamesFromAPIMocked = new List<IgdbGame>
            {
                new IgdbGame(1, "Super Man", "https://www.igdb.com/games/gears-of-war-2", "https://images.igdb.com/igdb/image/upload/t_thumb/co28gg.png"),
                new IgdbGame(2, "Super Man 2", "https://www.igdb.com/games/gears-of-war-3", "https://images.igdb.com/igdb/image/upload/t_thumb/co2a21.png"),
                new IgdbGame(3, "Super Man 3", "https://www.igdb.com/games/gears-of-war-4", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
                new IgdbGame(4, "Super Man 4", "https://www.igdb.com/games/gears-of-war-5", "https://images.igdb.com/igdb/image/upload/t_thumb/co2y29.png"),
            };

            int numberOfGames = 4;

            //Act
            igdbService.FinishGamesListForView(GamesFromPersonalDB, gamesFromAPIMocked, gamesToReturn, numberOfGames);

            //Assert
            Assert.AreEqual(numberOfGames, gamesToReturn.Count());
        }

    }
}
