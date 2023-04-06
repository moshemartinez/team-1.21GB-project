using System;
using TechTalk.SpecFlow;

namespace Team121GB_BDD_Test.StepDefinitions
{
    [Binding]
    public class HomeStepDefinitions
    {
        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
            //Nothing to Do!!
        }

        [When(@"I am on the ""([^""]*)"" page")]
        public void WhenIAmOnThePage(string page)
        {
            throw new PendingStepException();
        }

        [Then(@"The page title contains ""([^""]*)""")]
        public void ThenThePageTitleContains(string p0)
        {
            throw new PendingStepException();
        }
    }
}
