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
        private By _transferFundsLink = By.Id("transfer_funds_link");

        // Constructor
        public HomePage(IWebDriver driver) : base(driver){}

        // Methods
        public bool IsHomePageDisplayed()
        {
            return _driver.FindElement(_homePageNavBar).Displayed;
        }

        public void ClickSignInButton()
        {
            _driver.FindElement(_signInButton).Click();
        }

        public void ClickOnlineBankingLink()
        {
            _driver.FindElement(_onlineBankingLink).Click();
        }

        public void ClickTransferFundLink()
        {
            _driver.FindElement(_transferFundsLink).Click();
        }
    }
}