using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.Helpers
{
    public class LoginHelper
    {
        private readonly IWebDriver _driver;

        private IWebElement UserNameElement => _driver.FindElement(By.Id("Input_UserName"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("Input_Password"));

        public LoginHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string route) => _driver.Navigate().GoToUrl(route);

        public void Login(string username, string password)
        {
            PopulateUsername(username);
            PopulatePassword(password);
            ClickSignIn();
        }

        public void LoginAdmin()
        {
            PopulateUsername("Admin");
            PopulatePassword("Admin123!");
            ClickSignIn();
        }

        public void LoginUser()
        {
            PopulateUsername("User");
            PopulatePassword("User123!");
            ClickSignIn();
        }

        private void PopulateUsername(string value) => UserNameElement.SendKeys(value);
        private void PopulatePassword(string value) => PasswordElement.SendKeys(value);
        private void ClickSignIn() => PasswordElement.Submit();
    }
}
