using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.Pages
{
    public class OnlineBankingPage : BasePage
    {
        // Fields
        private readonly string _pageHeader = "Online Banking";

        // Selectors
        private By _h1Header = By.TagName("h1");
        private By _payBillsLink = By.Id("pay_bills_link");

        // Constructor
        public OnlineBankingPage(IWebDriver driver) : base(driver) { }

        // Methods
        public void ClickPayBillsLink()
        {
            ClickElement(_payBillsLink);
        }
        public void CheckOnlineBankingPageHeader()
        {
            string h1Header = _driver.FindElement(_h1Header).Text;
            Assert.That(h1Header, Is.EqualTo(_pageHeader), "The page header text does not match");
        }
    }
}
