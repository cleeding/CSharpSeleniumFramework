using Allure.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V131.CSS;
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
        [AllureStep("Visiting the site")]
        public void VisitSite()
        {
            _driver.Navigate().GoToUrl(_applicationURL);
        }

        [AllureStep("Clicking on element")]
        public void ClickElement(By selector)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            _driver.FindElement(selector).Click();
        }
        
        [AllureStep("Sending text to the element")]  
        public void SendText(By selector, bool clearText, string text)
        {
            var element = _driver.FindElement(selector);
            element.Click();
            if (clearText)
            {
                element.Clear();
            }
            element.SendKeys(text);
        }

        [AllureStep("Getting the page title")]
        public string GetPageTitle()
        {
            return _driver.Title;
        }

        [AllureStep("Checking the page title matches the expected string")]
        public void CheckPageTitle(string expectedPageTitle)
        {
            var actualPageTitle = GetPageTitle();
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle), $"Expected title: {expectedPageTitle}, but got: {actualPageTitle}");
        }

    }
}