using System.Collections.Generic;
using OpenQA.Selenium;

namespace Task2.Pages_Object
{
    class GamePageObject
    {
        private By _gameNameOnHisPage = By.Id("appHubAppName");
        private By _gameReleaseOnHisPAge = By.ClassName("date");
        private By _gamePriceOnHisPage = By.XPath("//div[contains(@class,'purchase_price')]");

        public List<string> getNamePriceRealese(IWebDriver driver)
        {
            string gameName = driver.FindElement(_gameNameOnHisPage).Text;
            string gameRelease = driver.FindElement(_gameReleaseOnHisPAge).Text;
            string gamePrice = driver.FindElement(_gamePriceOnHisPage).Text;
            var result = new List<string>();
            result.Add(gameName);
            result.Add(gameRelease);
            result.Add(gamePrice);
            return result;
        }
    }
}
