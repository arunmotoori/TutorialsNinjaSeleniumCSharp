using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TutorialsNinja.Hooks;
using TutorialsNinja.PageObjects;

namespace TutorialsNinja.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {

        public IWebDriver driver = WebHooks.driver;
        public SearchPage searchPage = null;

        [Given(@"I visit the website as a guest user")]
        public void GivenIVisitTheWebsiteAsAGuestUser()
        {
            driver.Url = "http://tutorialsninja.com/demo/";
        }

        [When(@"I enter valid product into the search box")]
        public void WhenIEnterValidProductIntoTheSearchBox()
        {
            searchPage = new SearchPage();
            searchPage.EnterProductNameIntoSearchBox("HP");
        }

        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            searchPage.ClickOnSearchButton();
        }

        [Then(@"I should see the product in the search results")]
        public void ThenIShouldSeeTheProductInTheSearchResults()
        {
            Assert.IsTrue(searchPage.IsProductDisplayed());
            Thread.Sleep(3000);
        }


    }
}
