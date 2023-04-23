using System;
using System.Security.Policy;
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
        //do nothing I am a visitor
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

    [Given(@"I am a logged in user")]
    public void GivenIAmALoggedInUser()
    {
        _homePage.GoTo();
        _userLoginsStepDefinitions.GivenIAmAUserWithFirstName("Talia");
        _userLoginsStepDefinitions.WhenILogin();
    }

    [Given(@"I navigate to the image generator page")]
    public void GivenINavigateToTheImageGeneratorPage()
    {
        _homePage.NavBarHelloLink.Click();
        _profilePage.generateDalleImageButton.Click();
        _generateImagePage.GetTitle().Should().Be("Dalle Page");
    }

    [Then(@"I should see a counter telling me how many image credits I have")]
    public void ThenIShouldSeeACounterTellingMeHowManyImageCreditsIHave()
    {
        _generateImagePage.CreditsCounter.Should().NotBeNull();
    }

    [Then(@"I input a prompt")]
    public void ThenIInputAPrompt()
    {
        string prompt = "Super Cool Prompt";
        _generateImagePage.EnterPrompt(prompt);
    }

    [Then(@"click the Generate Image Button my credits will decrease by (.*)")]
    public void ThenClickTheGenerateImageButtonMyCreditsWillDecreaseBy(int one)
    {
        _generateImagePage.SubmitPromptButton.Click();
        _generateImagePage.CreditsCounter.Text.Should().Be(one.ToString()); // This is not going to work currently need to come back  and fix this.
    }

    [Given(@"I am on the image generator page")]
    public void GivenIAmOnTheImageGeneratorPage()
    {
        _generateImagePage.GetTitle().Should().Be("Dalle Page");
        ThenIShouldSeeACounterTellingMeHowManyImageCreditsIHave();
    }

    [Given(@"I have no image credits left")]
    public void GivenIHaveNoImageCreditsLeft()
    {
        _generateImagePage.CreditsCounter.Text.Should().Be("0"); // This is not going to work currently need to come back  and fix this.
    }

    [Given(@"I try and generate an image")]
    public void GivenITryAndGenerateAnImage()
    {
        _generateImagePage.SubmitPromptButton.Click();
    }

    [Then(@"I will be told that I can't generate any more images")]
    public void ThenIWillBeToldThatICantGenerateAnyMoreImages()
    {
        //set some text to you don't have any credits and can't generate an image etc.
        throw new PendingStepException();
        //assert that the text was set
    }

    [Given(@"I've generated an image")]
    public void GivenIveGeneratedAnImage()
    {
        // Not sure that I need to anything here 
    }

    [When(@"I click the button for setting it as my profile picture")]
    public void WhenIClickTheButtonForSettingItAsMyProfilePicture()
    {
        //trigger the controller method
        throw new PendingStepException();
    }

    [Then(@"my profile picture will be updated to display the new profile image")]
    public void ThenMyProfilePictureWillBeUpdatedToDisplayTheNewProfileImage()
    {
        //Not really sure how to assert this one yet
        throw new PendingStepException();
    }

    [Given(@"I am a logged in user on the image generator page")]
    public void GivenIAmALoggedInUserOnTheImageGeneratorPage()
    {
        _userLoginsStepDefinitions.GivenIAmAUserWithFirstName("Talia");
        _userLoginsStepDefinitions.WhenILogin();
        _generateImagePage.GoTo("Dalle Page");
        _generateImagePage.GetTitle().Should().Be("Dalle Page");
    }

    [Given(@"I've enterred a prompt")]
    public void GivenIveEnterredAPrompt()
    {
        ThenIInputAPrompt();
        ThenClickTheGenerateImageButtonMyCreditsWillDecreaseBy(1);
    }

    [Given(@"the image generation failed")]
    public void GivenTheImageGenerationFailed()
    {
        //Do nothing the nothing to assert yet
    }

    [Then(@"I should be notified that something went wrong\.")]
    public void ThenIShouldBeNotifiedThatSomethingWentWrong_()
    {
        _generateImagePage.StatusNotificationDiv.Text.Should().Be("Something went wrong...");
    }
}