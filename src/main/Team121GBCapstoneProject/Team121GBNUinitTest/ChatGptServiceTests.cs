using Team121GBCapstoneProject.Services.Concrete;
using Team121GBCapstoneProject.Models;
using Microsoft.Extensions.Configuration;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;

namespace Team121GBNUnitTest;
#nullable enable

public class ChatGptServiceTests
{
    private IConfigurationRoot _configuration;
    private string _dallePrivateKey;
    private string _dallePublicKey;
    private IOpenAIService _openAiService;
    private InMemoryDbHelper<GPDbContext> _dbHelper;

    [SetUp]
    public void SetUp()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddUserSecrets<ChatGptServiceTests>();
        _configuration = builder.Build();
    }

    [TestCase("", "")]
    [TestCase(null, "")]
    public void GetChatResponse(string prompt, string expectedResult)
    {
        // * Arrange
        string key = "Fake key";
        Mock<HttpMessageHandler> mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        HttpResponseMessage responseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("Fake content")
        };
        Mock<IOpenAIService> mockOpenAiService = new Mock<IOpenAIService>
        {
            ApiKey = key
        };
        ChatGptService chatGptService = new ChatGptService(openAiService);
        // ! Act
        string result = chatGptService.GetChatResponse(prompt).Result;
        // ? Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}