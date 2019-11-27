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

            // Tells the chrome driver to wait for x amount of seconds 
            // when it can not find a specific element.
            // This is to give the server time to validate the form and load the next page.
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            Assert.Equal("Home", _driver.Title);
            // Confirms that the page contains the welcome back message and the new users username from the registered user dropdown
            Assert.Contains("Welcome back,", _loginpage.Source);
            Assert.Contains("TurboUser", _loginpage.Source);
        }

        [Fact]
        public void Login_WhenWrongPassword_ReturnsLoginPage()
        {
            _loginpage.PopulateUserName("TurboUser");
            _loginpage.PopulatePassword("Turbo123");
            _loginpage.ClickLogin();

            // Tells the chrome driver to wait for x amount of seconds 
            // when it can not find a specific element.
            // This is to give the server time to validate the form and load the next page.
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            // Confirms that the home page has loaded after clicking create which means it was successful
            Assert.Equal("Please sign in", _loginpage.Title);

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}