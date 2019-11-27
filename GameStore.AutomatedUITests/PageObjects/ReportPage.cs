using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class ReportPage : Page
    {
        private IWebElement InputUserElement => Driver.FindElement(By.Id("Input_UserName"));
        private IWebElement InputPasswordElement => Driver.FindElement(By.Id("Input_Password"));
        private IWebElement GamesElement => Driver.FindElement(By.Id("Games"));
        private IWebElement GameDetailsElement => Driver.FindElement(By.Id("GameDetails"));


        public ReportPage(IWebDriver driver, string pageRoute)
            : base(driver, pageRoute)
        {
        }

        public void PopulateUsername(string value) => InputUserElement.SendKeys(value);
        public void PopulatePassword(string value) => InputPasswordElement.SendKeys(value);
        public void ClickGames() => GamesElement.Click();
        public void ClickGameDetails() => GameDetailsElement.Click();
        public void ClickSignIn() => InputPasswordElement.Submit();
    }
}
