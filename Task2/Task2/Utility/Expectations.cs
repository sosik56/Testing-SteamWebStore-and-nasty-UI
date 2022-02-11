using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2
{
    public static class Expectations
    {
        public static void WaitUntilVisible(IWebDriver driver, By by, int seconds)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
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

        public static void WaitUntilCkicable(IWebDriver driver, By by, int seconds)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
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

        public static void WaitUntilAllElementsVisible(IWebDriver driver, By by, int seconds)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
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
