using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task3.Utility;

namespace Task3.Base
{
    public abstract class BaseElement
    {
        protected By _locator;
        protected string _name;

        protected BaseElement(By locator, string nameElem)
        {
            _locator = locator;
            _name = nameElem;
        }

        protected IWebElement GetElement()
        {            
            Expectations.WaitUntilVisible(_locator);            
            return DriverSinglton.InizializeWebDriver().FindElement(_locator);
        }

        public int GetElements()
        {
            Expectations.WaitUntilVisible(_locator);
            return DriverSinglton.InizializeWebDriver().FindElements(_locator).Count;
        }

        public string GetAtribute(string nameAtt)
        {           
            return GetElement().GetAttribute(nameAtt);
        }

        public bool IsVisible()
        {
            return GetElement().FindElements(_locator).Count > 0;
        }

        public string GetText()
        {
           return GetElement().Text;
        }

        public void MoveToElement()
        {
            Actions action = new Actions(DriverSinglton.InizializeWebDriver());            
            action.MoveToElement(GetElement());            
            action.Perform();
        }

        public void Click()
        {            
            LogUtils.MakeSystemLog($"{_name} was clicked");
            Expectations.WaitUntilCkicable(_locator);
            GetElement().Click();
        }        
    }
}
