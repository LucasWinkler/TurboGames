using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class PreferencesPage : Page
    {
        private IWebElement InputUserElement => Driver.FindElement(By.Id("Input_UserName"));
        private IWebElement InputPasswordElement => Driver.FindElement(By.Id("Input_Password"));
        private IWebElement CookieElement => Driver.FindElement(By.ClassName("accept-policy"));
        private SelectElement SelectPlatformElement => new SelectElement(Driver.FindElement(By.Id("Input_PlatformId")));
        private SelectElement SelectCategoryElement => new SelectElement(Driver.FindElement(By.Id("Input_CategoryId")));
        private IWebElement SaveElement => Driver.FindElement(By.Id("update-preferences-button"));
        public string SuccessMessage => Driver.FindElement(By.Id("StatusMessage")).Text;

        public PreferencesPage(IWebDriver driver, string pageRoute) : base(driver, pageRoute)
        {
            
        }
        public void PopulateUsername(string value) => InputUserElement.SendKeys(value);
        public void PopulatePassword(string value) => InputPasswordElement.SendKeys(value);
        public void PopulateSelectPlatform(string value) => SelectPlatformElement.SelectByText(value);
        public void PopulateSelectCategory(string value) => SelectCategoryElement.SelectByText(value);
        public void FindStatusMessage() => Driver.FindElement(By.Id("StatusMessage"));
        public void FindSaveButton() => Driver.FindElement(By.Id("update-preferences-button"));
        public void ClickAcceptCookies()
        {
            if (CookieElement != null)
                CookieElement.Click();
        }
        public void ClickSave() => SaveElement.Click();
        public void ClickSignIn() => InputPasswordElement.Submit();
    }
}
