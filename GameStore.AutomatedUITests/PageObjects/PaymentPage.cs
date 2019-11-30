using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class PaymentPage : Page
    {
        private IWebElement CookieElement => Driver.FindElement(By.ClassName("accept-policy"));
        private IWebElement InputCreditCardElement => Driver.FindElement(By.Id("Payment_CardNumber"));
        private IWebElement InputExpiryElement => Driver.FindElement(By.Id("Payment_CardExpirationDate"));
        private IWebElement InputCVCElement => Driver.FindElement(By.Id("Payment_CardCVC"));
        private IWebElement InputCardNameElement => Driver.FindElement(By.Id("Payment_CardName"));
        private IWebElement UpdateElement => Driver.FindElement(By.Id("update-payment-button"));
        public string SuccessMessage => Driver.FindElement(By.Id("StatusMessage")).Text;
        
        public PaymentPage(IWebDriver driver, string pageRoute)
            : base(driver, pageRoute)
        {

        }

        public void ClearCreditCard() => InputCreditCardElement.Clear();
        public void ClearExpiryDate() => InputExpiryElement.Clear();
        public void ClearCVC() => InputCVCElement.Clear();
        public void ClearCreditCardName() => InputCardNameElement.Clear();

        public void PopulateCreditCard(string value) => InputCreditCardElement.SendKeys(value);
        public void PopulateExpiryDate(string value) => InputExpiryElement.SendKeys(value);
        public void PopulateCVC(string value) => InputCVCElement.SendKeys(value);
        public void PopulateCreditCardName(string value) => InputCardNameElement.SendKeys(value);
        public void FindSaveButton() => Driver.FindElement(By.Id("update-payment-button"));
        public void FindStatusMessage() => Driver.FindElement(By.Id("StatusMessage"));
        public void ClickSave() => UpdateElement.Click();

        public void ClickAcceptCookies()
        {
            if (CookieElement != null)
                CookieElement.Click();
        }
    }
}
