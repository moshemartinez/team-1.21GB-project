using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Moq;
using Moq.Contrib.HttpClient;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.Services.Concrete;
using Team121GBCapstoneProject.Models;
using Team121GBNUnitTest;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Moq.Protected;

namespace Team121GBNUinitTests;

public class IgdbAPIServiceTests
{
    private readonly string _igdbClientId = "8ah5b0s8sx19uadsx3b5m4bfekrgla";
    private readonly string _igdbBearerToken = "llrnvo5vfowcyr0ggecl445q5dunyl";
    private IGameRepository _gameRepository;
    private IRepository<Game> _genericGameRepo;
    private InMemoryDbHelper<GPDbContext> _dbHelper;

    [SetUp]
    public void SetUp()
    {
        _dbHelper = new InMemoryDbHelper<GPDbContext>(null, DbPersistence.OneDbPerTest);
        _gameRepository = new GameRepository(_dbHelper.GetContext());
        _genericGameRepo = new Repository<Game>(_dbHelper.GetContext());

    }

    // Tests from Moshe (Sprint 2)

    [Test]
    public async Task IgdbService_GetJsonStringFromEndpoint_RequestAccepted()
    {
        // --> Arrange
        // Define the search query and the endpoint URL
        string searchBody = $"search \"Mario\"; fields name, cover.url, url; where parent_game = null;";
        string searchUri = "https://api.igdb.com/v4/games/";

        // Create a mock HttpMessageHandler to handle the request
        var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"key\":\"value\"}") });

        // Use the mock handler to create an HttpClient that will return the mock response
        var httpClient = new HttpClient(handler.Object)
        {
            BaseAddress = new Uri("https://api.igdb.com/v4/")
        };

        // Create a mock IHttpClientFactory that will return the mock HttpClient
        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

        // Create an instance of the IgdbService, passing in the mock HttpClientFactory and any other dependencies
        var igdbService = new IgdbService(mockHttpClientFactory.Object, _gameRepository, _genericGameRepo);

        // --> Act
        // Call the method under test and capture the result
        var result = await igdbService.GetJsonStringFromEndpoint(_igdbBearerToken, searchUri, _igdbClientId, searchBody);

        // --> Assert
        // Verify that the result matches the expected value
        Assert.That(result, Is.EqualTo("{\"key\":\"value\"}"));
    }

    [Test]
    public async Task IgdbService_GetJsonStringFromEndpoint_RequestDenied_ThrowsException()
    {
        // --> Arrange
        // Define the search request body and URI
        string searchBody = $"search \"Mario\"; fields name, cover.url, url; where parent_game = null;";
        string searchUri = "https://api.igdb.com/v4/games/";

        // Set up a mock HttpMessageHandler with a strict mock behavior
        var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        // Set up the mock handler to return a Forbidden response for any request message
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Forbidden));

        // Create a new HttpClient using the mock handler, and set the BaseAddress
        var httpClient = new HttpClient(handler.Object)
        {
            BaseAddress = new Uri("https://api.igdb.com/v4/")
        };

        // Set up a mock IHttpClientFactory that returns the mock HttpClient
        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

        // Create a new instance of the IgdbService using the mock HttpClientFactory
        var igdbService = new IgdbService(mockHttpClientFactory.Object, _gameRepository, _genericGameRepo);

        // --> Act & Assert
        // Assert that calling the method with the mock HttpClient will throw an HttpRequestException
        Assert.ThrowsAsync<System.Net.Http.HttpRequestException>(async () =>
            await igdbService.GetJsonStringFromEndpoint(_igdbBearerToken, searchUri, _igdbClientId, searchBody)
        );
    }


    //[Test]
    //public async Task IgdbService_Request_Denied()
    //{
    //    //Arrange
    //    var handler = new Mock<HttpMessageHandler>();
    //    string searchBody = $"search \"Mario\"; fields name, cover.url, url; where parent_game = null;";
    //    string searchUri = "https://api.igdb.com/v4/games/";

    //    handler.SetupAnyRequest()
    //        .ReturnsResponse(HttpStatusCode.NotFound);
    //    //New up the service class
    //    IgdbService igdbService = new IgdbService(handler.CreateClientFactory(), _gameRepository, _genericGameRepo);

    //    //Act
    //    Task<string> Act() => igdbService.GetJsonStringFromEndpoint("incorrectToken", searchUri, _igdbClientId, searchBody);

    //    //Assert
    //    Assert.That(Act, Throws.TypeOf<HttpRequestException>());
    //}
}