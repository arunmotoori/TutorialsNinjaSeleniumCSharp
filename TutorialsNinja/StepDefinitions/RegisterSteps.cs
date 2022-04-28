using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TutorialsNinja.Hooks;
using TutorialsNinja.PageObjects;

namespace TutorialsNinja.StepDefinitions
{
    [Binding]
    public class RegisterSteps
    {
        public IWebDriver driver = WebHooks.driver;
        public RegisterAccountPage registerAccountPage = null;
        public AccountSuccessPage accountSuccessPage = null;


       [Given(@"I visit the website")]
        public void GivenIVisitTheWebsite()
        {
            driver.Url = "http://tutorialsninja.com/demo/";
        }

        [Given(@"I navigate to Register Account page")]
        public void GivenINavigateToRegisterAccountPage()
        {
            HomePage homePage = new HomePage();
            homePage.ClickOnMyAccountDropMenu();
            registerAccountPage = homePage.SelectRegisterOption();
        }

       
        [When(@"I enter valid details into the fields")]
        public void WhenIEnterValidDetailsIntoAllTheFields(Table table)
        {
            dynamic details = table.CreateDynamicInstance();

            registerAccountPage.EnterFirstName(details.firstname);
            registerAccountPage.EnterLastName(details.lastname);
            registerAccountPage.EnterEmail("amotooricap"+GenerateTimeStamp()+"@gmail.com");
            registerAccountPage.EnterTelephoneNumber((details.telephone).ToString());
            registerAccountPage.EnterPassword((details.password).ToString());
            registerAccountPage.EnterPasswordConfirm((details.password).ToString());

        }

        [When(@"I select yes for subscription")]
        public void WhenISelectYesForSubscription()
        {
            registerAccountPage.SelectYesNewsletterOption();
        }

        [When(@"I select Privacy Policy")]
        public void WhenISelectPrivacyPolicy()
        {
            registerAccountPage.SelectPrivacyPolicyOption();
        }

        [When(@"I click on Continue button")]
        public void WhenIClickOnContinueButton()
        {
            accountSuccessPage = registerAccountPage.ClickOnContinueButton();
        }

        [Then(@"Account should be created")]
        public void ThenAccountShouldBeCreated()
        {
            Assert.IsTrue(accountSuccessPage.IsAccountCreated());
            Thread.Sleep(3000);
        }

        public string GenerateTimeStamp()
        {

            return DateTime.Now.ToString("yyyyMMddHHmmssffff");


        }

        [Then(@"Account should not be created")]
        public void ThenAccountShouldNotBeCreated()
        {
            Assert.IsTrue(registerAccountPage.IsAccountNotCreated());
        }

        [Then(@"Proper warning messages should be displayed")]
        public void ThenProperWarningMessagesShouldBeDisplayed()
        {
            Assert.IsTrue(registerAccountPage.AreAllWarningMessagesDisplayed());

        }

    }
}
