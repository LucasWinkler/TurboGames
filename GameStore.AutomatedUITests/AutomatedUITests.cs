using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace GameStore.AutomatedUITests
{
    public sealed class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public AutomatedUITests()
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
            _baseUrl = "https://localhost:44378";
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate()
                .GoToUrl($"{_baseUrl}/Register");

            Assert.Equal("Create Account", _driver.Title);
            Assert.Contains("Get started with your free account", _driver.PageSource);
        }

        [Fact]
        public void Create_WrongModelData_ReturnsErrorMessage()
        {
            _driver.Navigate()
                .GoToUrl($"{_baseUrl}/Register");

            _driver.FindElement(By.Id("Input_UserName"))
                .SendKeys("TurboUser");

            _driver.FindElement(By.Id("Input_Email"))
                .SendKeys("turboemail.com");

            _driver.FindElement(By.Id("btnSubmit"))
                .Click();

            var errorMessage = _driver.FindElement(By.Id("Input_Email-error")).Text;

            Assert.Equal("Please enter a valid email address.", errorMessage);
        }

        [Fact]
        public void Create_WhenSuccessfullyExecuted_ReturnsIndexViewWithNewEmployee()
        {
            _driver.Navigate()
                .GoToUrl($"{_baseUrl}/Register");

            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.FindElement(By.Id("Input_UserName"))
                .SendKeys("TurboUser");

            _driver.FindElement(By.Id("Input_FirstName"))
                .SendKeys("Turbo");

            _driver.FindElement(By.Id("Input_LastName"))
                .SendKeys("User");

            _driver.FindElement(By.Id("Input_Email"))
                .SendKeys("turbouser@myemail.com");

            _driver.FindElement(By.Id("Input_Gender"))
                .SendKeys("Male");

            _driver.FindElement(By.Id("Input_DOB"))
                .SendKeys("06/04/1999");

            _driver.FindElement(By.Id("Input_Password"))
                .SendKeys("Turbo123!");

            _driver.FindElement(By.Id("Input_ConfirmPassword"))
                .SendKeys("Turbo123!");

            _driver.FindElement(By.Id("btnSubmit"))
                .Click();

            _driver.FindElement(By.Id("dropdownMenuButton"));

            Assert.Equal("Home", _driver.Title);
            Assert.Contains("Welcome back, ", _driver.PageSource);
        }
    }
}
