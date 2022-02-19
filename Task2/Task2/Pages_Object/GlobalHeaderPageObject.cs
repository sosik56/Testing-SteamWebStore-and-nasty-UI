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

        public void ClickAboutButton()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            driver.FindElement(_aboutButton).Click();
        }
        
        public void ClickStoreButton()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            driver.FindElement(_storeButtone).Click();
        } 

        public void PoupMenuCommunityMarketClick()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            IWebElement newTab = driver.FindElement(_communityButton);
            Actions action = new Actions(driver);
            action.MoveToElement(newTab);
            action.Perform();
            Expectations.WaitUntilVisible(_poupMenyMarket);
            driver.FindElement(_poupMenyMarket).Click();
        } 
    }
}
