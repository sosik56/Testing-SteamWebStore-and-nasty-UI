using System.Collections.Generic;
using OpenQA.Selenium;
using Task2.Models;
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
        private By LocatorForCloseBlock(string item) => By.XPath($"//div[@data-collapse-name='{item}']");        
        private By LocatorForCheckedBox(string item) => By.XPath($"//span[@data-value='{item}' and contains(@class,'checked')]");        
        private By LocatorForTagsCheckBox(string item) => By.XPath($"//span[@data-loc='{item}']");        
        private By LocatorForCheckedTagsBox(string item) => By.XPath($"//span[@data-loc='{item}' and contains(@class,'checked')]");        
        

        public bool IsPageOpen()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            return driver.FindElements(_topSellersLocator).Count>0;
        }
        public void ClickFirstResault()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            driver.FindElement(_firstResault).Click();
        }

        public GameModel GetFirstResualtNamePriceRealese()
        {
             IWebDriver driver = DriverSingltone.InizializeWebDriver();
             string gameName =  driver.FindElement(_gameName).Text;            
             string gameReleaseDate = driver.FindElement(_gameReleaseDate).Text;            
             string gamePrice = driver.FindElement(_gamePrice).Text;
             GameModel result = new GameModel() { Name = gameName, Price = gamePrice, ReleaseDate = gameReleaseDate };             
             return result;
        }        

        public bool IsGameOnPageAreEqualWithTopNumber()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilVisible(_getRequestNumberPath);
            string str = driver.FindElement(_getRequestNumberPath).Text;
            int amoutOfGameRef = driver.FindElements(_getAmoutOfGameOnPage).Count;
            int numberGamesAboveRef = UtilityClass.GetRidOfLettersAndSymbols(str);

            return amoutOfGameRef==numberGamesAboveRef;
        }        

        public int CheckBoxs(string blockName, List<string> listOfBox)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            int answer = 0;
            foreach (var item in listOfBox)
            {
                if (blockName=="tags")
                {
                   answer =+ CheckBoxsForTags(item);
                }
                else
                {
                    Expectations.WaitUntilVisible(LocatorForCheckBox(item));
                    if (!driver.FindElement(LocatorForCheckBox(item)).Displayed)
                    {
                        Expectations.WaitUntilCkicable(LocatorForCloseBlock(blockName));
                        driver.FindElement(LocatorForCloseBlock(blockName)).Click();
                    }

                    Expectations.WaitUntilVisible(LocatorForCheckBox(item));
                    driver.FindElement(LocatorForCheckBox(item)).Click();
                   
                    var isChecked = driver.FindElements(LocatorForCheckedBox(item)).Count;
                    answer += isChecked;
                    Expectations.WaitUntilVisible(_getRequestNumberPath);
                    Expectations.WaitUntilAllElementsVisible(_getAmoutOfGameOnPage);
                }                
            }           
            return answer;
        }  
        
        public int CheckBoxsForTags(string boxValue)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            var element = driver.FindElement(enterTagField);
            element.SendKeys(boxValue);
            element.SendKeys(Keys.Enter);
            element.SendKeys(Keys.Enter);

            By fullBoxValue = LocatorForTagsCheckBox(boxValue);
            element.SendKeys(Keys.Enter);
            Expectations.WaitUntilCkicable(fullBoxValue);
            element.SendKeys(Keys.Enter);
            driver.FindElement(fullBoxValue).Click();  
            
            By check = LocatorForCheckedTagsBox(boxValue);
            Expectations.WaitUntilCkicable(_tagInlineBlock);
            Expectations.WaitUntilAllElementsVisible(_getAmoutOfGameOnPage);
            return driver.FindElements(check).Count;            
        }        
    }
}
