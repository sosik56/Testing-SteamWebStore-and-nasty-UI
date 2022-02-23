using OpenQA.Selenium;

namespace Task3.Utility
{
    public static class DriverSinglton
    {
        private static IWebDriver driver = null;

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
        
        public static void CloseCurrentTab()
        {            
            LogUtils.MakeSystemLog($"The TAB {driver.CurrentWindowHandle} was closed");
            driver.Close();
        }   
        
        public static string GetTitle()
        {
            return driver.Title;
        }

        public static string GetUrl()
        {
            return driver.Url;
        }

        public static void SwitchToTheTabByIndx(int i)
        {
            if(i < driver.WindowHandles.Count)
            {
                LogUtils.MakeSystemLog($"TAB was switched to {driver.WindowHandles[i]}");
                driver.SwitchTo().Window(driver.WindowHandles[i]);                
            }
            else
            {
                LogUtils.MakeSystemLog("There is no such TAB");
            }
        }

        public static int CountOfTabs()
        {
            return driver.WindowHandles.Count;
        }
    }
}
