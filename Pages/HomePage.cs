using Allure.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.Pages
{
    public class HomePage : BasePage
    {
        // Selectors
        private By _homePageNavBar = By.ClassName("navbar-inner");
        private By _signInButton = By.Id("signin_button");
        private By _onlineBankingLink = By.Id("onlineBankingMenu");
        private By _checkingAccountActivityLink = By.Id("account_activity_link");
        private By _transferFundsLink = By.Id("transfer_funds_link");
        private By _usernameNavBarSection = By.ClassName("icon-user");
        private By _logoutLink = By.Id("logout_link");
        private By _usernameSection = By.CssSelector(".dropdown:nth-of-type(2)");

        // Constructor
        public HomePage(IWebDriver driver) : base(driver) { }

        // Methods
        [AllureStep("Checking the home page nav bar is displayed by returning true or false")]
        public bool IsHomePageDisplayed()
        {
            return _driver.FindElement(_homePageNavBar).Displayed;
        }

        [AllureStep("Clicking the sign in button")]
        public void ClickSignInButton()
        {
            _driver.FindElement(_signInButton).Click();
        }

        [AllureStep("Clicking the Online Banking link")]
        public void ClickOnlineBankingLink()
        {
            _driver.FindElement(_onlineBankingLink).Click();
        }

        [AllureStep("Clicking the Checking Account Activity link")]
        public void ClickCheckingAccountActivityLink()
        {
            ClickElement(_checkingAccountActivityLink);
        }

        [AllureStep("Clicking the Transfer Fund link")]
        public void ClickTransferFundLink()
        {
            _driver.FindElement(_transferFundsLink).Click();
        }

        [AllureStep("Clicking the Logout link")]
        public void ClickLogoutLink()
        {
            ClickElement(_usernameNavBarSection);
            ClickElement(_logoutLink);
        }

        [AllureStep("Checking the Sign in button is displayed by returning true or false")]
        public bool CheckSigninButtonDisplayed()
        {
            return _driver.FindElement(_signInButton).Displayed;

        }
         [AllureStep("Checking the Username section in the nav bar is not displayed")]
        public bool CheckUsernameSectionIsNotDisplayed()
        {
            var elements = _driver.FindElements(_usernameSection); // Returns a list of matching elements

            // If no elements found, it is not displayed
            if (elements.Count == 0)
            {
                return true;
            }

            // If element exists, check if it's displayed
            return !elements[0].Displayed;
        }

    }

}