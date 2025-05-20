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

        public string GetThXPath(IWebDriver driver, int boardIndex, int thIndex)
        {
            string xpath =  $"(//div[@class='board-content'])[{boardIndex}]//table//th[{thIndex}]";
            return xpath = driver.FindElement(By.XPath(xpath)).Text;
        }

        public string GetTdXpath(IWebDriver driver, int boardIndex, int tdIndex){
            string xpath = $"(//div[@class='board-content'])[{boardIndex}]//table//td[{tdIndex}]";
            return xpath = driver.FindElement(By.XPath(xpath)).Text;
        }
    }
}
