using System.Collections.Generic;
using OpenQA.Selenium;
using Task2.Utility;

namespace Task2
{
    public static class DriverSingltone
    {
        public static IWebDriver driver = null;             
       
        public static IWebDriver InizializeWebDriver()
        {
            if (driver == null)
            {
                driver = BrowserFactory.InitializeBrowser();
                return driver;
            }
            return driver;
        }

        public static void EndAndNull()
        {
            driver.Quit();
            driver = null;
        }
    }
}
