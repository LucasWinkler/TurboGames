using GameStore.AutomatedUITests.Helpers;
using GameStore.AutomatedUITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameStore.AutomatedUITests.Tests
{
    public sealed class ReportTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly ReportPage _page;
        private readonly LoginHelper _loginHelper;

        public ReportTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new ReportPage(_driver, "Admin/Reports");
            _loginHelper = new LoginHelper(_driver);

            _page.Navigate();
        }

        [Fact]
        public void Report_WhenClickGameReport_ShowGameReport()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginAdmin();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _page.ClickGames();

            Assert.Equal("Game Report", _page.Title);

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
