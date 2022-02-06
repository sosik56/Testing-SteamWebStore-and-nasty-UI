using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace Task2
{
    class driverSingltone
    {
        private static IWebDriver driver = null;
        private driverSingltone() { }      
       
        public static IWebDriver InizializeWebDriver(string BrowserType,List<string> arguments)
        {
            if(driver == null && BrowserType == "Chrome")
            {

                new DriverManager().SetUpDriver(new ChromeConfig());
                var option = new ChromeOptions();
                option.PageLoadStrategy = PageLoadStrategy.Normal;
                foreach (var item in arguments)
                {
                    option.AddArgument(@$"{item}");
                }            
                
                driver = new ChromeDriver(option);
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
