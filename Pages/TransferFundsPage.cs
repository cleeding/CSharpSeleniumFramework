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
        private By _fromAccountDD = By.Id("c");
        private By _fromAccountDDVSavingsAcc = By.CssSelector("#tf_fromAccountId > option:nth-child(1)");
        private By _toAccountDD = By.Id("tf_toAccountId");
        private By _toAccountDDVBrokerage = By.CssSelector("#tf_toAccountId > option:nth-child(6)");
        private By _amount = By.Id("tf_amount");
        private By _desc = By.Id("tf_description");
        private By _continueButton = By.Id("btn_submit");
        private By _alertSuccessMessage = By.ClassName(".alert.alert-success");

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

        public void SelectFromToAccounts()
        {
            _driver.FindElement(_fromAccountDD).Click();
            _driver.FindElement(_fromAccountDDVSavingsAcc).Click();
            _driver.FindElement(_toAccountDDVBrokerage).Click();
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


        public void CheckVerfiyDetails(String fromAccountType, string toAccountType)
        {
            IWebElement inputElementFrom = _driver.FindElement(_fromAccountDD);
            string fromAccount = inputElementFrom.GetAttribute("value");
            IWebElement inputElementTo = _driver.FindElement(_toAccountDD);
            string toAccount = inputElementTo.GetAttribute("value");
            Assert.That(fromAccount, Is.EqualTo(fromAccountType), "The account type does not match");
            Assert.That(toAccount, Is.EqualTo(toAccountType), "The account type does not match");
        }

        public void CheckSuccessMessageIsDisplayed()
        {
            var alertSuccess = _driver.FindElement(_alertSuccessMessage);
            Assert.Equals(alertSuccess.Displayed, " Alert message is not displayed.");
        }
    }
}