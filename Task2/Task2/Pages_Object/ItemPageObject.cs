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

        public string GetItemName()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilVisible(itemName);
            return driver.FindElement(itemName).Text;
        }

        public bool IsTypeOfItem(string nameRare)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilVisible(RareLocator(nameRare));
            return driver.FindElements(RareLocator(nameRare)).Count == 1;
        }

        public bool IsItemForWhom(string heroName)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilVisible(HeroNameLocator(heroName));
            return driver.FindElements(HeroNameLocator(heroName)).Count == 1;
        }
    }
}
