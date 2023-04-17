using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Standups_BDD_Tests.PageObjects;

namespace Team121GB_BDD_Test.PageObjects
{
    public class ProfilePageObject : PageObject
    {
        public ProfilePageObject(IWebDriver webDriver) : base(webDriver)
        {
            _pageName = "Profile";
        }
        public void Logout()
        {
            IWebElement profilePictureBtn = _webDriver.FindElement(By.Id("navbarDropdownMenuLink"));
            profilePictureBtn.Click();
            IWebElement navbarLogoutButton = _webDriver.FindElement(By.Id("logoutBtn"));
            navbarLogoutButton.Click();
        }
    }
}
