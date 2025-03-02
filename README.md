
# Lightweight C# Selenium & NUnit Framework 

This framework leverages C#, Selenium, NUnit, POM, Allure reporting, and automatic screenshot capture for efficient and comprehensive testing.

## Prerequisites

Before running the tests and generating reports, make sure you have the following installed:

- .NET SDK (8.0 or higher)
- Selenium WebDriver
- Allure Commandline
- NUnit Console (optional, if you prefer to run tests through NUnit)


## Run Locally

1. Clone the repository to your local machine

2. Building the Project

Make sure the required dependencies are installed. Run the following command to restore NuGet packages:

```bash
  dotnet restore
  dotnet build
```

3. Running Tests

You can run the tests with the following command:
```bash
  dotnet test
```

4. Generating Allure Report

To generate an Allure report, run the following steps:

Run the tests with the following command to specify the logger for Allure:
```bash
  dotnet test --logger "nunit;LogFilePath=allure-results/results.xml"
```
After running the tests, generate the Allure report:
```bash
  allure generate --clean
```
To serve the report locally:
```bash
  allure serve allure-results
```
This will start a local server and open the Allure report in your browser.

5. Screenshots for failing tests will be saved in a 'screenshots' folder at the project root directory

## Roadmap

- Increase POM coverage

- Improved Folder Structure

- Increase Modular Setup (reduce duplciated code)

- Logging

- Test Data Management

- Cross Browser Support

