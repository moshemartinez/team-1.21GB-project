﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Standups_BDD_Tests.PageObjects;

public class GenerateImagePageObject : PageObject
{
    public GenerateImagePageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "Dalle Page";
    }

    public IWebElement SubmitPromptButton =>_webDriver.FindElement(By.Id("submitPromptButton"));
    public IWebElement UserPrompt => _webDriver.FindElement(By.Id("userPrompt"));
    public IWebElement CreditsCounter => _webDriver.FindElement(By.Id("creditsCounter"));
    public IWebElement StatusNotificationDiv => _webDriver.FindElement(By.Id("statusNotificationDiv"));

    public void WaitForJavascriptToUpdateDom()
    {
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        wait.Until(e => StatusNotificationDiv.Text == "Inappropriate prompt.");
    }
    public void EnterPrompt(string prompt)
    {
        UserPrompt.Clear();
        UserPrompt.SendKeys(prompt);
    }

}