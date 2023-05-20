﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Team121GB_BDD_Test.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GP-21-AccountPreferences")]
    [NUnit.Framework.CategoryAttribute("Nathaniel")]
    public partial class GP_21_AccountPreferencesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "Nathaniel"};
        
#line 1 "GP-21-AccountPreferences.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "GP-21-AccountPreferences", "** As a user, I want to be able to see my account preferences so that I can custo" +
                    "mize my account ** \r\n\r\nThis feature ensures that user who is logged in can see a" +
                    "nd customize their account preferences on a \r\ndedicated web page.", ProgrammingLanguage.CSharp, new string[] {
                        "Nathaniel"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 8
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table13.AddRow(new string[] {
                        "TaliaK",
                        "knott@example.com",
                        "Talia",
                        "Knott",
                        "Password1!"});
            table13.AddRow(new string[] {
                        "ZaydenC",
                        "clark@example.com",
                        "Zayden",
                        "Clark",
                        "Password1!"});
            table13.AddRow(new string[] {
                        "DavilaH",
                        "hareem@example.com",
                        "Hareem",
                        "Davila",
                        "Password1!"});
#line 9
 testRunner.Given("the following users exist", ((string)(null)), table13, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table14.AddRow(new string[] {
                        "AndreC",
                        "colea@example.com",
                        "Andre",
                        "Cole",
                        "0a9dfi3.a"});
            table14.AddRow(new string[] {
                        "JoannaV",
                        "valdezJ@example.com",
                        "Joanna",
                        "Valdez",
                        "d9u(*dsF4"});
#line 14
 testRunner.And("the following users do not exist", ((string)(null)), table14, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Logged in user can click on their name in the navbar")]
        [NUnit.Framework.CategoryAttribute("LoggedIn")]
        [NUnit.Framework.TestCaseAttribute("Talia", "Home", "Profile", null)]
        [NUnit.Framework.TestCaseAttribute("Zayden", "Home", "Profile", null)]
        [NUnit.Framework.TestCaseAttribute("Hareem", "Home", "Profile", null)]
        public virtual void LoggedInUserCanClickOnTheirNameInTheNavbar(string firstName, string page, string profilePage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "LoggedIn"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("Page", page);
            argumentsOfScenario.Add("ProfilePage", profilePage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logged in user can click on their name in the navbar", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
this.FeatureBackground();
#line hidden
#line 21
 testRunner.Given(string.Format("I am a logged in user with Firstname \'{0}\'", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
 testRunner.And(string.Format("I am on the \'{0}\' page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.When("I click my name in the navbar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then(string.Format("I should be redirected to the \'{0}\' page", profilePage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
