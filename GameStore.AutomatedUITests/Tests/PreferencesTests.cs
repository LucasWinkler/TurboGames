using GameStore.AutomatedUITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameStore.AutomatedUITests.Tests
{
    public sealed class PreferencesTests : IDisposable
    {

        private readonly IWebDriver _driver;
        private readonly PreferencesPage _page;

        public PreferencesTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new PreferencesPage(_driver, "Settings/Preferences");
            _page.Navigate();
        }

        [Fact]
        public void Preferences_WhenSuccessfullyExecuted_ReturnsSuccessMessage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _page.PopulateUsername("User");
            _page.PopulatePassword("User123!");
            _page.ClickSignIn();

            _page.FindSaveButton();
            Assert.Equal("Preferences", _page.Title);

            _page.ClickAcceptCookies();
            _page.PopulateSelectPlatform("Steam");
            _page.PopulateSelectCategory("FPS");
            _page.ClickSave();
            _page.FindStatusMessage();

            Assert.Contains("Your preferences has been updated", _page.Source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
