using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Input;
using OpenQA.Selenium.Support.UI;

namespace CSharpSeleniumFramework.Pages

{
    public class PayBillsPage : BasePage
    {
        // Selectors
        private By _payButton = By.Id("pay_saved_payees");
        private By _payeeField = By.Id("sp_payee");
        private By _accountField = By.Id("sp_account");
        private By _amountfield = By.Id("sp_amount");
        private By _dateField = By.Id("sp_date");
        private By _descriptionField = By.Id("sp_description");
        private By _alertTitleLocator = By.CssSelector("#alert_content span");

        // Constructor
        public PayBillsPage(IWebDriver driver) : base(driver) { }

        // Methods
        public void ClickPayButton()
        {
            ClickElement(_payButton);
        }

        public void SelectPayee(string payee)
        {
            // Explicit wait to check if the element is visible
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_payeeField));

            new SelectElement(_driver.FindElement(_payeeField)).SelectByValue(payee);
        }

        public void SelectAccount(string account)
        {
            new SelectElement(_driver.FindElement(_accountField)).SelectByValue(account);
        }

        public void EnterAmount(string amount)
        {
            SendText(_amountfield, true, amount);
        }

        public void EnterDate(string date)
        {
            SendText(_dateField, true, date);
            _driver.FindElement(_dateField).SendKeys(Keys.Return);
        }

        public void EnterDescription(string description)
        {
            SendText(_descriptionField, true, description);
        }

        public void CheckAlertTitleMatchesExpectedAmount(string amount)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement alertSpan = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_alertTitleLocator));
            string alertTitleText = alertSpan.GetAttribute("title");
            Assert.That(alertTitleText, Is.EqualTo($"$ {amount} payed to payee apple"), "The alert message did not match the expected string amount");
        }
    }
}