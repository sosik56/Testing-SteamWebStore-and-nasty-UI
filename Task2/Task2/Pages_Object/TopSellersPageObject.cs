using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using Task2.Utility;

namespace Task2.Pages_Object
{
    class TopSellersPageObject
    {
        private By _topSellersLocator = By.XPath("//div[@id='additional_search_options']");
        private By enterTagField = By.XPath("//input[@id ='TagSuggest']");
        private By _getRequestNumberPath = By.XPath("//div[@class='search_results_count']");
        private By _getAmoutOfGameOnPage = By.XPath("//div[@id='search_resultsRows']/a");        

        private string checkBox = "//span[@data-value='";
        private string checkBoxEnd = "']//span[contains(@class,'checkbox')]";
        
        private string checkBoxForTags = "//span[@data-loc='";

        private string blockPart1 = "//div[@data-collapse-name ='";       
        private string blockPart2Close = "']";             

        private string IScheckedBox = "' and contains(@class,'checked')]";
        

        public bool atPage(IWebDriver driver)
        {
           return driver.FindElements(_topSellersLocator).Count>0;
        }
        public void clickFirstResault(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[@id='search_resultsRows']/a[1]")).Click();
        }

        public List<string> getFirstResualtNamePriceRealese(IWebDriver driver)
        {            
           string gameName =  driver.FindElement(By.XPath("//div[@id='search_resultsRows']/a[1]//span[@class='title']")).Text;            
           string gameReleaseDate = 
             driver.FindElement(By.XPath("//div[@id='search_resultsRows']/a[1]//div[contains(@class,'search_released')]")).Text;            
           string gamePrice =
             driver.FindElement(By.XPath("//div[@id='search_resultsRows']/a[1]//div[contains(@class,'search_price_discount')]")).Text;
            var result = new List<string>();
            result.Add(gameName);
            result.Add(gameReleaseDate);
            result.Add(gamePrice);
            return result;
        }

        

        public bool gameOnPageAreEqualwithTopNumber(IWebDriver driver,int waitingTime)
        {
            Expectations.WaitUntilVisible(driver, _getRequestNumberPath, waitingTime);
            string str = driver.FindElement(_getRequestNumberPath).Text;
            int amoutOfGameRef = driver.FindElements(_getAmoutOfGameOnPage).Count;
            int numberGamesAboveRef = utilityClass.getRidOfLettersAndSymbols(str);

            return amoutOfGameRef==numberGamesAboveRef;
        }        

        public int checkBoxs(IWebDriver driver , string blockName, List<string> listOfBox,int waitingTime)
        {
            int answer = 0;
            foreach (var item in listOfBox)
            {
                if (blockName=="tags")
                {
                   answer =+ checkBoxsForTags(item,driver, waitingTime);
                }
                else
                {
                    By boxValue = By.XPath($@"{checkBox}{item}{checkBoxEnd}");
                    //Expectations.WaitUntilVisible(driver, boxValue, 2);
                    if (!driver.FindElement(boxValue).Displayed)
                    {
                        By blockClose = By.XPath($@"{blockPart1}{blockName}{blockPart2Close}");
                        
                        driver.FindElement(blockClose).Click();
                    }
                    Expectations.WaitUntilVisible(driver, boxValue, waitingTime);
                    driver.FindElement(boxValue).Click();
                    By check = By.XPath($@"{checkBox}{item}{IScheckedBox}");
                    var isChecked = driver.FindElements(check).Count;
                    answer += isChecked;
                }                
            }            
            Thread.Sleep(400);//если без слипа то он слишком быстро все боксы отмечает и выдает неправильно число
            return answer;
        }  
        
        public int checkBoxsForTags(string boxValue, IWebDriver driver,int waitingTime)
        {            
            var element = driver.FindElement(enterTagField);
            element.SendKeys(boxValue);
            element.SendKeys(Keys.Enter);            
            By fullBoxValue = By.XPath($@"{checkBoxForTags}{boxValue}{blockPart2Close}");

            Expectations.WaitUntilCkicable(driver, fullBoxValue, waitingTime);
            driver.FindElement(fullBoxValue).Click();           
            By check = By.XPath($@"{checkBoxForTags}{boxValue}{IScheckedBox}");            
            return driver.FindElements(check).Count;            
        }
        
    }
}
