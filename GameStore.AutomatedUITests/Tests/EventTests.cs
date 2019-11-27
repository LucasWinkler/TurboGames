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
    public sealed class EventTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly AddEventPage _addPage;
        private readonly DeleteEventPage _deletePage;
        private readonly LoginHelper _loginHelper;
        public EventTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _addPage = new AddEventPage(_driver, "Admin/Manage/Events/Create");
            _deletePage = new DeleteEventPage(_driver, "Admin/Manage/Events");
            _loginHelper = new LoginHelper(_driver);


        }

        [Fact]
        public void Events_WhenSuccessfullyExecuted_ReturnsEventOnManageEventsPage()
        {
            _addPage.Navigate();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginAdmin();

            _addPage.FindEventTitleElement();

            string title = "Test title";
            string details = "Test details";

            _addPage.PopulateEventTitle(title);
            _addPage.PopulateEventDate(DateTime.UtcNow.ToString());
            _addPage.PopulateEventDetails(details);
            _addPage.PopulateEventClassification("Web");
            _addPage.ClickSubmit();

            _addPage.FindAddEventButton();

            Assert.Equal("Manage Events", _addPage.Title);
            Assert.Contains(title, _addPage.Source);
            Assert.Contains(details, _addPage.Source);
        }

        [Fact]
        public void Events_WhenSuccessfullyExecuted_ReturnsEventGoneFromManageEventsPage()
        {
            //Adding the event to be deleted
            _addPage.Navigate();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginAdmin();

            _addPage.FindEventTitleElement();

            string title = "Testtitle2";
            string details = "Testdetails2";

            _addPage.PopulateEventTitle(title);
            _addPage.PopulateEventDate(DateTime.UtcNow.ToString());
            _addPage.PopulateEventDetails(details);
            _addPage.PopulateEventClassification("Web");
            _addPage.ClickSubmit();

            _addPage.FindAddEventButton();

            //Deleting 
            _deletePage.Navigate();

            _deletePage.FindDeleteEventButton(title);
            _deletePage.ClickDelete(title);
            _deletePage.FindDeleteEventButtonActual();
            _deletePage.ClickDeleteEventButton();

            _driver.FindElement(By.Id("add-event-button"));
           

            Assert.Equal("Manage Events", _driver.Title);
            Assert.DoesNotContain(title, _driver.PageSource);


        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
