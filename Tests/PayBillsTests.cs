using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;

namespace CSharpSeleniumFramework.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class PayBillsTest : BaseTest
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            // Login
            string username = "username";
            string password = "password";
            _homePage.ClickSignInButton();
            _loginPage.Login(username, password);
            _loginPage.ByPassSSLCertIssue();
        }

        [Test]
        [AllureFeature("Pay Bills")]
        [AllureStory("Verify can make payment to a saved payee")]
        public void PaySavedPayee()
        {
            string payee = "apple";
            string account = "2";
            string amount = "150.00";
            string date = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string description = "Mobile phone services";


            _homePage.ClickOnlineBankingLink();
            _onlineBankingPage.ClickPayBillsLink();
            _payBillsPage.SelectPayee(payee);
            _payBillsPage.SelectAccount(account);
            _payBillsPage.EnterAmount(amount);
            _payBillsPage.EnterDate(date);
            _payBillsPage.EnterDescription(description);
            _payBillsPage.ClickPayButton();
            _payBillsPage.CheckAlertTitleMatchesExpectedAmount(amount);
        }
    }
}