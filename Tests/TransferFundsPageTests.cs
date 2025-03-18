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
    public class TransferFundsPageTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private LoginPage _loginPage;
        private TransferFundsPage _transferFundsPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _transferFundsPage = new TransferFundsPage(_driver);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureFeature("Transfer Funds")]
        [AllureStory("Transfer funds from Savings account to Brokerage account")]
        public void TransferBetweenAccountsSuccessful()
        {

            string username = "username";
            string password = "password";
            string amount = "40.00";
            string desc = "Savings Withdrawal for Investment in Brokerage Account";
            string fromAccountTypeValue = "1";
            string toAccountTypeValue = "6";
            string fromAccountTypeText = "Savings";
            string toAccountTypeText = "Brokerage";

            _homePage.Visit();
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
            _homePage.ClickTransferFundLink();
            _transferFundsPage.SelectFromAccount(fromAccountTypeValue);
            _transferFundsPage.SelectToAccount(toAccountTypeValue);
            _transferFundsPage.EnterAmountAndDesc(amount, desc);
            _transferFundsPage.ClickContinue();
            _transferFundsPage.CheckVerifyDetails();
            _transferFundsPage.ClickContinue();
            _transferFundsPage.CheckSuccessMessageIsDisplayed();
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

