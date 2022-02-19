using System.Collections.Generic;
using OpenQA.Selenium;
using Task2.Models;

namespace Task2.Pages_Object
{
    public class GamePageObject
    {
        private By _gameNameOnHisPage = By.Id("appHubAppName");
        private By _gameReleaseOnHisPAge = By.ClassName("date");
        private By _gamePriceOnHisPage = By.XPath("//div[contains(@class,'purchase_price')]");
        
        public GameModel GetNamePriceRealese()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            string gameName = driver.FindElement(_gameNameOnHisPage).Text;
            string gameRelease = driver.FindElement(_gameReleaseOnHisPAge).Text;
            string gamePrice = driver.FindElement(_gamePriceOnHisPage).Text;
            GameModel result = new GameModel() { Name = gameName, Price = gamePrice, ReleaseDate = gameRelease };            
            return result;
        }
    }
}
