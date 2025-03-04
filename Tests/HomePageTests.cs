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
    public class HomePageTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureFeature("Navigation")]
        [AllureStory("Open the HomePage successfully")]
        public void NavigateToHomePage()
        {
            _homePage.Visit();
            bool isHomePageDisplayed = _homePage.IsHomePageDisplayed();
            Assert.That(isHomePageDisplayed, "HomePage should be displayed, but it was not.");
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
