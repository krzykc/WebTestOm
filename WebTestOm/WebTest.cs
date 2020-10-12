﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Security.Permissions;
using WebTestOm.PageObjects;

namespace WebTestOm
{
    [TestClass]
    public class WebTest
    {
        public IWebDriver driver;
        private const string driverPath = @"C:\drivers";
        //private const string screenshotPath = "screenshots";
        private const string homePage = @"https://www.omada.net";
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                string scrinshotPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/screenshots/" + TestContext.TestName + "_screenshot.png";
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
        private void RunDriver(BrowserType browserType)
        {
            driver = WebDriverFactory.create(browserType);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.IE11)]
        public void VerifyLiveDemo(BrowserType browserType)
        {
            RunDriver(browserType);
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

        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.IE11)]
        public void VerifyContact(BrowserType browserType)
        {
            RunDriver(browserType);
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

        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.IE11)]
        public void VerifyAboutUs(BrowserType browserType)
        {
            RunDriver(browserType);
            var home = new HomePage(driver);
            home.GoToHomePage();
            home.CloseCookiInfoBar();
            home.GoToAboutUsPage();
        }
}
