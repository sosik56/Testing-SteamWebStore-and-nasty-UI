using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using Task2.ForData;
using Task2.Pages_Object;

namespace Task2
{
    public class Tests
    {       
        private string _configJsonName = @"..\\..\\..\\Resourses\configJSON.json";
        private string _dataJsonName = @"..\\..\\..\\Resourses\data.json";       
        private string _pathToDataAdvancedSearch = @"..\\..\\..\\Resourses\jsonForAdvancedSearch.json";
        private ConfigClass _configData;
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

        private List<string> _onSearchingResualt;
        private List<string> _onHisPage;

        [OneTimeSetUp]
        public void InizializeData()
        {
            _configData = SerializeJson.DeSerializationDataFromFile<ConfigClass>(_configJsonName);
            _dataTestCase2 = SerializeJson.DeSerializationDataFromFile<DataClass>(_dataJsonName);
            _dataAdvancedSearch = SerializeJson.DeSerializationDataFromFile<MarketAdvencedSearch>(_pathToDataAdvancedSearch);
        }

        [SetUp]
        public void Setup()
        {             
            _driver = driverSingltone.InizializeWebDriver(_configData.BrowserType, _configData.Arguments);            
            _driver.Navigate().GoToUrl(_configData.Host);           
        }

        [TearDown]
        public void End()
        {
            driverSingltone.EndAndNull();
            _driver = null;
        }

        [Test]
        public void Test1()
        {
            Assert.True(_mainPageObject.IsPageOpen(_driver),"Not main page");

            _globalHeaderPage.ClickAboutButton(_driver);
            Assert.True(_aboutPageObject.IsPageOpen(_driver,_configData.WaitingTime), "Not about page");
            Assert.True(_aboutPageObject.IsGamersOnlineMoreInGame(_driver), "Compair was failed");

            _globalHeaderPage.ClickStoreButton(_driver);
            Assert.True(_mainPageObject.IsPageOpen(_driver), "Not main page");
        }

        [Test]
        public void Test2()
        {
            Assert.True(_mainPageObject.IsPageOpen(_driver), "Not main page");
            _storeNavigationPO.PopupMenuTopSellersClick(_driver,2);
            Assert.True(_topSellersPO.IsPageOpen(_driver), "Not topsseler page");
            foreach (var item in _dataTestCase2.CheckBoxCategoryAndValue)
            {
                var expectedCheckedBox = item.Value.Count;
                int actual = _topSellersPO.CheckBoxs(_driver, item.Key, item.Value, _configData.WaitingTime);
                Assert.AreEqual(expectedCheckedBox, actual, "Checkin box was failed");
            }
            
           Assert.True(_topSellersPO.IsGameOnPageAreEqualWithTopNumber(_driver,_configData.WaitingTime), 
               "Not equal amount ref games and top number");

            _onSearchingResualt = _topSellersPO.GetFirstResualtNamePriceRealese(_driver);
            _topSellersPO.ClickFirstResault(_driver);
            _onHisPage= _gamePageObject.GetNamePriceRealese(_driver);
            for (int i = 0; i < _onSearchingResualt.Count; i++)
            {
                Assert.AreEqual(_onSearchingResualt[i], _onHisPage[i], "Note Equals Data");
            }
        }

        [Test]
        public void Test3()
        {
            Assert.True(_mainPageObject.IsPageOpen(_driver), "Not main page");
            _globalHeaderPage.PoupMenuCommunityMarketClick(_driver, _configData.WaitingTime);
            Assert.True(_communityMarketPO.IsPageOpen(_driver, _configData.WaitingTime),"Not Market Page");
            _communityMarketPO.ClickShowAdvancedMarket(_driver, _configData.WaitingTime);
            Assert.True(_advancedSearchFormPO.IsAdvancedSearchFormVisibale(_driver, _configData.WaitingTime),"Not visibale SearchForm");
            _advancedSearchFormPO.EnterAdvancedSearchData(_dataAdvancedSearch, _driver, _configData.WaitingTime);           
            Assert.True(_communityMarketPO.AreFiltersHere(_driver, _dataAdvancedSearch),"Not all filters was finded");
            Assert.True(_communityMarketPO.AreFirstFiveResultsContaisGolden(_driver, _configData.WaitingTime),"First 5 results not contains Golden");
            int amoutOfResults = _communityMarketPO.ReturnAmountOfResualts(_driver);
            _communityMarketPO.RemoveGoldenAndDotaFilters(_driver, _dataAdvancedSearch.InputForSearchField, _dataAdvancedSearch.GameName);
            Assert.AreNotEqual(amoutOfResults, _communityMarketPO.ReturnAmountOfResualts(_driver),"amount of resualt the same");
            string firstResualtName = _communityMarketPO.GetFirstResualtName(_driver, _configData.WaitingTime);
            _communityMarketPO.ClickFirstResult(_driver);
            Assert.AreEqual(firstResualtName,
                _itemPageObject.GetItemName(_driver, _configData.WaitingTime),"Name not the same");

            Assert.True(_itemPageObject.IsTypeOfItem(_driver, _configData.WaitingTime, _dataAdvancedSearch.RareCheckBoxes[0]),
                "Item type's is not Immortal => filter not work");
            Assert.True(_itemPageObject.IsItemForWhom(_driver, _configData.WaitingTime, _dataAdvancedSearch.HeroName),
                "Item is not for Lifestealer => filter not work");           
        }
        
    }
}