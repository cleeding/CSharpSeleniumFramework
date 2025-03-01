using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using System;
using System.IO;

namespace PracticeTests
{
    [TestFixture]
    [AllureNUnit] // 🔥 Required for Allure reporting
    public class DuckDuckGoTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureFeature("Search Feature")]
        [AllureStory("Perform a search on DuckDuckGo")]
        public void DuckDuckGoSearch()
        {
            OpenDuckDuckGo();

            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium C# with Allure");
            searchBox.SendKeys(Keys.Enter);

            Assert.That(driver.Title, Does.Contain("Selenium C#"));
        }

        [Test]
        [AllureFeature("UI Feature")]
        [AllureStory("Verify the presence of the DuckDuckGo search button")]
        public void VerifySearchButtonPresence()
        {
            OpenDuckDuckGo();

            var searchButton = driver.FindElement(By.Id("search_button_homepage"));
            Assert.Equals(searchButton.Displayed, "Search button is not displayed.");
        }

        [Test]
        [AllureFeature("UI Feature")]
        [AllureStory("Verify DuckDuckGo homepage title")]
        public void VerifyHomepageTitle()
        {
            OpenDuckDuckGo();

            Assert.That(driver.Title, Is.EqualTo("DuckDuckGo — Privacy, simplified."));
        }

        [Test]
        [AllureFeature("Navigation Feature")]
        [AllureStory("Verify the Privacy page link")]
        public void VerifyPrivacyPageLink()
        {
            OpenDuckDuckGo();

            var privacyLink = driver.FindElement(By.LinkText("Privacy"));
            privacyLink.Click();

            Assert.That(driver.Title, Does.Contain("Privacy"));
        }

        [Test]
        [AllureFeature("Search Feature")]
        [AllureStory("Search for a non-existent term")]
        public void DuckDuckGoSearchNonExistent()
        {
            OpenDuckDuckGo();

            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("nonexistentterm12345");
            searchBox.SendKeys(Keys.Enter);

            Assert.That(driver.PageSource, Does.Contain("No results for"));
        }

        [AllureStep("Open DuckDuckGo homepage")]
        private void OpenDuckDuckGo()
        {
            driver.Navigate().GoToUrl("https://www.duckduckgo.com");
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                CaptureScreenshot();
            }
            driver.Quit();
            driver.Dispose();
        }

private void CaptureScreenshot()
{
    // Capture the screenshot
    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

    // Get the project root directory (two levels up from bin/Debug)
    string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

    // Define the path to the screenshots folder in the project root
    string screenshotsPath = Path.Combine(projectRoot, "screenshots");

    // Ensure the screenshots directory exists in the project root directory
    Directory.CreateDirectory(screenshotsPath);

    // Get the current timestamp for unique file names (format: yyyy-MM-dd_HH-mm-ss)
    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

    // Define the screenshot file path with the timestamp and test name
    string screenshotPath = Path.Combine(screenshotsPath, $"{TestContext.CurrentContext.Test.Name}_{timestamp}.png");

    // Save the screenshot as a PNG file in the screenshots directory
    screenshot.SaveAsFile(screenshotPath);

    // Attach the screenshot to Allure report
    TestContext.AddTestAttachment(screenshotPath);
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
