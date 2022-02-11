using System.Collections.Generic;
using OpenQA.Selenium;
using Task2.Utility;

namespace Task2.Pages_Object
{
    public class TopSellersPageObject
    {
        private By _topSellersLocator = By.XPath("//div[@id='additional_search_options']");
        private By enterTagField = By.XPath("//input[@id ='TagSuggest']");
        private By _getRequestNumberPath = By.XPath("//div[@class='search_results_count']");
        private By _getAmoutOfGameOnPage = By.XPath("//div[@id='search_resultsRows']/a");
        private By _tagInlineBlock = By.XPath("//div[@id='searchtag_tmpl' and contains(@style,'inline-block')]");
        private By _firstResault = By.XPath("//div[@id='search_resultsRows']/a[1]");

        private By _gameName = By.XPath("//div[@id='search_resultsRows']/a[1]//span[@class='title']");
        private By _gameReleaseDate = By.XPath("//div[@id='search_resultsRows']/a[1]//div[contains(@class,'search_released')]");
        private By _gamePrice = By.XPath("//div[@id='search_resultsRows']/a[1]//div[contains(@class,'search_price_discount')]");

        private By LocatorForCheckBox(string item) => By.XPath($"//span[@Data-Value='{item}']//span[contains(@Class,'checkbox')]");        
        private By LocatorForCloseBlock(string item) => By.XPath($"//div[@data-collapse-name ='{item}']");        
        private By LocatorForCheckedBox(string item) => By.XPath($"//span[@data-value='{item}' and contains(@class,'checked')]");        
        private By LocatorForTagsCheckBox(string item) => By.XPath($"//span[@data-loc='{item}']");        
        private By LocatorForCheckedTagsBox(string item) => By.XPath($"//span[@data-loc='{item}' and contains(@class,'checked')]");        
        

        public bool IsPageOpen(IWebDriver driver)
        {
           return driver.FindElements(_topSellersLocator).Count>0;
        }
        public void ClickFirstResault(IWebDriver driver)
        {
            driver.FindElement(_firstResault).Click();
        }

        public List<string> GetFirstResualtNamePriceRealese(IWebDriver driver)
        {            
             string gameName =  driver.FindElement(_gameName).Text;            
             string gameReleaseDate = driver.FindElement(_gameReleaseDate).Text;            
             string gamePrice = driver.FindElement(_gamePrice).Text;
             var result = new List<string>();
             result.Add(gameName);
             result.Add(gameReleaseDate);
             result.Add(gamePrice);
             return result;
        }        

        public bool IsGameOnPageAreEqualWithTopNumber(IWebDriver driver,int waitingTime)
        {
            Expectations.WaitUntilVisible(driver, _getRequestNumberPath, waitingTime);
            string str = driver.FindElement(_getRequestNumberPath).Text;
            int amoutOfGameRef = driver.FindElements(_getAmoutOfGameOnPage).Count;
            int numberGamesAboveRef = UtilityClass.GetRidOfLettersAndSymbols(str);

            return amoutOfGameRef==numberGamesAboveRef;
        }        

        public int CheckBoxs(IWebDriver driver , string blockName, List<string> listOfBox,int waitingTime)
        {
            int answer = 0;
            foreach (var item in listOfBox)
            {
                if (blockName=="tags")
                {
                   answer =+ CheckBoxsForTags(item,driver, waitingTime);
                }
                else
                {
                    Expectations.WaitUntilVisible(driver, LocatorForCheckBox(item), waitingTime/2);
                    if (!driver.FindElement(LocatorForCheckBox(item)).Displayed)
                    {
                        Expectations.WaitUntilCkicable(driver, LocatorForCloseBlock(blockName), waitingTime);
                        driver.FindElement(LocatorForCloseBlock(blockName)).Click();
                    }

                    Expectations.WaitUntilVisible(driver, LocatorForCheckBox(item), waitingTime);
                    driver.FindElement(LocatorForCheckBox(item)).Click();
                   
                    var isChecked = driver.FindElements(LocatorForCheckedBox(item)).Count;
                    answer += isChecked;
                    Expectations.WaitUntilVisible(driver, _getRequestNumberPath, waitingTime);
                    Expectations.WaitUntilAllElementsVisible(driver, _getAmoutOfGameOnPage, waitingTime);
                }                
            }           
            return answer;
        }  
        
        public int CheckBoxsForTags(string boxValue, IWebDriver driver,int waitingTime)
        {            
            var element = driver.FindElement(enterTagField);
            element.SendKeys(boxValue);
            element.SendKeys(Keys.Enter);
            element.SendKeys(Keys.Enter);

            By fullBoxValue = LocatorForTagsCheckBox(boxValue);
            element.SendKeys(Keys.Enter);
            Expectations.WaitUntilCkicable(driver, fullBoxValue, waitingTime);
            element.SendKeys(Keys.Enter);
            driver.FindElement(fullBoxValue).Click();  
            
            By check = LocatorForCheckedTagsBox(boxValue);
            Expectations.WaitUntilCkicable(driver, _tagInlineBlock, waitingTime);
            Expectations.WaitUntilAllElementsVisible(driver, _getAmoutOfGameOnPage, waitingTime);
            return driver.FindElements(check).Count;            
        }        
    }
}
