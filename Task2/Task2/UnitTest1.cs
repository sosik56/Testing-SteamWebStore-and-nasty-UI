using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using Task2.ForData;
using Task2.Models;
using Task2.Pages_Object;
using Task2.Utility;

namespace Task2
{    
    public class Tests
    {      
        private DataClass _dataTestCase2;
        private MarketAdvencedSearch _dataAdvancedSearch;
        private IWebDriver _driver;

        private GlobalHeaderPageObject _globalHeaderPage = new GlobalHeaderPageObject();
        private AboutPageObject _aboutPageObject = new AboutPageObject();
        private MainPageObject _mainPageObject = new MainPageObject();
        private StoreNavigationPageObject _storeNavigationPO = new StoreNavigationPageObject();
        private TopSellersPageObject _topSellersPO = new TopSellersPageObject();
        private GamePageObject _gamePageObject = new GamePageObject();
        private CommunityMarketPageObject _communityMarketPO = new CommunityMarketPageObject();
        private AdvancedSearchFormPO _advancedSearchFormPO = new AdvancedSearchFormPO();
        private ItemPageObject _itemPageObject = new ItemPageObject();              

        [OneTimeSetUp]
        public void InizializeData()
        {
            _dataTestCase2 = UtilityClass.DataTestCase2;
            _dataAdvancedSearch = UtilityClass.DataAdvancedSearch;
        }

        [SetUp]
        public void Setup()
        {             
            _driver = DriverSingltone.InizializeWebDriver();            
            _driver.Navigate().GoToUrl(UtilityClass.ConfigData.Host);           
        }

        [TearDown]
        public void End()
        {
            DriverSingltone.EndAndNull();
            _driver = null;
        }

        [Test]
        public void Test1()
        {
            Assert.True(_mainPageObject.IsPageOpen(),"Not main page");
            _globalHeaderPage.ClickAboutButton();
            Assert.True(_aboutPageObject.IsPageOpen(), "Not about page");
            Assert.True(_aboutPageObject.IsGamersOnlineMoreInGame(), "Compair was failed");
            _globalHeaderPage.ClickStoreButton();
            Assert.True(_mainPageObject.IsPageOpen(), "Not main page");
        }

        [Test]
        public void Test2()
        {
            Assert.True(_mainPageObject.IsPageOpen(), "Not main page");
            _storeNavigationPO.PopupMenuTopSellersClick();
            Assert.True(_topSellersPO.IsPageOpen(), "Not topsseler page");
            foreach (var item in _dataTestCase2.CheckBoxCategoryAndValue)
            {
                var expectedCheckedBox = item.Value.Count;
                int actual = _topSellersPO.CheckBoxs(item.Key, item.Value);
                Assert.AreEqual(expectedCheckedBox, actual, "Checkin box was failed");
            }
            
           Assert.True(_topSellersPO.IsGameOnPageAreEqualWithTopNumber(), 
               "Not equal amount ref games and top number");

            GameModel _onSearchingResualt = _topSellersPO.GetFirstResualtNamePriceRealese();
            _topSellersPO.ClickFirstResault();
            GameModel _onHisPage= _gamePageObject.GetNamePriceRealese();
            Assert.AreEqual(_onSearchingResualt.Name, _onHisPage.Name, "Note Equals Data");
            Assert.AreEqual(_onSearchingResualt.Price, _onHisPage.Price, "Note Equals Data");
            Assert.AreEqual(_onSearchingResualt.ReleaseDate, _onHisPage.ReleaseDate, "Note Equals Data");            
        }

        [Test]
        public void Test3()
        {
            Assert.True(_mainPageObject.IsPageOpen(), "Not main page");
            _globalHeaderPage.PoupMenuCommunityMarketClick();
            Assert.True(_communityMarketPO.IsPageOpen(),"Not Market Page");
            _communityMarketPO.ClickShowAdvancedMarket();
            Assert.True(_advancedSearchFormPO.IsAdvancedSearchFormVisibale(),"Not visibale SearchForm");
            _advancedSearchFormPO.EnterAdvancedSearchData(_dataAdvancedSearch);           
            Assert.True(_communityMarketPO.AreFiltersHere(_dataAdvancedSearch),"Not all filters was finded");
            Assert.True(_communityMarketPO.AreFirstFiveResultsContaisGolden(),"First 5 results not contains Golden");
            int amoutOfResults = _communityMarketPO.ReturnAmountOfResualts();
            _communityMarketPO.RemoveGoldenAndDotaFilters(_dataAdvancedSearch.InputForSearchField, _dataAdvancedSearch.GameName);
            Assert.AreNotEqual(amoutOfResults, _communityMarketPO.ReturnAmountOfResualts(),"amount of resualt the same");
            string firstResualtName = _communityMarketPO.GetFirstResualtName();
            _communityMarketPO.ClickFirstResult();
            Assert.AreEqual(firstResualtName,
                _itemPageObject.GetItemName(),"Name not the same");

            Assert.True(_itemPageObject.IsTypeOfItem(_dataAdvancedSearch.RareCheckBoxes[0]),
                "Item type's is not Immortal => filter not work");
            Assert.True(_itemPageObject.IsItemForWhom(_dataAdvancedSearch.HeroName),
                "Item is not for Lifestealer => filter not work");           
        }
        
    }
}