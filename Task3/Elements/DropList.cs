using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task3.Base;
using Task3.Utility;

namespace Task3.Elements
{
    public class DropList : BaseElement
    {
        public DropList(By locator, string name) : base(locator, name) { }

        public void SelectElementByValue(int value)
        {
            LogUtils.MakeSystemLog($"{_name} was taken value = {value.ToString()}");
            SelectElement selectElement = new SelectElement(GetElement());
            selectElement.SelectByValue(value.ToString());            
        }       
    }
}
