using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using CSharpSeleniumFramework.Pages;
using CSharpSeleniumFramework.Utils;

namespace CSharpSeleniumFramework.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class AccountSummaryTest : BaseTest
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
            _homePage.ClickCheckingAccountActivityLink();
            _accountActivityPage.ClickAccountSummaryLink();
        }

        [Test]
        [AllureFeature("Account Summary")]
        [AllureStory("Check all sections displayed on the page")]
        public void CheckSectionsDisplayed()
        {

            _accountSummaryPage.VerifyAllSectionHeadersDisplayed();
        }

        [Test]
        [AllureFeature("Account Summary")]
        [AllureStory("Check all table headers are displayed on the page")]
        public void CheckSectionTableHeaders()
        {
            var expectedValues = new (int board, int column, string expectedText)[]
            {
                (1, 1, "Account"),
                (1, 3, "Balance"),
                (2, 1, "Account"),
                (2, 3, "Balance"),
                (3, 1, "Account"),
                (3, 2, "Credit Card"),
                (3, 3, "Balance"),
                (4, 1, "Account"),
                (4, 3, "Balance")
                        };

            foreach (var (board, column, expectedText) in expectedValues)
            {
                var actualText = _accountSummaryPage.GetThXPath(_driver, board, column);
                Assert.That(actualText, Is.EqualTo(expectedText),
                    $"Failed on board {board}, column {column}");
            }
        }

        [Test]
        [AllureFeature("Account Summary")]
        [AllureStory("Check all table data matches expected")]
        public void CheckSectionTableData()
        {
            var expectedValues = new (int board, int column, string expectedText)[]
            {
                (1, 1, "Savings"),
                (1, 3, "$1000.9")
                        };

            foreach (var (board, column, expectedText) in expectedValues)
            {
                var actualText = _accountSummaryPage.GetTdXpath(_driver, board, column);
                Assert.That(actualText, Is.EqualTo(expectedText),
                    $"Failed on board {board}, column {column}");
            }
        }
    }
}
