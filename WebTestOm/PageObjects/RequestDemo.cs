using OpenQA.Selenium;

namespace WebTestOm.PageObjects
{
    public class RequestDemo : PagesCommon
    {
        public RequestDemo(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement requestDemoForm => _driver.FindElement(By.Id("pardot-form"));
        public IWebElement requestDemoFormName => _driver.FindElement(By.Id("581103_92489pi_581103_92489"));
        public IWebElement requestDemoFormLastName => _driver.FindElement(By.Id("581103_92491pi_581103_92491"));
        public IWebElement requestDemoFormCompany => _driver.FindElement(By.Id("581103_92495pi_581103_92495"));
        public IWebElement requestDemoFormJobTitle => _driver.FindElement(By.Id("581103_92493pi_581103_92493"));
        public IWebElement requestDemoFormBusinessEmail => _driver.FindElement(By.Id("581103_92499pi_581103_92499"));
        public IWebElement requestDemoFormPhone => _driver.FindElement(By.Id("581103_92501pi_581103_92501"));
        public IWebElement requestDemoFormCountryCombobox => _driver.FindElement(By.Id("581103_92497pi_581103_92497"));
        public IWebElement requestDemoFormNumberEmploeesCombobox => _driver.FindElement(By.Id("581103_139485pi_581103_139485"));
        public IWebElement requestDemoFormAcceptCheckbox => _driver.FindElement(By.CssSelector(".inline"));
        public IWebElement requestDemoFormSubmitButton => _driver.FindElement(By.Id(".submit > input"));

        internal void SumbmitRequestForm()
        {
            WaitForElementAndClick(requestDemoFormSubmitButton);
        }

        internal void FillRequestForm()
        {
            //text field are in the frame so we need to switch to it
            _driver.SwitchTo().Frame(0);
            //putting test values into text fields
            requestDemoFormName.Clear();
            requestDemoFormName.SendKeys("TestName");
            requestDemoFormLastName.SendKeys("TestLastName");
            requestDemoFormCompany.SendKeys("TestCompanyName");
            requestDemoFormJobTitle.SendKeys("TestJobTitle");
            requestDemoFormBusinessEmail.SendKeys("TestBusinessEmail");
            requestDemoFormPhone.SendKeys("123456789");
            SelectCombobox(requestDemoFormCountryCombobox, "Poland");
            SelectCombobox(requestDemoFormNumberEmploeesCombobox, "0-500");
            requestDemoFormAcceptCheckbox.Click();
        }
    }
}
