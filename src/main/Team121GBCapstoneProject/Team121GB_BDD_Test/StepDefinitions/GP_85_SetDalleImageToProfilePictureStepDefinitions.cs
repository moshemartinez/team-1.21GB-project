using System;
using System.Security.Policy;
using System.Text.RegularExpressions;
using AngleSharp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
    public void GivenIAmOnTheHomePage()
    {
        _homePage.GoTo();
    }


    [Given(@"I attempt to access the image generator page,")]
    public void GivenIAttemptToAccessTheImageGeneratorPage()
    {
        _generateImagePage.GoTo("Dalle Page");
    }

    [Then(@"I should be ask to login before accessing the page\.")]
    public void ThenIShouldBeAskToLoginBeforeAccessingThePage_()
    {
        _browserDriver.Current.Title.Should().Be("Log in");
    }

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

    [Then(@"I should see a counter telling me how many image credits I have")]
    public void ThenIShouldSeeACounterTellingMeHowManyImageCreditsIHave()
    {
        _generateImagePage.CreditsCounter.Should().NotBeNull();
    }

    //[Then(@"click the Generate Image Button my credits will decrease by (.*)")]
    //public void ThenClickTheGenerateImageButtonMyCreditsWillDecreaseBy(int p0)
    //{
    //    string countString = _generateImagePage.CreditsCounter.Text;
    //    Match match = Regex.Match(countString, @"\d+");
    //    int count = 0;
    //    if (match.Success) count = int.Parse(match.Value);
    //    _generateImagePage.SubmitPromptButton.Click();
    //    count -= 1;
    //    _generateImagePage.CreditsCounter.Text.Should().Contain($"Credits remaining: {count}");
    //}

    [Then(@"I input a prompt")]
    public void ThenIInputAPrompt()
    {
        _generateImagePage.EnterPrompt("Super cool prompt");
    }

    [Then(@"click the Generate Image Button")]
    public void ThenClickTheGenerateImageButton()
    {
        _generateImagePage.SubmitPromptButton.Click();
    }

    [Then(@"My credits will decrease by (.*)")]
    public void ThenMyCreditsWillDecreaseBy(int p0)
    {
        //For BDD Tests Talia is the user we use and talia always has 5 credits to start out with
        _generateImagePage.CreditsCounter.Text.Should().Contain("Credits remaining: 4");
    }

    [Given(@"I am on the image generator page")]
    public void GivenIAmOnTheImageGeneratorPage()
    {
        _generateImagePage.GoTo("Dalle Page");
    }

    [Given(@"I have no image credits left")]
    public void GivenIHaveNoImageCreditsLeft()
    {
        // credits are zero fo this user

    }

    [Given(@"I try and generate an image")]
    public void GivenITryAndGenerateAnImage()
    {
        //do nothing inputs are disabled
    }

    [Then(@"I will be told that I can't generate any more images")]
    public void ThenIWillBeToldThatICantGenerateAnyMoreImages()
    {
        _generateImagePage.CreditsCounter.Text.Should()
            .Be("Credits remaining: 0 You've used all of your free credits.");
    }

    [Given(@"I am a logged in user on the image generator page")]
    public void GivenIAmALoggedInUserOnTheImageGeneratorPage()
    {
        throw new PendingStepException();
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

    [Given(@"I've enterred a prompt")]
    public void GivenIveEnterredAPrompt()
    {
        throw new PendingStepException();
    }

    [Given(@"the image generation failed")]
    public void GivenTheImageGenerationFailed()
    {
        throw new PendingStepException();
    }

    [Then(@"I should be notified that something went wrong\.")]
    public void ThenIShouldBeNotifiedThatSomethingWentWrong_()
    {
        throw new PendingStepException();
    }
}