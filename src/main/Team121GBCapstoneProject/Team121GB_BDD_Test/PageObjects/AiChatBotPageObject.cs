using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Standups_BDD_Tests.PageObjects;

namespace Team121GB_BDD_Test.PageObjects;

public class AiChatBotPageObject : PageObject   
{
    public AiChatBotPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "ChatGPT page";
    }

    public IWebElement PromptInput => _webDriver.FindElement(By.Id("prompt"));
    public IWebElement SubmitPromptButton => _webDriver.FindElement(By.Id("send"));
    public void InputPrompt(string prompt) => PromptInput.SendKeys(prompt);

    public int CheckIfResponseExists()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
            IReadOnlyCollection<IWebElement> responses = _webDriver.FindElements(By.ClassName("card text-white bg-primary"));
            responses.Should().NotBeNullOrEmpty();
            return responses.Count();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
    }

}
