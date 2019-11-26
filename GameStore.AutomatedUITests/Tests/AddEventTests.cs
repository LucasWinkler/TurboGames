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
    public sealed class AddEventTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly AddEventPage _page;
        private readonly LoginHelper _loginHelper;
        public AddEventTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new AddEventPage(_driver, "Admin/Manage/Events/Create");
            _loginHelper = new LoginHelper(_driver);

            _page.Navigate();
        }

        [Fact]
        public void Events_WhenSuccessfullyExecuted_ReturnsEventOnManageEventsPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginAdmin();

            _page.FindEventTitleElement();

            string title = "Test title";
            string details = "Test details";

            _page.PopulateEventTitle(title);
            _page.PopulateEventDate(DateTime.UtcNow.ToString());
            _page.PopulateEventDetails(details);
            _page.PopulateEventClassification("Web");
            _page.ClickSubmit();

            _page.FindAddEventButton();

            Assert.Equal("Manage Events", _page.Title);
            Assert.Contains(title, _page.Source);
            Assert.Contains(details, _page.Source);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
