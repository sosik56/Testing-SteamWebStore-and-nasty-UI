using System.Linq;
using OpenQA.Selenium;
using Task2.Utility;

namespace Task2.Pages_Object
{
    class AboutPageObject
    {
        private  By _gamersOnline = By.XPath("//div[contains(@class,'gamers_online')]/ancestor::div[@class='online_stat']"); 
        private By _gamersInGame = By.XPath("//div[contains(@class,'gamers_in_game')]/ancestor::div[@class='online_stat']");
        

        public bool compairGamersOnlineMoreInGame(IWebDriver driver)
        {
            string gamersOnlineStrDirty = driver.FindElement(_gamersOnline).Text;
            string gamersInGameStrDirty = driver.FindElement(_gamersInGame).Text;            

            int gamersOnline = utilityClass.getRidOfLettersAndSymbols(gamersOnlineStrDirty);
            int gamersInGame = utilityClass.getRidOfLettersAndSymbols(gamersInGameStrDirty);
            return gamersOnline > gamersInGame;
        }

        public bool atPage(IWebDriver driver)
        {
            return driver.FindElements(_gamersInGame).Count()>0;
        }
                
    }
}
