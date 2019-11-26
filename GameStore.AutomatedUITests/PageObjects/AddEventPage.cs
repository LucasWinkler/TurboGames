using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class AddEventPage : Page
    {
        private IWebElement EventTitleElement => Driver.FindElement(By.Id("Event_Title"));
        private IWebElement EventDateElement => Driver.FindElement(By.Id("Event_Date"));
        private IWebElement EventDetailsElement => Driver.FindElement(By.Id("Event_Details"));
        private SelectElement EventClassificationElement => new SelectElement(Driver.FindElement(By.Id("Event_Classification")));

        public string DateErrorMessage => Driver.FindElement(By.Id("Input_Event_Date-error")).Text;

        public AddEventPage(IWebDriver driver, string pageRoute)
            : base(driver, pageRoute)
        {

        }

        public void PopulateEventTitle(string value) => EventTitleElement.SendKeys(value);
        public void PopulateEventDate(string value) => EventDateElement.SendKeys(value);
        public void PopulateEventDetails(string value) => EventDetailsElement.SendKeys(value);
        public void PopulateEventClassification(string value) => EventClassificationElement.SelectByText(value);
        public void FindEventTitleElement() => Driver.FindElement(By.Id("Event_Title"));
        public void FindAddEventButton() => Driver.FindElement(By.Id("add-event-button"));
        public void ClickSubmit() => EventDetailsElement.Submit();
    }
}
