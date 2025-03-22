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
    public class OnlineBankingPageTests : BaseTest
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
        [AllureFeature("Online Banking")]
        [AllureStory("Verify Online Banking page header")]
        public void OnlineBankingPageHeader()
        {
            _homePage.ClickOnlineBankingLink();
            _onlineBankingPage.CheckOnlineBankingPageHeader();
        }
    }
}

