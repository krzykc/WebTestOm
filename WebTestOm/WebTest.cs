using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Security.Permissions;
using WebTestOm.PageObjects;

namespace WebTestOm
{
    [TestClass]
    public class WebTest
    {
        public IWebDriver driver;
        public const string driverPath = @"C:\drivers";
        private const string homePage = @"https://www.omada.net";

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome, driverPath)]
        [DataRow(BrowserType.IE11, driverPath)]
        public void VerifyLiveDemo(BrowserType browserType, string driverPath)
        {
            using (IWebDriver driver = WebDriverFactory.create(browserType, driverPath))
            {
                driver.Manage().Window.Maximize();
                var home = new HomePage(driver);
                home.GoToHomePage();
                home.CloseCookiInfoBar();
                home.GoToRequestDemo();
                var requestDemo = new RequestDemo(driver);
                Assert.IsTrue(requestDemo.IsCorrectAddress("https://www.omada.net/en-us/more/resources/request-an-omada-live-demo"));
                requestDemo.FillRequestForm();
                //Commented out due to avoid spam on Production environment
                //reqDemo.SumbmitRequestForm();
                //Assert.IsTrue(reqDemo.IsCorrectAddress("https://www.omada.net/en-us/more/resources/request-an-omada-live-demo");
            }
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome, driverPath)]
        [DataRow(BrowserType.IE11, driverPath)]
        public void VerifyContact(BrowserType browserType, string driverPath)
        {
            using (IWebDriver driver = WebDriverFactory.create(browserType, driverPath))
            {
                driver.Manage().Window.Maximize();
                var home = new HomePage(driver);
                home.GoToHomePage();
                home.CloseCookiInfoBar();
                home.GoToContactPage();
                var contact = new ContactPage(driver);
                contact.IsCorrectAddress("https://www.omada.net/en-us/more/company/contact");
                contact.FillContactForm();
                //Commented out due to avoid spam on Production environment
                //contact.SumbmitContactForm();
                //Assert.IsTrue(reqDemo.IsCorrectAddress("https://www.omada.net/en-us/more/resources/request-an-omada-live-demo");

            }
        }
    }
}
