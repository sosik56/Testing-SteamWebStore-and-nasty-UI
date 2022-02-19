using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Task3.Utility
{
    public static class Expectations
    {
        public static int waitSec = UtilityClass.ConfigData.WaitingTime;

        public static void WaitUntilVisible(By by)
        {
            var driver = DriverSinglton.InizializeWebDriver();
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSec));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch
            {
                Console.WriteLine($"{by} not visibale");
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            }
        }

        public static void WaitUntilCkicable(By by)
        {
            var driver = DriverSinglton.InizializeWebDriver();
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSec));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));

            }
            catch
            {
                Console.WriteLine($"{by} not visibale");
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            }
        }

        public static void WaitUntilAllElementsVisible(By by)
        {
            var driver = DriverSinglton.InizializeWebDriver();
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSec));
            try
            {
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }
            catch
            {
                Console.WriteLine($"{by} not visibale");
            }
        }

    }
}

