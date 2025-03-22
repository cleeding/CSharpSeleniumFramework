using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSeleniumFramework.Pages
{
    public class BasePage
    {
        protected static readonly string _applicationURL = "http://zero.webappsecurity.com/";
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }
        public void VisitSite()
        {
            _driver.Navigate().GoToUrl(_applicationURL);
        }

        public void ClickElement(By selector)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            _driver.FindElement(selector).Click();

        }

        public string GetPageTitle(){
            return _driver.Title;
        }

        public void CheckPageTitle(string expectedPageTitle){
            var actualPageTitle = GetPageTitle();
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle), $"Expected title: {expectedPageTitle}, but got: {actualPageTitle}");
        }

    }
}