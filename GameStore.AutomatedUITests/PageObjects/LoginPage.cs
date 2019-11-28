using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class LoginPage : Page
    {
        private IWebElement UserNameElement => Driver.FindElement(By.Id("Input_UserName"));
        private IWebElement PasswordElement => Driver.FindElement(By.Id("Input_Password"));
        private IWebElement LoginElement => Driver.FindElement(By.Id("Input_Login"));

        public LoginPage(IWebDriver driver, string pageRoute)
            : base(driver, pageRoute)
        {
        }

        public void PopulateUserName(string value) => UserNameElement.SendKeys(value);
        public void PopulatePassword(string value) => PasswordElement.SendKeys(value);
        public void ClickLogin() => LoginElement.Click();
        public void FindRegisteredUserMenu() => Driver.FindElement(By.Id("userMenuButton"));
    }
}
