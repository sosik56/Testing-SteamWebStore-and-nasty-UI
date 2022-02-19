using OpenQA.Selenium;

namespace Task3.Utility
{
    public static class DriverSinglton
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
