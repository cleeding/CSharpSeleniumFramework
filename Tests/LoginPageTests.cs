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
    public class LoginPageTests : BaseTest
    {
        [Test]
        [AllureFeature("Navigation")]
        [AllureStory("Open the LoginPage successfully")]
        public void NavigateToLoginPage()
        {
            _basePage.VisitSite();
            _homePage.ClickSignInButton();
            _loginPage.CheckLoginHeader();
        }

        [Test]
        [AllureFeature("Login")]
        [AllureStory("Log in to the application successfully")]
        public void LoginSuccessful()
        {

            string username = "username";
            string password = "password";

            _basePage.VisitSite();
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
            _loginPage.CheckUsername(username);
        }

        [TestCase("john", "password123")]
        [TestCase("john", "")]
        [TestCase("", "password123")]
        [TestCase("", "")]
        [Test]
        [AllureFeature("Login")]
        [AllureStory("Log in unsuccessful")]
        public void LoginUnsuccessful(string username, string password)
        {
            _basePage.VisitSite();
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            bool loginErrorDisplayed = _loginPage.LoginErrorDisplayed();
            Assert.That(loginErrorDisplayed, "Login error message should be displayed, but it was not.");
        }
    }
}

