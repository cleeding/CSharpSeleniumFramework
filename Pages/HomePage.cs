using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.Pages
{
    public class HomePage
    {
        // Fields
        private static readonly string _applicationURL = "http://zero.webappsecurity.com/";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Selectors
        private By _homePageNavBar = By.ClassName("navbar-inner");
        private By _signInButton = By.Id("signin_button");
        private By _onlineBankingLink = By.Id("onlineBankingMenu");
        private By _transferFundsLink = By.Id("transfer_funds_link");

        // Constructor
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Methods
        public void Visit()
        {
            _driver.Navigate().GoToUrl(_applicationURL);
        }

        public bool IsHomePageDisplayed()
        {
            return _driver.FindElement(_homePageNavBar).Displayed;
        }

        public void ClickSignInButton(){
            _driver.FindElement(_signInButton).Click();
        }

        public void ClickOnlineBankingLink(){
            _driver.FindElement(_onlineBankingLink).Click();
        }

        public void ClickTransferFundLink(){
            _driver.FindElement(_transferFundsLink).Click();
        }
    }
}