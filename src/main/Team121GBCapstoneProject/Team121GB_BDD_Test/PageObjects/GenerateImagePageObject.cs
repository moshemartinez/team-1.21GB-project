using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Standups_BDD_Tests.PageObjects;

public class GenerateImagePageObject : PageObject
{
    public GenerateImagePageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "Dalle Page";
    }

    public IWebElement SubmitPromptButton =>_webDriver.FindElement(By.Id("submitPromptButton"));
}