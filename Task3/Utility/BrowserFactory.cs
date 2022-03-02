﻿using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using Task3.ForData;
using System;

namespace Task3.Utility
{
    public static class BrowserFactory
    {
        public static IWebDriver InitializeBrowser()
        {
            List<string> arguments = UtilityClass.ConfigData.Arguments;
            BrowserTypes browserType;
            IWebDriver driver = null;

            try
            {
                browserType = (BrowserTypes)Enum.Parse(typeof(BrowserTypes), UtilityClass.ConfigData.BrowserType.ToLower());
            }
            catch (Exception)
            {
                Console.WriteLine("No apropriate data");
                throw new Exception("No apropriate data");
            }            

            switch (browserType)
            {
                case BrowserTypes.chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var option = new ChromeOptions();
                    option.AddUserProfilePreference("download.default_directory", AppDomain.CurrentDomain.BaseDirectory);
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
                    optionFF.SetPreference("browser.download.folderList",2); //2 means download to specify folder
                    optionFF.SetPreference("browser.download.dir", AppDomain.CurrentDomain.BaseDirectory);
                    optionFF.SetPreference("browser.helperApps.neverAsk.saveToDisk", "image/jpeg, image/png");

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
                    throw new Exception("No apropriate data");
            }
        }
    }
}
