using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task3.Base;
using Task3.Utility;

namespace Task3.Elements
{
    public class DropList : BaseElement
    {
        public DropList(By xpath, string name) : base(xpath, name) { }

        public void SelectElementByValue(int value)
        {
            SelectElement selectElement = new SelectElement(DriverSinglton.InizializeWebDriver().FindElement(_locator));
            selectElement.SelectByValue(value.ToString());
            LogUtils.MakeSystemLog($"{_name} was taken value = {value.ToString()}");
        }       
    }
}
