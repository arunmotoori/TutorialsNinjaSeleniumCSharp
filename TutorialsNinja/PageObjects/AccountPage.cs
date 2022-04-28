using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsNinja.PageObjects
{
    public class AccountPage
    {
        public IWebDriver driver;

        private By editYourAccountInformationOption = By.LinkText("Edit your account information");

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public bool IsUserLoggedIn()
        {
            return driver.FindElement(editYourAccountInformationOption).Displayed;
        }


    }
}
