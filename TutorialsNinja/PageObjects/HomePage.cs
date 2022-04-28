using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialsNinja.Hooks;

namespace TutorialsNinja.PageObjects
{

    public class HomePage
    {
        public IWebDriver driver;

        private By myAccountDropMenu = By.XPath("//span[text()='My Account']");
        private By registerOption = By.LinkText("Register");
        private By loginOption = By.LinkText("Login");
        public HomePage()
        {
            driver = WebHooks.driver;
        }

        public void ClickOnMyAccountDropMenu()
        {
            driver.FindElement(myAccountDropMenu).Click();

        }

        public RegisterAccountPage SelectRegisterOption()
        {
            driver.FindElement(registerOption).Click();

            return new RegisterAccountPage(driver);

        }

        public LoginPage SelectLoginOption()
        {
            driver.FindElement(loginOption).Click();
            return new LoginPage(driver);
        }


    }
}
