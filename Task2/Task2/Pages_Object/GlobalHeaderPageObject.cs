using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Task2.Pages_Object
{    
    public class GlobalHeaderPageObject
    {
        private By _aboutButton = By.XPath("//div[@class='supernav_container']//a[contains(@href,'about')]");
        private By _storeButtone = By.XPath("//div[@class='supernav_container']//a[contains(@data-tooltip-content,'store')]");
        private By _communityButton = By.XPath("//div[@id='global_header']//a[contains(@data-tooltip-content,'community')]");

        private By _poupMenyMarket = By.XPath("//div[@id='global_header']//a[contains(@href,'market')]");        

        public void ClickAboutButton(IWebDriver driver)
        {
            driver.FindElement(_aboutButton).Click();
        }
        
        public void ClickStoreButton(IWebDriver driver)
        {
            driver.FindElement(_storeButtone).Click();
        } 

        public void PoupMenuCommunityMarketClick(IWebDriver driver, int waitSec)
        {
            IWebElement newTab = driver.FindElement(_communityButton);
            Actions action = new Actions(driver);
            action.MoveToElement(newTab);
            action.Perform();
            Expectations.WaitUntilVisible(driver, _poupMenyMarket, waitSec);
            driver.FindElement(_poupMenyMarket).Click();
        }
        

    }
}
