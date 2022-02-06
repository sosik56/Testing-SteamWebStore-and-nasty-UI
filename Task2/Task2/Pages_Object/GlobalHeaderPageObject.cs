using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriverManager;

namespace Task2.Pages_Object
{
    
    class GlobalHeaderPageObject
    {
        private By _aboutButton = By.XPath("//div[@class='supernav_container']//a[contains(@href,'about')]");
        private By _storeButtone = By.XPath("//div[@class='supernav_container']//a[contains(@data-tooltip-content,'store')]");
        

        public void clickAboutButton(IWebDriver driver)
        {
            driver.FindElement(_aboutButton).Click();
        }
        
        public void clickStoreButton(IWebDriver driver)
        {
            driver.FindElement(_storeButtone).Click();
        }       
        

    }
}
