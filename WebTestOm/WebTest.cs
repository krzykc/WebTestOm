using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using WebTestOm.PageObjects;

namespace WebTestOm
{
    [TestClass]
    public class WebTest
    {
        public IWebDriver driver;
        private const string driverPath = @"C:\drivers";
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                string scrinshotPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\screenshots\" + TestContext.TestName + "_screenshot.png";
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(scrinshotPath);
                TestContext.AddResultFile(scrinshotPath);
            }
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
        private void RunDriver(BrowserType browserType, string driverPath)
        {
            driver = WebDriverFactory.create(browserType, driverPath);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome, driverPath)]
        [DataRow(BrowserType.IE11, driverPath)]
        public void VerifyLiveDemo(BrowserType browserType, string driverPath)
        {
            RunDriver(browserType, driverPath);
            var home = new HomePage(driver);
            home.GoToHomePage();
            Assert.IsTrue(home.IsCorrectAddress("https://www.omada.net/"));
            home.CloseCookiInfoBar();
            home.GoToRequestDemo();
            var requestDemo = new RequestDemo(driver);
            Assert.IsTrue(requestDemo.IsCorrectAddress("https://www.omada.net/en-us/more/resources/request-an-omada-live-demo"));
            requestDemo.FillRequestForm();
            //Commented out due to avoid spam on Production environment
            //reqDemo.SumbmitRequestForm();
            //Assert.IsTrue(reqDemo.IsCorrectAddress("https://www.omada.net/en-us/more/resources/request-an-omada-live-demo");
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome, driverPath)]
        [DataRow(BrowserType.IE11, driverPath)]
        public void VerifyContact(BrowserType browserType, string driverPath)
        {
            RunDriver(browserType, driverPath);
            var home = new HomePage(driver);
            home.GoToHomePage();
            Assert.IsTrue(home.IsCorrectAddress("https://www.omada.net/"));
            home.CloseCookiInfoBar();
            home.GoToContactPage();
            Assert.IsTrue(home.IsCorrectAddress("https://www.omada.net/en-us/more/company/contact"));
            var contact = new ContactPage(driver);
            contact.FillContactForm();
            //Commented out due to avoid spam on Production environment
            //contact.SumbmitContactForm();
            //Assert.IsTrue(reqDemo.IsCorrectAddress("https://www.omada.net/en-us/more/resources/request-an-omada-live-demo");
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome, driverPath)]
        [DataRow(BrowserType.IE11, driverPath)]
        public void VerifyAboutUs(BrowserType browserType, string driverPath)
        {
            RunDriver(browserType, driverPath);
            var home = new HomePage(driver);
            home.GoToHomePage();
            Assert.IsTrue(home.IsCorrectAddress("https://www.omada.net/"));
            home.CloseCookiInfoBar();
            home.GoToAboutUsPage();
            Assert.IsTrue(home.IsCorrectAddress("https://www.omada.net/en-us/more"));
        }
    }
}
