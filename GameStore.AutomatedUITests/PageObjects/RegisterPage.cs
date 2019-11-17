using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:44378/Register";

        private IWebElement UserNameElement => _driver.FindElement(By.Id("Input_UserName"));
        private IWebElement FirstNameElement => _driver.FindElement(By.Id("Input_FirstName"));
        private IWebElement LastNameElement => _driver.FindElement(By.Id("Input_LastName"));
        private IWebElement EmailElement => _driver.FindElement(By.Id("Input_Email"));
        private IWebElement GenderElement => _driver.FindElement(By.Id("Input_Gender"));
        private IWebElement DOBElement => _driver.FindElement(By.Id("Input_DOB"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("Input_Password"));
        private IWebElement ConfirmPasswordElement => _driver.FindElement(By.Id("Input_ConfirmPassword"));
        private IWebElement CreateElement => _driver.FindElement(By.Id("Input_Create"));

        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        public string EmailErrorMessage => _driver.FindElement(By.Id("Input_Email-error")).Text;

        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
        public void PopulateUserName(string value) => UserNameElement.SendKeys(value);
        public void PopulateFirstName(string value) => FirstNameElement.SendKeys(value);
        public void PopulateLastName(string value) => LastNameElement.SendKeys(value);
        public void PopulateEmail(string value) => EmailElement.SendKeys(value);
        public void PopulateGender(string value) => GenderElement.SendKeys(value);
        public void PopulateDOB(string value) => DOBElement.SendKeys(value);
        public void PopulatePassword(string value) => PasswordElement.SendKeys(value);
        public void PopulateConfirmPassword(string value) => ConfirmPasswordElement.SendKeys(value);
        public void ClickCreate() => CreateElement.Click();
        public void FindRegisteredUserMenu() => _driver.FindElement(By.Id("userMenuButton"));
    }
}
