using OpenQA.Selenium;

namespace Task2.Pages_Object
{
    public class MainPageObject
    {
        private By _mainPageLocator = By.XPath("//div[contains(@class,'home_page')]");        
      
        public bool IsPageOpen(IWebDriver driver)
        {
            return driver.FindElements(_mainPageLocator).Count > 0;
        }        

    }
}
