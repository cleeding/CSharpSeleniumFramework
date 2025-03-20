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
    }
}
