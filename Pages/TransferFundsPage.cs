using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.Pages
{
    public class TransferFundsPage
    {
        // Fields
        private readonly string _pageHeader = "Transfer Money & Make Payments";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Selectors
        private By _h2Header = By.TagName("h2");
        private By _fromAccountDD = By.Id("tf_fromAccountId");
        //private By _fromAccountDDVSavingsAcc = By.CssSelector("#tf_fromAccountId > option:nth-child(1)");
        private By _toAccountDD = By.Id("tf_toAccountId");
        //private By _toAccountDDVBrokerage = By.CssSelector("#tf_toAccountId > option:nth-child(6)");
        private By _amount = By.Id("tf_amount");
        private By _desc = By.Id("tf_description");
        private By _continueButton = By.Id("btn_submit");
        private By _alertSuccessMessage = By.CssSelector(".alert.alert-success");

        // Constructor
        public TransferFundsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Methods
        public void CheckTransferFundsPageHeader()
        {
            string h2Header = _driver.FindElement(_h2Header).Text;
            Assert.That(h2Header, Is.EqualTo(_pageHeader), "The page header text does not match");
        }

        public void SelectFromAccount(string fromAccountType)
        {
            new SelectElement(_driver.FindElement(_fromAccountDD)).SelectByValue(fromAccountType);
        }

        public void SelectToAccount(string toAccountType)
        {
            new SelectElement(_driver.FindElement(_toAccountDD)).SelectByValue(toAccountType);
        }

        public void EnterAmountAndDesc(String amount, String desc)
        {
            _driver.FindElement(_amount).SendKeys(amount);
            _driver.FindElement(_desc).SendKeys(desc);
        }

        public void ClickContinue()
        {
            _driver.FindElement(_continueButton).Click();
        }


        public void CheckVerifyDetails()
        {
            IWebElement inputElementFrom = _wait.Until(ExpectedConditions.ElementIsVisible(_fromAccountDD));
            string actualValue = inputElementFrom.GetAttribute("value");
            Assert.That(actualValue, Is.EqualTo("Savings"), "The account type does not match");

        }

        public void CheckSuccessMessageIsDisplayed()
        {
            Assert.That(_driver.FindElement(_alertSuccessMessage).Displayed, "Alert message is not displayed.");
        }
    }
}