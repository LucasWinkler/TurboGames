using GameStore.AutomatedUITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            _driver = new ChromeDriver(Environment.CurrentDirectory);
            _page = new RegisterPage(_driver);
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
            _page.PopulateDOB("06/04/1999");
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
            _page.PopulateDOB("06/04/1999");
            _page.PopulatePassword("Turbo123!");
            _page.PopulateConfirmPassword("Turbo123!");
            _page.ClickCreate();

            // Tells the chrome driver to wait for x amount of seconds 
            // when it can not find a specific element.
            // This is to give the server time to validate the form and load the next page.
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Look for the element that a registered user would see (waits to ensure page has loaded)
            _page.FindRegisteredUserMenu();

            // Confirm that the next page has loaded and that the test was successful.
            Assert.Equal("Home", _page.Title);
            Assert.Contains("Welcome back, <span class=\"font-weight-bold\">TurboUser</span>!", _page.Source);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
