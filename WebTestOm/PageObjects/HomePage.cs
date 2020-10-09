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
        public IWebElement closeCookieInfoButton => _driver.FindElement(By.CssSelector(".fa-times"));
        public IWebElement contactPage => _driver.FindElement(By.CssSelector(".header__function-nav--right .header__menuitem--function-nav:nth-child(3) > .header__menulink--function-nav"));

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
            WaitForElementAndClick(closeCookieInfoButton);
        }

        public void GoToContactPage()
        {
            WaitForElementAndClick(contactPage);
        }


    }
}
