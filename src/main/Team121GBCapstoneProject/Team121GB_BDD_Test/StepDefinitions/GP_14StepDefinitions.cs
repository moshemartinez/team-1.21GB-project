using Standups_BDD_Tests.Drivers;
using Standups_BDD_Tests.PageObjects;
using System;
using Team121GB_BDD_Test.PageObjects;
using TechTalk.SpecFlow;

namespace Team121GB_BDD_Test.StepDefinitions
{
    [Binding]
    public class GP_14StepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPageObject _loginPage;
        private readonly ProfilePageObject _profilePage;

        public GP_14StepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _loginPage = new LoginPageObject(browserDriver.Current);
            _profilePage = new ProfilePageObject(browserDriver.Current);
            _scenarioContext = context;
        }

        [When(@"I navigate to the account preferences page")]
        public void WhenINavigateToTheAccountPreferencesPage()
        {
            _profilePage.GoTo();
        }


        [Then(@"I should see a form with a text box to edit my profile name and a submit button\.")]
        public void ThenIShouldSeeAFormWithATextBoxToEditMyProfileNameAndASubmitButton_()
        {
            throw new PendingStepException();
        }
    }
}
