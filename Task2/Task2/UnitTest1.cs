using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using Task2.ForData;
using Task2.Pages_Object;



namespace Task2
{
    public class Tests
    {
        private string _configJsonName = "configJSON.json";
        private string _dataJsonName = "data.json";
        private ConfigClass _configData;
        private DataClass _data;

        private IWebDriver _driver;

        private GlobalHeaderPageObject _globalHeaderPage = new GlobalHeaderPageObject();
        private AboutPageObject _aboutPageObject = new AboutPageObject();
        private MainPageObject _mainPageObject = new MainPageObject();
        private StoreNavigationPageObject _storeNavigationPO = new StoreNavigationPageObject();
        private TopSellersPageObject _topSellersPO = new TopSellersPageObject();
        private GamePageObject _gamePageObject = new GamePageObject();

        private List<string> _onSearchingResualt;
        private List<string> _onHisPage;

        [OneTimeSetUp]
        public void InizializeData()
        {
            SerializeJson.serializeConfigClass(_configJsonName, out _configData);
            SerializeJson.serializeConfigClass(_dataJsonName, out _data);            
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
        }

        [Test]
        public void Test1()
        {
            Assert.True(_mainPageObject.atPage(_driver),"Not main page");

            _globalHeaderPage.clickAboutButton(_driver);
            Assert.True(_aboutPageObject.atPage(_driver), "Not about page");
            Assert.True(_aboutPageObject.compairGamersOnlineMoreInGame(_driver), "Compair was failed");

            _globalHeaderPage.clickStoreButton(_driver);
            Assert.True(_mainPageObject.atPage(_driver), "Not main page");
        }

        [Test]
        public void Test2()
        {
            Assert.True(_mainPageObject.atPage(_driver), "Not main page");
            _storeNavigationPO.popupMenuTopSellersClick(_driver,2);
            Assert.True(_topSellersPO.atPage(_driver), "Not topsseler page");
            foreach (var item in _data.checkBoxCategoryAndValue)
            {
                var expectedCheckedBox = item.Value.Count;
                int actual = _topSellersPO.checkBoxs(_driver, item.Key, item.Value, _configData.waitingTime);
                Assert.AreEqual(expectedCheckedBox, actual, "Checkin box was failed");
            }
            
           Assert.True(_topSellersPO.gameOnPageAreEqualwithTopNumber(_driver,_configData.waitingTime), 
               "Not equal amount ref games and top number");

            _onSearchingResualt = _topSellersPO.getFirstResualtNamePriceRealese(_driver);
            _topSellersPO.clickFirstResault(_driver);
            _onHisPage= _gamePageObject.getNamePriceRealese(_driver);
            for (int i = 0; i < _onSearchingResualt.Count; i++)
            {
                Assert.AreEqual(_onSearchingResualt[i], _onHisPage[i], "Note Equals Data");
            }

        }

        
    }
}