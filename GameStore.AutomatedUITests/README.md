- Create a Page Object for the page you want to test.
	- Example: 
		- /PageObjects/RegisterPage.cs
		- public class RegisterPage : Page
		- Make sure to include the constructor from the inherited Page class


- Create a Test class for the page.
	- Example:
		- /Tests/RegisterTests.cs
		- public sealed class RegisterTests : IDisposable
		- public void Dispose() { _driver.Quit(); _driver.Dispose(); }

		```csharp
		private readonly IWebDriver _driver;
        private readonly RegisterPage _page;

        public RegisterTests()
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
            _page = new RegisterPage(_driver, "Register");
            _page.Navigate();
        }

		// TODO: Add tests here.

		public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
		```

- Use the RegisterPage and RegisterTests classes as an example on how to create tests.


- Minimum 2 tests per requirement
	- 1 valid and 1 invalid test will work.
