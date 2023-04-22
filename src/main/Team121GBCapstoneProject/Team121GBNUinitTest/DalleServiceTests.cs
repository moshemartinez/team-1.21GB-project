using NUnit.Framework;
using Team121GBCapstoneProject.Services;
using Team121GBCapstoneProject.Models;
using Team121GBNUnitTest;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using Microsoft.AspNetCore.Identity;
using OpenAI.GPT3.Interfaces;



namespace Team121GBNUnitTest;

public class DalleServiceTests
{
    private string _dallePrivateKey;
    private string _dallePublicKey;
    private IOpenAIService _openAiService;
    private InMemoryDbHelper<GPDbContext> _dbHelper;

    [SetUp]
public void Setup()
    {
    }

    [TestCase("fakeURL")] // should fail
    [TestCase("")] // should fail
    [TestCase(null)] // should fail
    [TestCase("https://content.codecademy.com/courses/web-101/web101-image_brownbear.jpg")] // good image link
    public void TurnImageUrlIntoByteArray(string imageURL)
    {
        // * Arrange
        // using GPDbContext context = _dbHelper.GetContext();
        _dallePrivateKey = "fake";
        _dallePublicKey = "fake";
        IOpenAIService openAiService = new OpenAIService(_dallePrivateKey, _dallePublicKey);
        DalleService dalleService = new DalleService(openAiService);

        // ! Act
        var result = dalleService.TurnImageUrlIntoByteArray(imageURL);

        // ? Assert
        Assert.IsNotNull(result);
    }
}