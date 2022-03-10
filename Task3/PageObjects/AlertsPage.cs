using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class AlertsPage:BaseForm
    {
        private Button _standartAllertButton = new Button(By.XPath("//button[@id='alertButton']"), "Standart Alert Button");
        private Button _confirmAllertButton = new Button(By.XPath("//button[@id='confirmButton']"), "Confirm Alert Button");
        private Button _promtAlertButton = new Button(By.XPath("//button[@id='promtButton']"), "Promt Alert Button");

        private Text _confirmSpan = new Text(By.XPath("//span[@id='confirmResult']"), "Confirm Span");
        private Text _promptSpan = new Text(By.XPath("//span[@id='promptResult']"), "Prompt Span");

        public AlertsPage() : base(new Button(By.XPath("//button[@id='alertButton']"), "Standart Alert Button"), "Alert Page") { }

        public void ClickStandartAlertButton()
        {
            _standartAllertButton.Click();
        }

        public void ClickConfirmAlertButton()
        {
            _confirmAllertButton.Click();
        }

        public void ClickPromtButton()
        {
            _promtAlertButton.Click();
        }

        public string GetConfirmSpanText()
        {
            return _confirmSpan.GetText();
        }

        public string GetPromptSpanText()
        {
            return _promptSpan.GetText();
        }
    }
}
