using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.Models;

namespace Team121GBNUnitTest
{
    public class SpeedSearchTests
    {
        public static readonly string _seedFile = @"..\..\..\Data\seed.sql";
        private InMemoryDbHelper<GPDbContext> _dbHelper = new InMemoryDbHelper<GPDbContext>(_seedFile, DbPersistence.OneDbPerTest);

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGameRepository _gameRepository;
        private readonly IRepository<Game> _genericGameRepo;
        private readonly IRepository<Esrbrating> _esrbratingRepo;
        private readonly IRepository<GameGenre> _gameGenreRepository;
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<Platform> _platformRepository;
        private readonly IRepository<GamePlatform> _gamePlatformRepository;

        //Testing TitleParse
        [Test]
        public void TitleParseGivenAEmptyInputShouldReturnEmptyList()
        {
            //Arrange
            List<string> listToCheck = new List<string>();
            using GPDbContext context = _dbHelper.GetContext();
            SpeedSearch speedSearch = new SpeedSearch(context);

            //Act
            listToCheck = speedSearch.TitleParse("");

            //Assert
            Assert.AreEqual(0,listToCheck.Count());
        }

        [Test]
        public void TitleParseGivenAValidInputShouldReturnListOfCount2()
        {
            //Arrange
            List<string> listToCheck = new List<string>();
            using GPDbContext context = _dbHelper.GetContext();
            SpeedSearch speedSearch = new SpeedSearch(context);

            //Act
            listToCheck = speedSearch.TitleParse("*Super Mario Brothers *Super Mario 64");

            //Assert
            Assert.AreEqual(2, listToCheck.Count());
        }

        [Test]
        public void TitleParseGivenAValidInputShouldReturnListOfCount1()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            SpeedSearch speedSearch = new SpeedSearch(context);
            List<string> listToCheck = new List<string>();

            //Act
            listToCheck = speedSearch.TitleParse("*Super Mario Brothers");

            //Assert
            Assert.AreEqual(1, listToCheck.Count());
        }

        //Testing GetFirstSearchResult
        [Test]
        public void GetFirstSearchResultWithSuperMarioBrosAsQueryShouldNotBeNull()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            SpeedSearch speedSearch = new SpeedSearch(context);

            //Act
            Game gameToCheck = speedSearch.GetFirstSearchResult("Super Mario Bros");

            //Assert
            bool expected = true;
            bool result = true;

            if (gameToCheck == null)
            {
                result = false;
            }
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetFirstSearchResultWithInvalidGameAsQueryShouldBeNull()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            SpeedSearch speedSearch = new SpeedSearch(context);

            //Act
            Game gameToCheck = speedSearch.GetFirstSearchResult("dkjvnskjdcnoiwncdjksnckeslnjvrkjsenckdncs123456789");

            //Assert
            bool expected = false;
            bool result = true;

            if (gameToCheck == null)
            {
                result = false;
            }
            Assert.AreEqual(expected, result);
        }

        //Testing SpeedSearch
        [Test]
        public void SpeedSearchWithTwoMarioGamesListShouldHaveACountOf2()
        {
            //Arrange
            using GPDbContext context = _dbHelper.GetContext();
            SpeedSearch speedSearch = new SpeedSearch(context);

            //Act
            List<Game> listToCheck = speedSearch.SpeedSearching("*Super Mario Bros *Super Mario 64");

            //Assert
            Assert.AreEqual(2, listToCheck.Count());
        }
    }
}
