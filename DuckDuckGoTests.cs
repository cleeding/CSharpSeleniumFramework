using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using CSharpSeleniumFramework.Utils;

namespace CSharpSeleniumFramework
{
    [TestFixture]
    [AllureNUnit] // Required for Allure reporting
    public class DuckDuckGoTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureFeature("Search Feature")]
        [AllureStory("Perform a search on DuckDuckGo")]
        public void DuckDuckGoSearch()
        {
            OpenDuckDuckGo();

            var searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium C# with Allure");
            searchBox.SendKeys(Keys.Enter);

            Assert.That(_driver.Title, Does.Contain("Selenium C#"));
        }

        [Test]
        [AllureFeature("UI Feature")]
        [AllureStory("Verify the presence of the DuckDuckGo search button")]
        public void VerifySearchButtonPresence()
        {
            OpenDuckDuckGo();

            var searchButton = _driver.FindElement(By.Id("search_button_homepage"));
            Assert.Equals(searchButton.Displayed, "Search button is not displayed.");
        }

        [Test]
        [AllureFeature("UI Feature")]
        [AllureStory("Verify DuckDuckGo homepage title")]
        public void VerifyHomepageTitle()
        {
            OpenDuckDuckGo();

            Assert.That(_driver.Title, Is.EqualTo("DuckDuckGo — Privacy, simplified."));
        }

        [Test]
        [AllureFeature("Navigation Feature")]
        [AllureStory("Verify the Privacy page link")]
        public void VerifyPrivacyPageLink()
        {
            OpenDuckDuckGo();

            var privacyLink = _driver.FindElement(By.LinkText("Privacy"));
            privacyLink.Click();

            Assert.That(_driver.Title, Does.Contain("Privacy"));
        }

        [Test]
        [AllureFeature("Search Feature")]
        [AllureStory("Search for a non-existent term")]
        public void DuckDuckGoSearchNonExistent()
        {
            OpenDuckDuckGo();

            var searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys("nonexistentterm12345");
            searchBox.SendKeys(Keys.Enter);

            Assert.That(_driver.PageSource, Does.Contain("No results for"));
        }

        [AllureStep("Open DuckDuckGo homepage")]
        private void OpenDuckDuckGo()
        {
            _driver.Navigate().GoToUrl("https://www.duckduckgo.com");
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