using NUnit.Framework;
using OpenQA.Selenium;

namespace CSharpSeleniumFramework.Pages
{

    public class AccountSummaryPage : BasePage
    {

        public AccountSummaryPage(IWebDriver driver) : base(driver) { }

        public void VerifyAllSectionHeadersDisplayed()
        {
            var sections = new List<String> { "Cash Accounts", "Investment Accounts", "Credit Accounts", "Loan Accounts" };
            foreach (var section in sections)
            {
                IWebElement element = _driver.FindElement(By.XPath($"//h2[text()='{section}']"));
                Assert.That(element.Displayed);
            }
        }
    }
}
