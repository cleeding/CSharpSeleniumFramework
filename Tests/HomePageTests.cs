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
    public class HomePageTests : BaseTest
    {
        [Test]
        [AllureFeature("Navigation")]
        [AllureStory("Open the HomePage successfully")]
        public void NavigateToHomePage()
        {
            _basePage.VisitSite();
            bool isHomePageDisplayed = _homePage.IsHomePageDisplayed();
            Assert.That(isHomePageDisplayed, "HomePage should be displayed, but it was not.");
        }

        [Test]
        [AllureFeature("Logout")]
        [AllureStory("Log out of the application and check Sign In button is displayed")]
        public void Logout_CheckSignInButtonDisplayed()
        {
            String username = "username";
            String password = "password";

            _basePage.VisitSite();
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
            _homePage.ClickLogoutLink();

            bool signInButtonDisplayed = _homePage.CheckSigninButtonDisplayed();
            Assert.That(signInButtonDisplayed, Is.True, "Sign In button was expected but was not found");
        }

        [Test]
        [AllureFeature("Logout")]
        [AllureStory("Log out of the application and check Username section is not displayed")]
        public void Logout_CheckUsernameSectionNotDisplayed()
        {
            String username = "username";
            String password = "password";

            _basePage.VisitSite();
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
            _homePage.ClickLogoutLink();

            bool usernameSectionNotDisplayed = _homePage.CheckUsernameSectionIsNotDisplayed();
            Assert.That(usernameSectionNotDisplayed, Is.True, "Username section was not expected but was found");
        }

    }
}
