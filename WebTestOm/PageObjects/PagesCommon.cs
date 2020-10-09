using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebTestOm.PageObjects
{
    public class PagesCommon
    {
        protected IWebDriver _driver;
        protected Actions actions;
        protected readonly TimeSpan timeSpan = TimeSpan.FromSeconds(15);

        public void ImplicitWait(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = timeSpan;
        }
        private void WaitForElement(IWebElement element)
        {
            ImplicitWait(_driver);
            new WebDriverWait(_driver, timeSpan).Until(driver => element.Displayed);
        }
        public void WaitForElementAndClick(IWebElement element)
        {
            WaitForElement(element);
            element.Click();
        }

        public void SelectCombobox(IWebElement element, string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(value);
        }

        public void MoveToElement(IWebElement element)
        {
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
