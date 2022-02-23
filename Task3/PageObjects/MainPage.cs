using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class MainPage:BaseForm
    {
        private Button _alertFrameButton = new Button(By.XPath("//div[@class='card-body']/h5[text()[contains(.,'Alerts, Frame')]]"), "Alerts&Frame Button");
        private Button _elementsButton = new Button(By.XPath("//div[@class='card-body']/h5[text()[contains(.,'Elements')]]"), "Alerts&Frame Button");

        public MainPage(BaseElement elem, string namePage) : base(elem, namePage) { }

        public void ClickAlertFrameButton()
        {
            _alertFrameButton.Click();
        }

        public void ClickElementsButton()
        {
            _elementsButton.Click();
        }
    }
}
