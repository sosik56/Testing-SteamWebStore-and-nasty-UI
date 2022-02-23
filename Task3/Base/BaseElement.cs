using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task3.Utility;

namespace Task3.Base
{
    abstract public class BaseElement
    {
        protected By _Xpath;
        protected string _name;

        public BaseElement(By xpath, string nameElem)
        {
            _Xpath = xpath;
            _name = nameElem;
        }

        public IWebElement GetElement()
        {            
            Expectations.WaitUntilVisible(_Xpath);            
            return DriverSinglton.InizializeWebDriver().FindElement(_Xpath);
        }

        public int GetElements()
        {
            Expectations.WaitUntilVisible(_Xpath);
            return DriverSinglton.InizializeWebDriver().FindElements(_Xpath).Count;
        }
        
        public string GetAtribute(string nameAtt)
        {
            return GetElement().GetAttribute(nameAtt);
        }

        public bool IsVisible()
        {
           return GetElement().Displayed;
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
            Expectations.WaitUntilCkicable(_Xpath);
            GetElement().Click();
        }        
    }
}
