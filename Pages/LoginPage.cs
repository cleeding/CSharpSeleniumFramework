using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.Pages
{
    public class LoginPage : BasePage
    {
        // Fields
        private readonly string _pageHeader = "Log in to ZeroBank";

        // Selectors
        private By _h3Header = By.ClassName("page-header");
        private By _userNameField = By.Id("user_login");
        private By _passwordField = By.Id("user_password");
        private By _signInButton = By.CssSelector(".btn.btn-primary");
        private By _userNameDisplayed = By.XPath("//*[@id='settingsBox']/ul/li[3]/a");
        private By _loginErrorMessage = By.CssSelector(".alert.alert-error");

        // Constructor
        public LoginPage(IWebDriver driver) : base(driver){}

        // Methods
        public void CheckLoginHeader()
        {
            string h3Header = _driver.FindElement(_h3Header).Text;
            Assert.That(h3Header, Is.EqualTo(_pageHeader), "The page header text does not match");
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(_userNameField).SendKeys(username);
            _driver.FindElement(_passwordField).SendKeys(password);
            _driver.FindElement(_signInButton).Click();
        }

        public void ByPassSSLCertIssue()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("neterror")));
            _driver.Navigate().Back();
        }

        public void CheckUsername(string username)
        {
            Assert.That(_driver.FindElement(_userNameDisplayed).Text, Is.EqualTo(username));
        }

        public bool LoginErrorDisplayed(){
            return _driver.FindElement(_loginErrorMessage).Displayed;
        }
    }
}
