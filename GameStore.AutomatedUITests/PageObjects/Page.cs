using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.PageObjects
{
    /// <summary>
    /// A PageObject for the page that should be tested.
    /// </summary>
    public class Page
    {
        private readonly string _baseUrl;
        private readonly string _port;
        private readonly string _pageRoute;

        /// <summary>
        /// Initializes a new Page with a web driver and a page route from the website.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        /// <param name="pageRoute">The route for the page that is being tested.</param>
        public Page(IWebDriver driver, string pageRoute)
        {
            Driver = driver;

            // Configure the url that the test will navigate to
            _baseUrl = "https://localhost";
            _port = "44323";
            _pageRoute = pageRoute;
        }

        /// <summary> Gets url for the page that is being tested. </summary>
        private string Url => $"{_baseUrl}:{_port}/{_pageRoute}";

        /// <summary> Gets the web driver that is being used for the page. </summary>
        protected IWebDriver Driver { get; }

        /// <summary> Gets the title of the current page. </summary>
        public string Title => Driver.Title;

        /// <summary> Gets the source code for the current page. </summary>
        public string Source => Driver.PageSource;

        /// <summary> Uses the web drivers Navigate() method to go to the pages url.  </summary>
        public void Navigate() => Driver.Navigate().GoToUrl(Url);
    }
}
