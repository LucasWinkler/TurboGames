using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class GameLibraryPage : Page
    {
        private IWebElement InputUserElement => Driver.FindElement(By.Id("Input_UserName"));
        private IWebElement InputPasswordElement => Driver.FindElement(By.Id("Input_Password"));

        private IWebElement CookieElement => Driver.FindElement(By.ClassName("accept-policy"));

        private IWebElement DownloadElement => Driver.FindElement(By.Id("btnDownload"));
        public GameLibraryPage(IWebDriver driver, string pageRoute) : base(driver, pageRoute)
        {

        }
        public void PopulateUsername(string value) => InputUserElement.SendKeys(value);
        public void PopulatePassword(string value) => InputPasswordElement.SendKeys(value);
        public void FindDownloadButton() => Driver.FindElement(By.Id("btnDownload"));
        public void ClickAcceptCookies()
        {
            if (CookieElement != null)
                CookieElement.Click();
        }
        public void ClickDownload() => DownloadElement.Click();
        public void ClickSignIn() => InputPasswordElement.Submit();
    }
}
