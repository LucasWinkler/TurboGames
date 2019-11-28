using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace GameStore.AutomatedUITests.PageObjects
{
    public class DeleteEventPage : Page
    {
        private SelectElement EventClassificationElement => new SelectElement(Driver.FindElement(By.Id("Event_Classification")));

        public string DateErrorMessage => Driver.FindElement(By.Id("Input_Event_Date-error")).Text;

        public DeleteEventPage(IWebDriver driver, string pageRoute)
            : base(driver, pageRoute)
        {

        }

        public void FindDeleteEventButton(string value) => Driver.FindElement(By.Id("deleteEventBtn-" + value));
        public void ClickDelete(string value) => Driver.FindElement(By.Id("deleteEventBtn-" + value)).Click();

        public void FindDeleteEventButtonActual() => Driver.FindElement(By.Id("deleteEventBtn"));

        public void ClickDeleteEventButton() => Driver.FindElement(By.Id("deleteEventBtn")).Click();
    }
}
