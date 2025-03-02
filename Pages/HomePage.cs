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

        public void NavigateToLoginPage(){
            _driver.FindElement(_signInButton).Click();
        }
    }
}