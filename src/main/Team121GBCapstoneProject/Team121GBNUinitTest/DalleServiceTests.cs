using NUnit.Framework;
using Team121GBCapstoneProject.Services.Concrete;
using Team121GBCapstoneProject.Models;
using Team121GBNUnitTest;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Contrib.HttpClient;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;


namespace Team121GBNUnitTest;

public class DalleServiceTests
{
    private IConfigurationRoot _configuration;
    private string _dallePrivateKey;
    private string _dallePublicKey;
    private IOpenAIService _openAiService;
    private InMemoryDbHelper<GPDbContext> _dbHelper;
    // private readonly byte[] _expectedResultForValidImgUrl = { client.DownloadData("https://content.codecademy.com/courses/web-101/web101-image_brownbear.jpg") };

    [SetUp]
    public void Setup()
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<DalleServiceTests>();
        _configuration = builder.Build();
        // string validImgUrl = "https://content.codecademy.com/courses/web-101/web101-image_brownbear.jpg";
        // using (var client = new WebClient())
        // {
        //     _expectedResultForValidImgUrl = client.DownloadData(validImgUrl);
        // }
        // //_expectedResultForValidImgUrl = client.DownloadData("https://content.codecademy.com/courses/web-101/web101-image_brownbear.jpg");
    }

    [TestCase("", null)]
    [TestCase(null, null)]
    // [TestCase("https://content.codecademy.com/courses/web-101/web101-image_brownbear.jpg", null)] // good image link
    public void TurnImageUrlIntoByteArray(string imageURL, byte[] expectedResult)
    {
        // * Arrange
        string key = _configuration["OpenAIServiceOptions:ApiKey"];
        OpenAIService openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey = key
        });
        DalleService dalleService = new DalleService(openAiService);
        // ! Act
        byte[] result = dalleService.TurnImageUrlIntoByteArray(imageURL).Result;
        // ? Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    [Test]
    public void TurnImageUrlIntoByteArraySuccess()
    {
        // * Arrange
        string key = _configuration["OpenAIServiceOptions:ApiKey"];
        OpenAIService openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey = key
        });
        DalleService dalleService = new DalleService(openAiService);
        string imageURL = "https://content.codecademy.com/courses/web-101/web101-image_brownbear.jpg";
        // ! Act
        byte[] result = dalleService.TurnImageUrlIntoByteArray(imageURL).Result;
        // ? Assert
        Assert.That(result, Is.Not.Null);
    }
    //[TestCase("https://content.codecademy.com/courses/web-101/web101-image_brownbear.jpg")] // good image link
}