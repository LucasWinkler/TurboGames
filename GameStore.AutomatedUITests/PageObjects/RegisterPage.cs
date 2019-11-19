using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class RegisterPage : Page
    {
        private IWebElement UserNameElement => Driver.FindElement(By.Id("Input_UserName"));
        private IWebElement FirstNameElement => Driver.FindElement(By.Id("Input_FirstName"));
        private IWebElement LastNameElement => Driver.FindElement(By.Id("Input_LastName"));
        private IWebElement EmailElement => Driver.FindElement(By.Id("Input_Email"));
        private IWebElement GenderElement => Driver.FindElement(By.Id("Input_Gender"));
        private IWebElement DOBElement => Driver.FindElement(By.Id("Input_DOB"));
        private IWebElement PasswordElement => Driver.FindElement(By.Id("Input_Password"));
        private IWebElement ConfirmPasswordElement => Driver.FindElement(By.Id("Input_ConfirmPassword"));
        private IWebElement CreateElement => Driver.FindElement(By.Id("Input_Create"));

        public string EmailErrorMessage => Driver.FindElement(By.Id("Input_Email-error")).Text;

        public RegisterPage(IWebDriver driver, string pageRoute)
            : base(driver, pageRoute)
        {
        }

        public void PopulateUserName(string value) => UserNameElement.SendKeys(value);
        public void PopulateFirstName(string value) => FirstNameElement.SendKeys(value);
        public void PopulateLastName(string value) => LastNameElement.SendKeys(value);
        public void PopulateEmail(string value) => EmailElement.SendKeys(value);
        public void PopulateGender(string value) => GenderElement.SendKeys(value);
        public void PopulateDOB(string value) => DOBElement.SendKeys(value);
        public void PopulatePassword(string value) => PasswordElement.SendKeys(value);
        public void PopulateConfirmPassword(string value) => ConfirmPasswordElement.SendKeys(value);
        public void ClickCreate() => CreateElement.Click();
        public void FindRegisteredUserMenu() => Driver.FindElement(By.Id("userMenuButton"));
    }
}
