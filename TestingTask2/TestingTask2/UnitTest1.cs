using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestingTask2
{    

    public class Tests
    {
        private IWebDriver _driver;
        ChromeOptions chromeOptions = new ChromeOptions();

        private By _headder = By.CssSelector(".example h3");
        private By _nameElementsTable1 = By.XPath("//table[@id='table1']//tr//td[2]"); //***
        private By _tableHeader = By.XPath("//table[@id='table1']//th");
        private By _addButton = By.XPath("//button[text()='Add Element']");
        private By _deletButton = By.XPath("//button[text()='Delet']");

        private string _nameElementsStr = "//table[@id='table1']//tr//td";
        private string _tableHeadderStr = "//table[@id='table1']//th";

        private int colFirstName = 0;
        private string colName = "First Name";

        private int _expectedHeader = 1;
        private int _expectedHeaderElements = 4;
        private int _expectedAddButton = 1;
        private int _expectedDeletButton = 0;

        [SetUp]
        public void Setup()
        {
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            _driver = new ChromeDriver(chromeOptions);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
            var actualHeader = _driver.FindElements(_headder).Count;
            var numberHeader = _driver.FindElements(_tableHeader).Count;

            string str;
            for (int i = 1; i < numberHeader+1; i++)
            {
                str = _driver.FindElement(By.XPath(_tableHeadderStr + "[" + i + "]//span")).Text;
                if (str == colName)
                {
                    colFirstName = i;
                    return;
                }
            }
            
            var actuealNameElements = _driver.FindElements(By.XPath(_nameElementsStr + "[" + colFirstName + "]")).Count;        

            Assert.AreEqual(_expectedHeader,actualHeader,"Header is not equal");
            Assert.AreEqual(_expectedHeaderElements, actuealNameElements, "Names are not equal");
        }   
        
        [Test]
        public void Test2()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

            var actualAbbButon = _driver.FindElements(_addButton).Count;
            var actualDeletButton = _driver.FindElements(_deletButton).Count;

            Assert.AreEqual(_expectedAddButton, actualAbbButon, "There is no Add Button");
            Assert.AreEqual(_expectedDeletButton, actualDeletButton, "There is Delet Button");
        }

        [TearDown]
        public void End()
        {
            _driver.Quit();
        }
    }
}