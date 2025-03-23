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
    public class TransferFundsPageTests : BaseTest
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
        [AllureFeature("Transfer Funds")]
        [AllureStory("Transfer funds from Savings account to Brokerage account")]
        [AllureTag("Regression", "Banking")]
        public void TransferBetweenAccountsSuccessful()
        {
            string fromAccountTypeValue = "1";
            string toAccountTypeValue = "6";
            string amount = "40.00";
            string desc = "Savings Withdrawal for Investment in Brokerage Account";
            string fromAccountTypeText = "Savings";
            string toAccountTypeText = "Brokerage";

            _homePage.ClickTransferFundLink();
            _transferFundsPage.SelectFromAccount(fromAccountTypeValue);
            _transferFundsPage.SelectToAccount(toAccountTypeValue);
            _transferFundsPage.EnterAmountAndDesc(amount, desc);
            _transferFundsPage.ClickContinue();
            _transferFundsPage.CheckFromAccount(fromAccountTypeText);
            _transferFundsPage.CheckToAccount(toAccountTypeText);
            _transferFundsPage.ClickContinue();
            _transferFundsPage.CheckSuccessMessageIsDisplayed();
        }

        [Test]
        [AllureFeature("Transfer Funds")]
        [AllureStory("Attempt to tranfer funds without amount populated")]
        [AllureTag("Regression", "Banking")]
        public void TranferBetweenAccountsBlankAmount()
        {
            string desc = "Savings Withdrawal for Investment in Brokerage Account";
            string fromAccountTypeValue = "1";
            string toAccountTypeValue = "6";

            _homePage.ClickTransferFundLink();
            _transferFundsPage.SelectFromAccount(fromAccountTypeValue);
            _transferFundsPage.SelectToAccount(toAccountTypeValue);
            _transferFundsPage.EnterDesc(desc);
            _transferFundsPage.ClickContinue();
            _transferFundsPage.CheckAmountCannotBeBlank();
        }
    }
}

