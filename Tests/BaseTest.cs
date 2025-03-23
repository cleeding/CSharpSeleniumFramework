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

        [SetUp]
        public virtual void Setup()
        {
            var options = new ChromeOptions();
            
            // Common Chrome options for both local and CI environments
            options.AddArguments("headless", "disable-gpu", "window-size=1280x1024", "no-sandbox");

            // Conditionally add user data dir for CI environment (GitHub Actions)
            if (Environment.GetEnvironmentVariable("GITHUB_ACTIONS") != null)
            {
                options.AddArguments($"--user-data-dir=/tmp/chrome-{Guid.NewGuid()}"); // Unique directory for CI
            }
            
            _driver = new ChromeDriver();
            _basePage = new BasePage(_driver);
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _onlineBankingPage = new OnlineBankingPage(_driver);
            _transferFundsPage = new TransferFundsPage(_driver);
            _accountActivityPage = new AccountActivityPage(_driver);
            _driver.Manage().Window.Maximize();

            //Visit the application
            _basePage.VisitSite();
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
