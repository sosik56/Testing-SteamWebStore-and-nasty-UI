using OpenQA.Selenium;
using Task2.ForData;

namespace Task2.Pages_Object
{
    public class CommunityMarketPageObject
    {   
        private By SearchResualt(string item) => By.XPath($"//span[contains(@id,'result_{item}')]");        

        private By atPageLocator = By.Id("popularItemsRows");
        private By showAdvancedMarket = By.Id("market_search_advanced_show");      
        private By firstResult = By.Id("result_0_name"); 
        private By IsFilterHere(string filterName) =>
            By.XPath($"//div[contains(@class,'search_results')]//a[text()[contains(.,'{filterName}')]]");
        private By RemoveFilter(string filterName) =>
            By.XPath($"//div[contains(@class,'search_results')]//a[text()[contains(.,'{filterName}')]]/span");    
        private By serchResults = By.XPath("//span[contains(@id,'result')]");    


        public bool IsPageOpen(IWebDriver driver,int waitSec)
        {
            Expectations.WaitUntilVisible(driver, atPageLocator, waitSec);
            return driver.FindElements(atPageLocator).Count > 0;
        } 
        public void ClickShowAdvancedMarket(IWebDriver driver, int waitSec)
        {
            Expectations.WaitUntilCkicable(driver, showAdvancedMarket, waitSec);
            driver.FindElement(showAdvancedMarket).Click();
        }        

        public bool AreFiltersHere(IWebDriver driver, MarketAdvencedSearch data)
        {
            int iteration = 3;
            int numb = 0;
            numb += driver.FindElements(IsFilterHere(data.GameName)).Count;           
            numb += driver.FindElements(IsFilterHere(data.HeroName)).Count;
            numb += driver.FindElements(IsFilterHere(data.InputForSearchField)).Count;
            foreach (var item in data.RareCheckBoxes)
            {
                numb += driver.FindElements(IsFilterHere(item)).Count;
                iteration++;
            }            
            return numb == iteration;
        }

        public bool AreFirstFiveResultsContaisGolden(IWebDriver driver, int waitSec)
        {
            string str;
            int answer = 0;
            for (int i = 0; i < 5; i++)
            {
                Expectations.WaitUntilVisible(driver, SearchResualt(i.ToString()), waitSec);
                str = driver.FindElement(SearchResualt(i.ToString())).Text;
                if (str.Contains("Golden"))
                    answer++;
            }
            return answer == 5;
        }
       
        public int ReturnAmountOfResualts(IWebDriver driver)
        {
           return driver.FindElements(serchResults).Count;
        }
        public void RemoveGoldenAndDotaFilters(IWebDriver driver, params string[] parameters)
        {
            foreach (var item in parameters)
            {
                driver.FindElement(RemoveFilter(item)).Click();
            }            
        }
        public string GetFirstResualtName(IWebDriver driver,int waitSec)
        {
            Expectations.WaitUntilVisible(driver, firstResult, waitSec);
            return driver.FindElement(firstResult).Text;
        }               

        public void ClickFirstResult(IWebDriver driver)
        {
            driver.FindElement(firstResult).Click();
        }       

    }
}
