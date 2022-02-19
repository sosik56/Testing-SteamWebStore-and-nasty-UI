using System.Collections.Generic;
using OpenQA.Selenium;
using Task2.ForData;

namespace Task2.Pages_Object
{
    public class AdvancedSearchFormPO
    {       
        private By locatorForGame(string gameName) =>
            By.XPath($"//div[contains(@id,'app_option')]//img[contains(@alt,'{gameName}')]");
        private By locatorForHero(string heroName) =>
            By.XPath($"//div[@id='market_advancedsearch_filters']//option[text()='{heroName}']");       
        private By locatorRareCheckBoxs(string checkBoxName) =>
            By.XPath($"//input[contains(@id,'{checkBoxName}')]");      

        private By advancedSearchFormVisibal = By.Id("market_advancedsearch_dialog");
        private By gameMenuDropDown = By.Id("market_advancedsearch_appselect");
        private By searchFild = By.Id("advancedSearchBox");
        private By categoryHero = By.XPath("//div[@id='market_advancedsearch_filters']//select[contains(@name,'Hero')]");
        private By searchBtn = By.XPath("//div[@id='market_advancedsearch_dialog']//div[contains(@class,'btn')]");


        public bool IsAdvancedSearchFormVisibale()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilVisible(advancedSearchFormVisibal);
            return driver.FindElements(advancedSearchFormVisibal).Count > 0;
        }
        public void EnterAdvancedSearchData(MarketAdvencedSearch data)
        {
            PickGame(data.GameName);
            PickHero(data.HeroName);
            PickRareCheckBoxes(data.RareCheckBoxes);
            EnterSearchValue(data.InputForSearchField);
            ClickSearchBtn();
        }

        private void PickGame(string gameName)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilCkicable(gameMenuDropDown);
            driver.FindElement(gameMenuDropDown).Click();
            Expectations.WaitUntilCkicable(locatorForGame(gameName));
            driver.FindElement(locatorForGame(gameName)).Click();
        }

        private void PickHero(string heroName)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            Expectations.WaitUntilCkicable(categoryHero);
            driver.FindElement(categoryHero).Click();
            Expectations.WaitUntilCkicable(locatorForHero(heroName));
            driver.FindElement(locatorForHero(heroName)).Click();
        }
        private void PickRareCheckBoxes(List<string> checkBoxesName)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            foreach (var item in checkBoxesName)
            {
                driver.FindElement(locatorRareCheckBoxs(item)).Click();
            }            
        }
        private void EnterSearchValue(string value)
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            driver.FindElement(searchFild).SendKeys(value);
        }
        private void ClickSearchBtn()
        {
            IWebDriver driver = DriverSingltone.InizializeWebDriver();
            driver.FindElement(searchBtn).Click();
        }

    }
}
