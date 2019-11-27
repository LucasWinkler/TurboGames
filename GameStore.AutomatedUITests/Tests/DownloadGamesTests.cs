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
    public sealed class DownloadGamesTests
    {
        private readonly IWebDriver _driver;
        private readonly GameLibraryPage _page;
        private readonly LoginHelper _loginHelper;

        public DownloadGamesTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new GameLibraryPage(_driver, "/Library");
            _loginHelper = new LoginHelper(_driver);

            _page.Navigate();
        }
        [Fact]
        public void Library_WheneverUserHitsDownload_DownloadJson()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginUser();

            // Find's the download button
            _page.FindDownloadButton();

            // Accept cookies so the status message will appear
            _page.ClickAcceptCookies();

            // Clicks the download button
            _page.ClickDownload();

            Assert.Equal("Game Library", _page.Title);
        }
    }
}
