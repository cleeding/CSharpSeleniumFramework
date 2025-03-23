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
            _homePage.ClickCheckingAccountActivityLink();
        }
        
        [Test]
        [AllureFeature("Account Activity")]
        [AllureStory("Check Account Activity page title matches expected string")]
        public void CheckAccountActivityPageTitle()
        {
            _accountActivityPage.CheckPageTitle(_accountActivityPage._pageTitle);
        }

        [Test]
        [AllureFeature("Account Activity")]
        [AllureStory("Check Account Activity page tab panel header is displayed")]
        public void CheckAccountActivityPageTabHeaderDisplayed()
        {
            _accountActivityPage.CheckTabPanelHeaderIsDisplayed();
        }

        [Test]
        [AllureFeature("Find Transactions")]
        [AllureStory("Find Transactions using a blank search")]
        [AllureTag("Regression", "Banking")]
        [Category("Banking")]
        public void FindTransactionsBlankSearch()
        {
            string date = "2012-09-06";
            string description = "ONLINE TRANSFER REF #UKKSDRQG6L";
            string deposit = "984.3";
            string withdrawal = "";

            _accountActivityPage.ClickFindTransactionsTab();
            _accountActivityPage.ClickFindButton();
            _accountActivityPage.CheckTransactionRowData(date, description, deposit, withdrawal);
        }

        [Test]
        [AllureFeature("Find Transactions")]
        [AllureStory("Find Transaction(s) of type Withdrawal")]
        [AllureTag("Regression", "Banking")]
        [Category("Banking")]
        public void FindTransactionsWithdrawalType()
        {
            // Search parameters
            string descriptionField = "OFFICE";
            string fromDateField = "2012-09-01";
            string toDateField = "2012-09-30";
            string fromAmountField = "10";
            string toAmountField = "100";
            string typeField = "Withdrawal";
            
            // Expected data
            string date = "2012-09-05";
            string description = "OFFICE SUPPLY";
            string deposit = "";
            string withdrawal = "50";

            // Perform search
            _accountActivityPage.ClickFindTransactionsTab();
            _accountActivityPage.CompleteFindTransactionSearchParameters(descriptionField, fromDateField, toDateField, fromAmountField, toAmountField, typeField);
            _accountActivityPage.ClickFindButton();
            
            // Verfy results
            _accountActivityPage.CheckTransactionRowData(date, description, deposit, withdrawal);

        }
    }
}
