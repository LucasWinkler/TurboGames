using GameStore.AutomatedUITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;

namespace GameStore.AutomatedUITests.Tests
{
    public sealed class LoginTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginpage;

        public LoginTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _loginpage = new LoginPage(_driver, "Login");
            _loginpage.Navigate();
        }

        [Fact]
        public void Login_CorrectUser_ReturnsHomePageWithRegisteredUserMenu()
        {
            _loginpage.PopulateUserName("TurboUser");
            _loginpage.PopulatePassword("Turbo123!");
            _loginpage.ClickLogin();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _loginpage.FindRegisteredUserMenu();

            Assert.Equal("Home", _driver.Title);
            Assert.Contains("Welcome back,", _loginpage.Source);
            Assert.Contains("TurboUser", _loginpage.Source);
        }

        [Fact]
        public void Login_WhenWrongPassword_ReturnsLoginPage()
        {
            _loginpage.PopulateUserName("TurboUser");
            _loginpage.PopulatePassword("Turbo123");
            _loginpage.ClickLogin();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _loginpage.FindRegisteredUserMenu();

            Assert.Equal("Please sign in", _loginpage.Title);
            // Could also assert.contains for the error message in the source
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}