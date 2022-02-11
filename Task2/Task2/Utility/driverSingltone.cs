using System.Collections.Generic;
using OpenQA.Selenium;
using Task2.Utility;

namespace Task2
{
    public static class driverSingltone
    {
        public static IWebDriver driver = null;             
       
        public static IWebDriver InizializeWebDriver(string BrowserType,List<string> arguments)
        {
            if (driver == null)
            {
                driver = BrowserFactory.InitializeBrowser(BrowserType, arguments);
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
