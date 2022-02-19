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


        public bool IsPageOpen()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilVisible(atPageLocator);
            return driver.FindElements(atPageLocator).Count > 0;
        } 
        public void ClickShowAdvancedMarket()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilCkicable(showAdvancedMarket);
            driver.FindElement(showAdvancedMarket).Click();
        }        

        public bool AreFiltersHere(MarketAdvencedSearch data)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
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

        public bool AreFirstFiveResultsContaisGolden()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            string str;
            int answer = 0;
            for (int i = 0; i < 5; i++)
            {
                Expectations.WaitUntilVisible(SearchResualt(i.ToString()));
                str = driver.FindElement(SearchResualt(i.ToString())).Text;
                if (str.Contains("Golden"))
                    answer++;
            }
            return answer == 5;
        }
       
        public int ReturnAmountOfResualts()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            return driver.FindElements(serchResults).Count;
        }
        public void RemoveGoldenAndDotaFilters(params string[] parameters)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            foreach (var item in parameters)
            {
                driver.FindElement(RemoveFilter(item)).Click();
            }            
        }
        public string GetFirstResualtName()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilVisible(firstResult);
            return driver.FindElement(firstResult).Text;
        }               

        public void ClickFirstResult()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            driver.FindElement(firstResult).Click();
        }       

    }
}
