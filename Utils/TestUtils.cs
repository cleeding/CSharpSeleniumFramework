using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.IO;

namespace CSharpSeleniumFramework.Utils
{
    public static class TestUtils
    {
        // This method captures a screenshot for a failing test and saves it in the "Screenshots" folder
        public static void CaptureScreenshot(IWebDriver driver)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            // Get the project root directory (two levels up from bin/Debug)
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

            // Define the path to the screenshots folder in the project root
            string screenshotsPath = Path.Combine(projectRoot, "Screenshots");

            // Ensure the screenshots directory exists in the project root directory
            Directory.CreateDirectory(screenshotsPath);

            // Get the current timestamp for unique file names
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            // Define the screenshot file path
            string screenshotPath = Path.Combine(screenshotsPath, $"{TestContext.CurrentContext.Test.Name}_{timestamp}.png");

            // Save the screenshot as a PNG file in the screenshots directory
            screenshot.SaveAsFile(screenshotPath);

            // Attach the screenshot to Allure report
            TestContext.AddTestAttachment(screenshotPath);
        }
    }
}
