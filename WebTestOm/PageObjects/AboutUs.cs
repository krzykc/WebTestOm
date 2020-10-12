using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestOm.PageObjects
{
    public class AboutUs : PagesCommon
    {
        public AboutUs(IWebDriver driver)
        {
            this._driver = driver;
        }

    }
}
