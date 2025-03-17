using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.Pages
{
    public class OnlineBankingPage
    {
        // Fields
        private readonly string _pageHeader = "Online Banking";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Selectors
        private By _h1Header = By.TagName("h1");

        // Constructor
        public OnlineBankingPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Methods
        public void CheckOnlineBankingPageHeader()
        {
            string h1Header = _driver.FindElement(_h1Header).Text;
            Assert.That(h1Header, Is.EqualTo(_pageHeader), "The page header text does not match");
        }
    }
}
