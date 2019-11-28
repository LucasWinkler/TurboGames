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
    public sealed class PaymentTests
    {
        private readonly IWebDriver _driver;
        private readonly PaymentPage _page;
        private readonly LoginHelper _loginHelper;

        public PaymentTests()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory);
            geckoService.Host = "::1";
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            _driver = new FirefoxDriver(geckoService, firefoxOptions);
            _page = new PaymentPage(_driver, "/Settings/Payment");
            _loginHelper = new LoginHelper(_driver);

            _page.Navigate();
        }

        [Fact]
        public void Payment_EnterCreditCardInformation_ReturnsSuccessMessage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _loginHelper.LoginUser();

            // Make sure we find the preferences save button
            _page.FindSaveButton();

            // Accept cookies so the status message will appear
            _page.ClickAcceptCookies();


            string creditCard = "4123450131003313";
            string exp = "12/23";
            string cvc = "343";
            string name = "Lucas Winkler";
            // Populate the elements and submit form
            _page.PopulateCreditCard(creditCard.Replace("4123450131003313", "4123450131003312"));
            _page.PopulateExpiryDate(exp.Replace("12/23","01/19"));
            _page.PopulateCVC(cvc.Replace("343","312"));
            _page.PopulateCreditCardName(name.Replace("Lucas Winkler","Bob Smith"));
            _page.ClickSave();

            // Checks to see if the status message exists
            _page.FindStatusMessage();

            // Make sure we're on the preferences page and check the source for the StatusMessage text
            Assert.Equal("Payment information", _page.Title);
            Assert.Contains("Your payment information has been updated", _page.Source);
        }
    }
}
