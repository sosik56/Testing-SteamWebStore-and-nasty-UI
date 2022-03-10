using OpenQA.Selenium;
using Task3.Base;

namespace Task3.Elements
{
    public class Button:BaseElement
    {
        public Button(By locator, string name) : base(locator, name) { }
    }
}
