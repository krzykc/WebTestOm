using OpenQA.Selenium;

namespace WebTestOm.PageObjects
{
    public class HomePage : PagesCommon
    {
        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement requestDemoButton => _driver.FindElement(By.CssSelector(".slider__button"));
        public IWebElement CloseCookieInfoButton => _driver.FindElement(By.CssSelector(".fa-times"));

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.omada.net");
            ImplicitWait(_driver);
        }

        public void GoToRequestDemo()
        {
            WaitForElementAndClick(requestDemoButton);
        }

        public void CloseCookiInfoBar()
        {
            WaitForElementAndClick(CloseCookieInfoButton);
        }


    }
}
