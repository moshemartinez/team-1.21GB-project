using Team121GBCapstoneProject.Services.Concrete;
using Team121GBCapstoneProject.Models;
using Microsoft.Extensions.Configuration;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using Moq;
using System.Net;

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
        // Mock<HttpMessageHandler> mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        // HttpResponseMessage responseMessage = new HttpResponseMessage()
        // {
        //     StatusCode = HttpStatusCode.OK,
        //     Content = new StringContent("Fake content")
        // };
        // //Mock<IOpenAIService> mockOpenAiService = new Mock<IOpenAIService>();
        // // //mockOpenAiService.Setup(x => x.GetResponseAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(responseMessage);
        // // //mockOpenAiService.Setup(x => x.ChatCompletion( new ChatCompletionRequest() { Prompt = prompt, MaxTokens = 150, Stop = new string[] { "\n" } })).ReturnsAsync(new ChatCompletionResponse() { Choices = new Choice[] { new Choice() { Text = expectedResult } } });

        // // mockOpenAiService.Setup(x => x);
        OpenAI.GPT3.OpenAiOptions openAiOptions = new OpenAI.GPT3.OpenAiOptions()
        {
            ApiKey = key,
            BaseDomain = "https://fake.com"
        };
        IOpenAIService openAiService = new OpenAIService(openAiOptions);

        ChatGptService chatGptService = new ChatGptService(openAiService);
        // ! Act
        string result = chatGptService.GetChatResponse(prompt).Result;
        // ? Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void GetChatResponse_Success()
    {
        // * Arrange
        string key = _configuration["OpenAIServiceOptions:ApiKey"];
        string somePrompt = "Hello World!";
        OpenAI.GPT3.OpenAiOptions openAiOptions = new OpenAI.GPT3.OpenAiOptions()
        {
            ApiKey = key
        };
        IOpenAIService openAiService = new OpenAIService(openAiOptions);
        ChatGptService chatGptService = new ChatGptService(openAiService);
        // ! Act
        string result = chatGptService.GetChatResponse(somePrompt).Result;
        // ? Assert
        Assert.That(result, Is.Not.Null.And.Not.Empty.And.Not.EqualTo(somePrompt));

    }
}