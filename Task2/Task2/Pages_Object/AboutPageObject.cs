using System.Linq;
using OpenQA.Selenium;
using Task2.Utility;

namespace Task2.Pages_Object
{
    public class AboutPageObject
    {
        private  By _gamersOnline = By.XPath("//div[contains(@class,'gamers_online')]/ancestor::div[@class='online_stat']"); 
        private By _gamersInGame = By.XPath("//div[contains(@class,'gamers_in_game')]/ancestor::div[@class='online_stat']");
        
        public bool IsGamersOnlineMoreInGame(IWebDriver driver)
        {
            string gamersOnlineStrDirty = driver.FindElement(_gamersOnline).Text;
            string gamersInGameStrDirty = driver.FindElement(_gamersInGame).Text;            

            int gamersOnline = UtilityClass.GetRidOfLettersAndSymbols(gamersOnlineStrDirty);
            int gamersInGame = UtilityClass.GetRidOfLettersAndSymbols(gamersInGameStrDirty);
            return gamersOnline > gamersInGame;
        }

        public bool IsPageOpen(IWebDriver driver, int waitSec)
        {
            Expectations.WaitUntilVisible(driver, _gamersInGame, waitSec);
            return driver.FindElements(_gamersInGame).Count()>0;
        }                        
    }
}
