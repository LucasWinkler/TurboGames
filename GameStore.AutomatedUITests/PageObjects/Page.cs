using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.PageObjects
{
    /// <summary>
    /// A PageObject for the page that should be tested.
    /// </summary>
    public class Page
    {
        private readonly string _url;

        /// <summary>
        /// Initializes a new Page with a web driver and a page route from the website.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        /// <param name="pageRoute">The route for the page that is being tested.</param>
        public Page(IWebDriver driver, string pageRoute)
        {
            Driver = driver;
            _url = "https://localhost:44378/" + pageRoute;
        }

        /// <summary> Gets the title of the current page. </summary>
        public string Title => Driver.Title;

        /// <summary> Gets the source code for the current page. </summary>
        public string Source => Driver.PageSource;

        /// <summary> Gets the web driver that is being used for the page. </summary>
        protected IWebDriver Driver { get; }

        /// <summary> Uses the web drivers Navigate() method to go to the pages url.  </summary>
        public void Navigate() => Driver.Navigate().GoToUrl(_url);
    }
}
