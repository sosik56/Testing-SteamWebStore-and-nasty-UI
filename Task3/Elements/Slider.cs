using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task3.Base;
using Task3.Utility;

namespace Task3.Elements
{
    public class Slider:BaseElement
    {
        public Slider(By xpath, string name) : base(xpath, name) { }        

        public void MoveSliderByX(int xValue)
        {
            Actions action = new Actions(DriverSinglton.InizializeWebDriver());
            LogUtils.MakeSystemLog($"{_name} was  on {GetElement().Location.ToString()}");            
            action.DragAndDropToOffset(GetElement(), xValue, 0);            
            action.Perform();
            LogUtils.MakeSystemLog($"{_name} now  on {GetElement().Location.ToString()}");
        }
        
        public void MoveByOneToRight()
        {
            Actions action = new Actions(DriverSinglton.InizializeWebDriver());
            action.SendKeys(Keys.ArrowRight);
            action.Perform();            
        }
    }
}
