using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using Task2.ForData;
using System;

namespace Task2.Utility
{
    public static  class BrowserFactory
    {     
        public static  IWebDriver InitializeBrowser(string browserTypeStr, List<string> arguments)
        {
            BrowserTypes browserType;
            try
            {
                browserType = (BrowserTypes)Enum.Parse(typeof(BrowserTypes), browserTypeStr.ToLower());
            }
            catch (Exception)
            {
                Console.WriteLine("No apropriate data");
                browserType = BrowserTypes.chrome;
            }             

            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserTypes.chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var option = new ChromeOptions();
                    option.PageLoadStrategy = PageLoadStrategy.Normal;
                    foreach (var item in arguments)
                    {
                        option.AddArgument(@$"{item}");
                    }
                    driver = new ChromeDriver(option);
                    return driver;                    

                case BrowserTypes.firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    var optionFF = new FirefoxOptions();
                    optionFF.PageLoadStrategy = PageLoadStrategy.Normal;
                    foreach (var item in arguments)
                    {
                        optionFF.AddArgument(@$"{item}");
                    }
                    driver = new FirefoxDriver(optionFF);
                    return driver;

                case BrowserTypes.opera:
                    new DriverManager().SetUpDriver(new OperaConfig());
                    var optionOpera = new OperaOptions();                    
                    optionOpera.PageLoadStrategy = PageLoadStrategy.Normal;                    
                    foreach (var item in arguments)
                    {
                        optionOpera.AddArgument(@$"{item}");
                        
                    }
                    driver = new OperaDriver(optionOpera);
                    return driver;

                default:
                    System.Console.WriteLine("No apropriate data");
                    return null;
            }
        }
    }
}
