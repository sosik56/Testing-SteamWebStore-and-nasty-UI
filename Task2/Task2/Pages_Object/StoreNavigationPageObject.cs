using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Task2.Pages_Object
{
    public class StoreNavigationPageObject
    {
        private By _newAndNoteworthyTab = By.Id("noteworthy_tab");
        private By _topSellersPopup = By.XPath("//div[@id='noteworthy_flyout']//a[contains(@href,'topsellers')]");
       
        public void PopupMenuTopSellersClick()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            IWebElement newTab = driver.FindElement(_newAndNoteworthyTab);
            Actions action = new Actions(driver);
            action.MoveToElement(newTab);
            action.Perform();
            Expectations.WaitUntilVisible(_topSellersPopup);
            driver.FindElement(_topSellersPopup).Click();
        }
    
    }
}
