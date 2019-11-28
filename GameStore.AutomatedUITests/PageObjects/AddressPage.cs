using OpenQA.Selenium;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class AddressPage : Page
    {
        private IWebElement AddressCountryElement => Driver.FindElement(By.Id("Address_Country"));
        private IWebElement AddressFullNameElement => Driver.FindElement(By.Id("Address_FullName"));
        private IWebElement AddressStreetAddressElement => Driver.FindElement(By.Id("Address_StreetAddress"));
        private IWebElement AddressCityElement => Driver.FindElement(By.Id("Address_City"));
        private IWebElement AddressStateProvinceRegionElement => Driver.FindElement(By.Id("Address_StateProvinceRegion"));
        private IWebElement AddressPostalCodeElement => Driver.FindElement(By.Id("Address_PostalCode"));
        private IWebElement CreateElement => Driver.FindElement(By.Id("Address_Create"));


        public AddressPage(IWebDriver driver, string pageRoute)
            : base(driver, pageRoute)
        {
        }

        public void PopulateAddressCountry(string value) => AddressCountryElement.SendKeys(value);
        public void PopulateAddressFullName(string value) => AddressFullNameElement.SendKeys(value);
        public void PopulateAddressStreetAddress(string value) => AddressStreetAddressElement.SendKeys(value);
        public void PopulateAddressCity(string value) => AddressCityElement.SendKeys(value);
        public void PopulateAddressStateProvinceRegion(string value) => AddressStateProvinceRegionElement.SendKeys(value);
        public void PopulateAddressPostalCode(string value) => AddressPostalCodeElement.SendKeys(value);
        public void ClickCreate() => CreateElement.Click();
    }
}
