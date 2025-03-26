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
    public class AccountSummaryTest : BaseTest
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
        [AllureFeature("Account Summary")]
        [AllureStory("Check all sections displayed on the page")]
        public void CheckSectionsDisplayed()
        {
            _accountActivityPage.ClickAccountSummaryLink();
            _accountSummaryPage.VerifyAllSectionHeadersDisplayed();
        }
    }
}
