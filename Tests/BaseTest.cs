using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using CSharpSeleniumFramework.Pages;
using CSharpSeleniumFramework.Utils;

namespace CSharpSeleniumFramework.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        protected BasePage _basePage;
        protected HomePage _homePage;
        protected LoginPage _loginPage;
        protected OnlineBankingPage _onlineBankingPage;
        protected TransferFundsPage _transferFundsPage;
        protected AccountActivityPage _accountActivityPage;
        protected PayBillsPage _payBillsPage;
        protected AccountSummaryPage _accountSummaryPage;

        [SetUp]
        public virtual void Setup()
        {
            _driver = WebDriverFactory.CreateDriver(browser: "chrome", headless: true);
            InitPages();
            _basePage.VisitSite();
        }

        private void InitPages()
        {
            _basePage = new BasePage(_driver);
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _onlineBankingPage = new OnlineBankingPage(_driver);
            _transferFundsPage = new TransferFundsPage(_driver);
            _accountActivityPage = new AccountActivityPage(_driver);
            _payBillsPage = new PayBillsPage(_driver);
            _accountSummaryPage = new AccountSummaryPage(_driver);
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Call the utility method to capture the screenshot
                TestUtils.CaptureScreenshot(_driver);
            }
            _driver.Quit();
            _driver.Dispose();
        }

        [SetUpFixture]
        public class TestSetup
        {
            [OneTimeSetUp]
            public void GlobalSetup()

            {
                // Get the project root directory (this should be the directory that contains your .csproj file)
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

                // Define the allure-results path directly in the project root directory
                string allureResultsPath = Path.Combine(projectRoot, "allure-results");

                // Ensure allure-results directory exists in the project root directory
                Directory.CreateDirectory(allureResultsPath);

                // Explicitly set the environment variable for Allure results directory to the correct path
                Environment.SetEnvironmentVariable("ALLURE_RESULTS_DIRECTORY", allureResultsPath);

                // Optionally, set the working directory to the project root for Allure to resolve paths correctly
                Directory.SetCurrentDirectory(projectRoot);
            }
        }

    }
}
