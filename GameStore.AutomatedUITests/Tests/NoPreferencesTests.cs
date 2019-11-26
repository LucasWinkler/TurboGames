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
    public sealed class NoPreferencesTests
    {
        private readonly IWebDriver _driver;
        private readonly PreferencesPage _page;
        private readonly LoginHelper _loginHelper;

        public NoPreferencesTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new PreferencesPage(_driver, "Settings/Preferences");
            _loginHelper = new LoginHelper(_driver);

            _page.Navigate();
        }

        [Fact]
        public void Preferences_WhenSuccessfullyExecuted_ReturnsSuccessMessage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginAdmin();

            // Make sure we find the preferences save button
            _page.FindSaveButton();

            // Accept cookies so the status message will appear
            _page.ClickAcceptCookies();

            // Populate the elements and submit form
            _page.PopulateSelectPlatform("Select platform");
            _page.PopulateSelectCategory("Select category");
            _page.ClickSave();

            // Checks to see if the status message exists
            _page.FindStatusMessage();

            // Make sure we're on the preferences page and check the source for the StatusMessage text
            Assert.Equal("Preferences", _page.Title);
            Assert.Contains("Your preferences has been updated", _page.Source);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
