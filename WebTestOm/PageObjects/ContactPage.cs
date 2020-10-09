using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestOm.PageObjects
{
    public class ContactPage : PagesCommon
    {
        public ContactPage (IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement contactFormDepartament => _driver.FindElement(By.Id("581103_91599pi_581103_91599"));
        public IWebElement contactFormFirstName => _driver.FindElement(By.Id("581103_89027pi_581103_89027"));
        public IWebElement contactFormLastName => _driver.FindElement(By.Id("581103_89029pi_581103_89029"));
        public IWebElement contactFormCompany => _driver.FindElement(By.Id("581103_89031pi_581103_89031"));
        public IWebElement contactFormJobTitle=> _driver.FindElement(By.Id("581103_89035pi_581103_89035"));
        public IWebElement contactFormLevel => _driver.FindElement(By.Id("581103_89183pi_581103_89183"));
        public IWebElement contactFormEmail => _driver.FindElement(By.Id("581103_89033pi_581103_89033"));
        public IWebElement contactFormPhone => _driver.FindElement(By.Id("581103_92509pi_581103_92509"));
        public IWebElement contactFormCountry => _driver.FindElement(By.Id("581103_89179pi_581103_89179"));
        public IWebElement contactFormSubject => _driver.FindElement(By.Id("581103_91683pi_581103_91683"));
        public IWebElement contactFormAccept => _driver.FindElement(By.CssSelector(".inline"));
        public IWebElement contactFormSubmit => _driver.FindElement(By.CssSelector(".submit > input"));


        internal void FillContactForm()
        {
            //text fields are in the frame so we need to switch to it
            _driver.SwitchTo().Frame(0);
            //putting test values into text fields
            SelectCombobox(contactFormDepartament, "Sales");
            contactFormFirstName.SendKeys("FirstName");
            contactFormLastName.SendKeys("LastName");
            contactFormCompany.SendKeys("Company");
            contactFormJobTitle.SendKeys("JobTitle");
            SelectCombobox(contactFormLevel, "Manager");
            contactFormEmail.SendKeys("email@email.dk");
            contactFormPhone.SendKeys("123456789");
            SelectCombobox(contactFormCountry, "Poland");
            contactFormSubject.SendKeys("Title");
            contactFormAccept.Click();
        }
        internal void SumbmitContactForm()
        {
            WaitForElementAndClick(contactFormSubmit);
        }
    }
}
