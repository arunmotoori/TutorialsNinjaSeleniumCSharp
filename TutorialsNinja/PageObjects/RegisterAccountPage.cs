using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsNinja.PageObjects
{
    public class RegisterAccountPage
    {
        public IWebDriver driver;

        private By firstNameField = By.Id("input-firstname");
        private By lastNameField = By.Id("input-lastname");
        private By emailField = By.Id("input-email");
        private By telephoneField = By.Id("input-telephone");
        private By passwordField = By.Id("input-password");
        private By passwordConfirmField = By.Id("input-confirm");
        private By yesNewsletterOption = By.XPath("(//input[@name='newsletter'])[1]");
        private By privacyPolicyField = By.Name("agree");
        private By continueButton = By.CssSelector("input[value='Continue']");
        private By registerAccountPageHeading = By.XPath("//div[@id='content']/h1[text()='Register Account']");
        private By firstNameWarningMessage = By.XPath("//div[text()='First Name must be between 1 and 32 characters!']");
        private By lastNameWarningMessage = By.XPath("//div[text()='Last Name must be between 1 and 32 characters!']");
        private By emailWarningMessage = By.XPath("//div[text()='E-Mail Address does not appear to be valid!']");
        private By telephoneWarningMessage = By.XPath("//div[text()='Telephone must be between 3 and 32 characters!']");
        private By passwordWarningMessage = By.XPath("//div[text()='Password must be between 4 and 20 characters!']");


        public RegisterAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterFirstName(string firstNameText)
        {
            driver.FindElement(firstNameField).SendKeys(firstNameText);
        }

        public void EnterLastName(string lastNameText)
        {
            driver.FindElement(lastNameField).SendKeys(lastNameText);
        }

        public void EnterEmail(string emailText)
        {
            driver.FindElement(emailField).SendKeys(emailText);

        }

        public void EnterTelephoneNumber(string telephoneText)
        {
            driver.FindElement(telephoneField).SendKeys(telephoneText);
        }

        public void EnterPassword(string passwordText)
        {
            driver.FindElement(passwordField).SendKeys(passwordText);
        }

        public void EnterPasswordConfirm(string passwordText)
        {
            driver.FindElement(passwordConfirmField).SendKeys(passwordText);
        }

        public void SelectYesNewsletterOption()
        {
            driver.FindElement(yesNewsletterOption).Click();
        }

        public void SelectPrivacyPolicyOption()
        {
            driver.FindElement(privacyPolicyField).Click();
        }

        public AccountSuccessPage ClickOnContinueButton()
        {
            driver.FindElement(continueButton).Click();

            return new AccountSuccessPage(driver);
        }

        public bool IsAccountNotCreated()
        {
            return driver.FindElement(registerAccountPageHeading).Displayed;

        }

        public bool AreAllWarningMessagesDisplayed()
        {

            bool a = driver.FindElement(firstNameWarningMessage).Displayed;
            bool b = driver.FindElement(lastNameWarningMessage).Displayed;
            bool c = driver.FindElement(emailWarningMessage).Displayed; 
            bool d = driver.FindElement(telephoneWarningMessage).Displayed; 
            bool e = driver.FindElement(passwordWarningMessage).Displayed;

            if (a && b && c && d && e)
                return true;
            else
                return false;

        }

    }
}
