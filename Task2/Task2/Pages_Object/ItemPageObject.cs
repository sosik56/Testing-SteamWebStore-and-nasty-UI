using OpenQA.Selenium;

namespace Task2.Pages_Object
{
    public class ItemPageObject
    {
        private By itemName = By.XPath("//div[@id='largeiteminfo']//*[contains(@id,'item_name')]");       

        private By RareLocator(string nameRare) =>
            By.XPath($"//div[contains(@id,'item_type')][text()[contains(.,'{nameRare}')]]");
        private By HeroNameLocator(string heroName) =>
            By.XPath($"//div[contains(@id,'item_descriptors')]/div[text()[contains(.,'{heroName}')]]");

        public string GetItemName(IWebDriver driver, int waitSec)
        {
            Expectations.WaitUntilVisible(driver, itemName, waitSec);
            return driver.FindElement(itemName).Text;
        }
        public bool IsTypeOfItem(IWebDriver driver, int waitSec, string nameRare)
        {
            Expectations.WaitUntilVisible(driver, RareLocator(nameRare), waitSec);
            return driver.FindElements(RareLocator(nameRare)).Count == 1;
        }
        public bool IsItemForWhom(IWebDriver driver, int waitSec, string heroName)
        {
            Expectations.WaitUntilVisible(driver, HeroNameLocator(heroName), waitSec);
            return driver.FindElements(HeroNameLocator(heroName)).Count == 1;
        }
    }
}
