using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Task2.Pages_Object
{
    class MainPageObject
    {
        private By _mainPageLocator = By.XPath("//div[contains(@class,'home_page')]");
        
      
        public bool atPage(IWebDriver driver)
        {
            return driver.FindElements(_mainPageLocator).Count > 0;
        }        

    }
}
