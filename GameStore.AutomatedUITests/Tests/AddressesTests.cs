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
    public sealed class AddressesTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly AddressPage _page;
        private readonly LoginHelper _loginHelper;

        public AddressesTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new AddressPage(_driver, "Settings/Addresses/Add");
            _loginHelper = new LoginHelper(_driver);

            _page.Navigate();
        }

        [Fact]
        public void Address_WhenEnterValidAddress_ReturnsSuccessMessage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginAdmin();

            // Populate the elements and submit form
            _page.PopulateAddressCountry("Canada");
            _page.PopulateAddressFullName("John Doe");
            _page.PopulateAddressStreetAddress("372 Random Road");
            _page.PopulateAddressCity("Waterloo");      
            _page.PopulateAddressStateProvinceRegion("Ontario");
            _page.PopulateAddressPostalCode("N1P1H1");
            _page.ClickCreate();

            Assert.Equal("Your addresses", _page.Title);
            Assert.Contains("Canada", _page.Source);
            Assert.Contains("John Doe", _page.Source);
            Assert.Contains("372 Random Road", _page.Source);
            Assert.Contains("Waterloo", _page.Source);
            Assert.Contains("Ontario", _page.Source);
            Assert.Contains("N1P1H1", _page.Source);
        }

        [Fact]
        public void Address_WhenEnterNoValues_ReturnsFormValidationErrorMessages()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginAdmin();

            // submit form
            _page.ClickCreate();

            Assert.Equal("Add a new address", _page.Title);
            Assert.Contains("The Full name field is required.", _page.Source);
            Assert.Contains("The Street address field is required.", _page.Source);
            Assert.Contains("The City field is required.", _page.Source);
            Assert.Contains("The State/province/region field is required.", _page.Source);
            Assert.Contains("The Postal/zip code field is required.", _page.Source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}