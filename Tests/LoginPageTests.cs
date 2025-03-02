using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using CSharpSeleniumFramework.Pages;
using CSharpSeleniumFramework.Utils;

namespace CSharpSeleniumFramework.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class LoginPageTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureFeature("Navigation")]
        [AllureStory("Open the LoginPage successfully")]
        public void NavigateToLoginPage()
        {
            _homePage.Visit();
            _homePage.NavigateToLoginPage();
            _loginPage.CheckLoginHeader();
        }

        [Test]
        [AllureFeature("Login")]
        [AllureStory("Log in to the application successfully")]
        public void LoginSuccessful()
        {

            string username = "username";
            string password = "password";

            _homePage.Visit();
            _homePage.NavigateToLoginPage();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
            _loginPage.CheckUsername(username);
        }


        [Test]
        [AllureFeature("Login")]
        [AllureStory("Log in unsuccessful")]
        public void LoginUnsuccessful()
        {

            string username = "john";
            string password = "password123";

            _homePage.Visit();
            _homePage.NavigateToLoginPage();
            _loginPage.Login(username, password);
            bool loginErrorDisplayed = _loginPage.LoginErrorDisplayed();
            Assert.That(loginErrorDisplayed, "Login error message should be displayed, but it was not.");
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Call the utility method to capture the screenshot
                TestUtils.CaptureScreenshot(_driver);
            }
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

