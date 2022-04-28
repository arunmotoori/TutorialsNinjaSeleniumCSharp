using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialsNinja.Hooks;

namespace TutorialsNinja.PageObjects
{
    public class SearchPage
    {
        public IWebDriver driver;

        private By searchBoxField = By.Name("search");

        private By searchButton = By.CssSelector("i[class$='fa-search']");

        private By hpProduct = By.LinkText("HP LP3065");

        public SearchPage()
        {

            driver = WebHooks.driver;

        }

        public void EnterProductNameIntoSearchBox(string productName)
        {

            driver.FindElement(searchBoxField).SendKeys(productName);

        }

        public void ClickOnSearchButton()
        {

            driver.FindElement(searchButton).Click();
        }

        public bool IsProductDisplayed()
        {

            return driver.FindElement(hpProduct).Displayed;

        }

    }
}
