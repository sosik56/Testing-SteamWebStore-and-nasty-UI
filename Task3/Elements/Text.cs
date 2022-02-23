using Task3.Base;
using OpenQA.Selenium;

namespace Task3.Elements
{
    public class Text:BaseElement
    {
        public Text(By xpath, string name) : base(xpath, name) { }
    }
}
