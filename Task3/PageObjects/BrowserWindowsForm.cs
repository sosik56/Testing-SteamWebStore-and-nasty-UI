using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class BrowserWindowsForm : BaseForm
    {
        private Button _newTabButton = new Button(By.XPath("//button[@id='tabButton']"), "New Tab Button");

        public BrowserWindowsForm(BaseElement elem, string namePage) : base(elem, namePage) { }

        public void ClickNewTabButton()
        {
            _newTabButton.Click();
        }
    }
}
