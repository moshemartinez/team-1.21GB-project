using System;
using System.Security.Policy;
using System.Text.RegularExpressions;
using AngleSharp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using Standups_BDD_Tests.Drivers;
using Standups_BDD_Tests.PageObjects;
using Standups_BDD_Tests.StepDefinitions;
using Team121GB_BDD_Test.PageObjects;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;

namespace Team121GB_BDD_Test.StepDefinitions;

[Binding]
public class GP_85_SetDalleImageToProfilePictureStepDefinitions
{
    private readonly HomePageObject _homePage;
    private readonly ProfilePageObject _profilePage;
    private readonly GenerateImagePageObject _generateImagePage;
    private readonly UserLoginsStepDefinitions _userLoginsStepDefinitions;
    private readonly BrowserDriver _browserDriver;
    private int _creditCount;
    public GP_85_SetDalleImageToProfilePictureStepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
    {
        _homePage = new HomePageObject(browserDriver.Current);
        _profilePage = new ProfilePageObject(browserDriver.Current);
        _generateImagePage = new GenerateImagePageObject(browserDriver.Current);
        _userLoginsStepDefinitions = new UserLoginsStepDefinitions(context, browserDriver);
        _browserDriver = browserDriver;
    }

    [Given(@"I am not logged in")]
    public void GivenIAmNotLoggedIn()
    {
        //do nothing you are a visitor
    }

    [Given(@"I am on the home page")]
    public void GivenIAmOnTheHomePage() => _homePage.GoTo();

    [Given(@"I attempt to access the image generator page,")]
    public void GivenIAttemptToAccessTheImageGeneratorPage() => _generateImagePage.GoTo("Dalle Page");

    [Then(@"I should be ask to login before accessing the page\.")]
    public void ThenIShouldBeAskToLoginBeforeAccessingThePage_() => _browserDriver.Current.Title.Should().Be("Log in");

    [Given(@"I am a logged in user with first name '([^']*)'")]
    public void GivenIAmALoggedInUserWithFirstName(string user)
    {
        GivenIAmOnTheHomePage();
        _userLoginsStepDefinitions.GivenIAmAUserWithFirstName(user);
        _userLoginsStepDefinitions.WhenILogin();
    }

    [Given(@"I navigate to the image generator page")]
    public void GivenINavigateToTheImageGeneratorPage()
    {
        _homePage.NavBarHelloLink.Click();
        _profilePage.generateDalleImageButton.Click();
        _browserDriver.Current.Title.Should().Be("Dalle Page");
    }

    [Given(@"I should see a counter telling me how many image credits I have that is '([^']*)'")]
    public void GivenIShouldSeeACounterTellingMeHowManyImageCreditsIHaveThatIs(string count) => _generateImagePage.CreditsCounter.Text.Should().Contain(count);
    

    [Given(@"I input a prompt")]
    public void GivenIInputAPrompt() => _generateImagePage.EnterPrompt("Super cool prompt");

    [Then(@"My credits will decrease by (.*)")]
    public void ThenMyCreditsWillDecreaseBy(int one) => _generateImagePage.CreditsCounter.Text.Contains($"{_creditCount - one}");

    [Given(@"I am on the image generator page")]
    public void GivenIAmOnTheImageGeneratorPage()
    {
        GivenINavigateToTheImageGeneratorPage();
        _browserDriver.Current.Title.Should().Be("Dalle Page");
    }

    [When(@"I click the Generate Image Button")]
    public void WhenIClickTheGenerateImageButton()
    {
        string counterText = new string(_generateImagePage.CreditsCounter.Text.Where(Char.IsDigit).ToArray());
        _creditCount = int.Parse(counterText);
        _generateImagePage.SubmitPromptButton.Click();
    }

    [Then(@"I will not be able click the Generate Image Button")]
    public void ThenIWillNotBeAbleClickTheGenerateImageButton() => _generateImagePage.SubmitPromptButton.Enabled.Should().BeFalse();

    [Given(@"I am a logged in user on the image generator page")]
    public void GivenIAmALoggedInUserOnTheImageGeneratorPage()
    {
        GivenIAmALoggedInUserWithFirstName("Talia");
        _generateImagePage.GoTo("Dalle Page");
    }

    [Given(@"I've generated an image")]
    public void GivenIveGeneratedAnImage()
    {
        throw new PendingStepException();
    }

    [When(@"I click the button for setting it as my profile picture")]
    public void WhenIClickTheButtonForSettingItAsMyProfilePicture()
    {
        throw new PendingStepException();
    }

    [Then(@"my profile picture will be updated to display the new profile image")]
    public void ThenMyProfilePictureWillBeUpdatedToDisplayTheNewProfileImage()
    {
        throw new PendingStepException();
    }

    [Given(@"I have  entered a prompt that is totally inappropriate '([^']*)'")]
    public void GivenIHaveEnteredAPromptThatIsTotallyInappropriate(string terriblePrompt)
    {
        _generateImagePage.EnterPrompt(terriblePrompt);
        WhenIClickTheGenerateImageButton();
    }




    [Then(@"I should be notified that something went wrong\.")]
    public void ThenIShouldBeNotifiedThatSomethingWentWrong_()
    {
        _generateImagePage.StatusNotificationDiv.Text.Should().Be("Inappropriate prompt.");
    }
}