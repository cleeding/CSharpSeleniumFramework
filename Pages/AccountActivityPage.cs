using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.Pages
{

    public class AccountActivityPage : BasePage
    {
        // Selectors
        public string _pageTitle = "Zero - Account Activity";
        private By _findTransactionsTab = By.CssSelector("a[href='#ui-tabs-2']");
        private By _findButton = By.CssSelector(".btn.btn-primary");
        private By _dateColumn = By.CssSelector("#filtered_transactions_for_account table tr:nth-child(1) td:nth-child(1)");
        private By _descriptionColumn = By.CssSelector("#filtered_transactions_for_account table tr:nth-child(1) td:nth-child(2)");
        private By _depositColumn = By.CssSelector("#filtered_transactions_for_account table tr:nth-child(1) td:nth-child(3)");
        private By _withdrawalColumn = By.CssSelector("#filtered_transactions_for_account table tr:nth-child(1) td:nth-child(4)");
        private By _h2Header = By.ClassName("board-header");

        // Constructor
        public AccountActivityPage(IWebDriver driver) : base(driver) { }

        // Methods
        public void ClickFindTransactionsTab()
        {
            ClickElement(_findTransactionsTab);
        }

        public void ClickFindButton()
        {
            ClickElement(_findButton);
        }

        public void CheckTransactionRowData(string date, string description, string deposit, string wtihdrawal)
        {
            // Explicit wait to check if the element is visible
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dateColumn));

            var dateElement = _driver.FindElement(_dateColumn);
            var descriptionElement = _driver.FindElement(_descriptionColumn);
            var depositColumn = _driver.FindElement(_depositColumn);
            var withdrawlColumn = _driver.FindElement(_withdrawalColumn);

            // Assert values
            Assert.That(dateElement.Text, Is.EqualTo(date));
            Assert.That(descriptionElement.Text, Is.EqualTo(description));
            Assert.That(depositColumn.Text, Is.EqualTo(deposit));
            Assert.That(withdrawlColumn.Text, Is.EqualTo(wtihdrawal));
        }
    }
}