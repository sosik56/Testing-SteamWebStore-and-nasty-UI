using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task3.Base;
using Task3.Utility;

namespace Task3.Elements
{
    public class Slider:BaseElement
    {
        public Slider(By locator, string name) : base(locator, name) { }        

        public void MoveSliderByX(int xValue)
        {
            LogUtils.MakeSystemLog($"{_name} was  on {GetElement().Location.ToString()} and move by {xValue}");
            Actions action = new Actions(DriverSinglton.InizializeWebDriver());                        
            action.DragAndDropToOffset(GetElement(), xValue, 0);            
            action.Perform();            
        }
        
        public void MoveByOneToRight()
        {
            LogUtils.MakeSystemLog($"{_name} moved to right by 1");
            Actions action = new Actions(DriverSinglton.InizializeWebDriver());
            action.SendKeys(Keys.ArrowRight);
            action.Perform();            
        }
    }
}
