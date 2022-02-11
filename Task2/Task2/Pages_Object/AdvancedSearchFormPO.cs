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


        public bool IsAdvancedSearchFormVisibale(IWebDriver driver, int waitSec)
        {
            Expectations.WaitUntilVisible(driver, advancedSearchFormVisibal, waitSec);
            return driver.FindElements(advancedSearchFormVisibal).Count > 0;
        }
        public void EnterAdvancedSearchData(MarketAdvencedSearch data, IWebDriver driver, int waitSec)
        {
            PickGame(driver, waitSec, data.GameName);
            PickHero(driver, waitSec, data.HeroName);
            PickRareCheckBoxes(driver, waitSec, data.RareCheckBoxes);
            EnterSearchValue(driver, data.InputForSearchField, waitSec);
            ClickSearchBtn(driver);
        }

        private void PickGame(IWebDriver driver, int waitSec, string gameName)
        {
            Expectations.WaitUntilCkicable(driver, gameMenuDropDown, waitSec);
            driver.FindElement(gameMenuDropDown).Click();
            Expectations.WaitUntilCkicable(driver, locatorForGame(gameName), waitSec);
            driver.FindElement(locatorForGame(gameName)).Click();
        }

        private void PickHero(IWebDriver driver, int waitSec,string heroName)
        {
            Expectations.WaitUntilCkicable(driver, categoryHero, waitSec);
            driver.FindElement(categoryHero).Click();
            Expectations.WaitUntilCkicable(driver, locatorForHero(heroName), waitSec);
            driver.FindElement(locatorForHero(heroName)).Click();
        }
        private void PickRareCheckBoxes(IWebDriver driver, int waitSec,List<string> checkBoxesName)
        {
            foreach (var item in checkBoxesName)
            {
                driver.FindElement(locatorRareCheckBoxs(item)).Click();
            }            
        }
        private void EnterSearchValue(IWebDriver driver, string value, int waitSec)
        {
            driver.FindElement(searchFild).SendKeys(value);
        }
        private void ClickSearchBtn(IWebDriver driver)
        {
            driver.FindElement(searchBtn).Click();
        }

    }
}
