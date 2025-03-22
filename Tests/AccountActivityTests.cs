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
    public class AccountActivityTests : BaseTest
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            // Login
            string username = "username";
            string password = "password";
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
        }


        [Test]
        [AllureFeature("Account Activity")]
        [AllureStory("Check Account Activity page title matches expected string")]
        public void CheckAccountActivityPageTitle()
        {
            _homePage.ClickCheckingAccountActivityLink();
            _accountActivityPage.CheckPageTitle(_accountActivityPage._pageTitle);
        }

        [Test]
        [AllureFeature("Find Transactions")]
        [AllureStory("Find Transactions using a blank search")]
        public void FindTransactionsBlankSearch()
        {
            string date = "2012-09-06";
            string description = "ONLINE TRANSFER REF #UKKSDRQG6L";
            string deposit = "984.3";
            string withdrawal = "";

            _homePage.ClickCheckingAccountActivityLink();
            _accountActivityPage.ClickFindTransactionsTab();
            _accountActivityPage.ClickFindButton();
            _accountActivityPage.CheckTransactionRowData(date, description, deposit, withdrawal);
        }
    }
}
