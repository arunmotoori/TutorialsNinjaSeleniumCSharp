using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsNinja.PageObjects
{
    public class AccountSuccessPage
    {
        public IWebDriver driver;

        private By accountSuccessPageHeading = By.XPath("//div[@id='content']/h1");

        public AccountSuccessPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public bool IsAccountCreated()
        {
            return driver.FindElement(accountSuccessPageHeading).Text.Equals("Your Account Has Been Created!");

        }


    }
}
