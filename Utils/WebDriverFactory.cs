using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace CSharpSeleniumFramework.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string browser = "chrome", bool headless = false)
        {
            IWebDriver driver;

            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();

                    if (headless)
                    {
                        chromeOptions.AddArguments(
                            "--headless=new",
                            "--disable-gpu",
                            "--window-size=1280x1024",
                            "--no-sandbox",
                            "--disable-dev-shm-usage",
                            "--disable-blink-features=AutomationControlled",
                            "--disable-extensions",
                            "--disable-popup-blocking"
                        );
                    }

                    chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);

                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (headless)
                    {
                        firefoxOptions.AddArgument("--headless");
                    }

                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (headless)
                    {
                        edgeOptions.AddArgument("--headless=new");
                    }

                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
