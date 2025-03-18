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
    public class OnlineBankingPageTests
    {
        private IWebDriver _driver;
        private BasePage _basePage;
        private HomePage _homePage;
        private LoginPage _loginPage;

        private OnlineBankingPage _onlineBankingPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _basePage = new BasePage(_driver);
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _onlineBankingPage = new OnlineBankingPage(_driver);
            _driver.Manage().Window.Maximize();

            // Login
            string username = "username";
            string password = "password";
            _basePage.VisitSite();
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
        }

        [Test]
        [AllureFeature("Online Banking")]
        [AllureStory("Verify Online Banking page header")]
        public void OnlineBankingPageHeader()
        {
            _homePage.ClickOnlineBankingLink();
            _onlineBankingPage.CheckOnlineBankingPageHeader();
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

