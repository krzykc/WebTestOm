using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;

namespace WebTestOm
{
    public static class WebDriverFactory
    {
        public static IWebDriver create(BrowserType type)
        {
            switch(type)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                case BrowserType.IE11:
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieOptions.IgnoreZoomLevel = true;
                    ieOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                    ieOptions.EnablePersistentHover = true;
                    ieOptions.EnableNativeEvents = false;
                    ieOptions.EnsureCleanSession = true;
                    return new InternetExplorerDriver(ieOptions);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
