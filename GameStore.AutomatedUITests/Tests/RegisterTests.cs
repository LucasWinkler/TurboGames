using GameStore.AutomatedUITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;

namespace GameStore.AutomatedUITests.Tests
{
    public sealed class RegisterTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly RegisterPage _page;

        public RegisterTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new RegisterPage(_driver, "Register");
            _page.Navigate();
        }

        [Fact]
        public void Register_WhenExecuted_ReturnsRegistrationPage()
        {
            Assert.Equal("Create Account", _page.Title);
            Assert.Contains("Get started with your free account", _page.Source);
        }

        [Fact]
        public void Register_WrongEmailData_ReturnsErrorMessage()
        {
            _page.PopulateUserName("TurboUser");
            _page.PopulateFirstName("Turbo");
            _page.PopulateLastName("User");
            _page.PopulateEmail("turbouser.com");
            _page.PopulateGender("Other");
            _page.PopulateDOB("1999-06-04");
            _page.PopulatePassword("Turbo123!");
            _page.PopulateConfirmPassword("Turbo123!");
            _page.ClickCreate();

            Assert.Equal("Please enter a valid email address.", _page.EmailErrorMessage);
        }

        [Fact]
        public void Register_WhenSuccessfullyExecuted_ReturnsHomePageWithRegisteredUserMenu()
        {
            _page.PopulateUserName("TurboUser");
            _page.PopulateFirstName("Turbo");
            _page.PopulateLastName("User");
            _page.PopulateEmail("turbouser@myemail.com");
            _page.PopulateGender("Other");
            _page.PopulateDOB("1999-06-04");
            _page.PopulatePassword("Turbo123!");
            _page.PopulateConfirmPassword("Turbo123!");
            _page.ClickCreate();

            // Tells the chrome driver to wait for x amount of seconds 
            // when it can not find a specific element.
            // This is to give the server time to validate the form and load the next page.
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Look for the element that a registered user would see (waits to ensure page has loaded)
            _page.FindRegisteredUserMenu();

            // Confirms that the home page has loaded after clicking create which means it was successful
            Assert.Equal("Home", _page.Title);

            // Confirms that the page contains the welcome back message and the new users username from the registered user dropdown
            Assert.Contains("Welcome back,", _page.Source);
            Assert.Contains("TurboUser", _page.Source);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
