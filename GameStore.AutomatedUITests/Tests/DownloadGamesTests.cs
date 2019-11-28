using GameStore.AutomatedUITests.Helpers;
using GameStore.AutomatedUITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace GameStore.AutomatedUITests.Tests
{
    public sealed class DownloadGamesTests :IDisposable
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

            // Login as a regular user
            _loginHelper.LoginUser();

            // Find's the download button
            _page.FindDownloadButton();

            // Accept cookies so the status message will appear
            _page.ClickAcceptCookies();

            // Clicks the download button
            _page.ClickDownload();

            Assert.Equal("Your games", _page.Title);
        }
        [Fact]
        public void Library_AfterDownload_CheckIfFileExist()
        {
            // Checks if the file exists
            Assert.True(CheckFile("Apex.json"));

        }

        // checks to see if the directory exist first, if the download directory
        // exists then check if the directory contains the file that your downloaded
        public bool CheckFile(string filename)
        {
            string directory = $@"C:\Users\{Environment.UserName}\Downloads\";
            string file = $@"C:\Users\{Environment.UserName}\Downloads\{filename}";

            if (Directory.Exists(directory))
            {
                if (File.Exists(file))
                {
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
