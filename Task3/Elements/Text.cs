using Task3.Base;
using OpenQA.Selenium;

namespace Task3.Elements
{
    public class Text:BaseElement
    {
        public Text(By locator, string name) : base(locator, name) { }
    }
}
