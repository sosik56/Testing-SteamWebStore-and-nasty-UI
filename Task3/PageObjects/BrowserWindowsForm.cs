using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class BrowserWindowsForm : BaseForm
    {
        private  Button _newTabButton = new Button(By.XPath("//button[@id='tabButton']"), "New Tab Button");

        public BrowserWindowsForm() : base(new Button(By.XPath("//button[@id='tabButton']"), "New Tab Button"),"Browser Windows Form") { }

        public void ClickNewTabButton()
        {
            _newTabButton.Click();
        }
    }
}
