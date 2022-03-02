using OpenQA.Selenium;
using Task3.Base;
using Task3.Utility;

namespace Task3.Elements
{
    public class TextField: BaseElement
    {
        public TextField(By xpath, string name) : base(xpath, name) { }

        public void SendText(string text)
        {
            LogUtils.MakeSystemLog($"Send to {_name} the text: {text}");
            Expectations.WaitUntilVisible(_locator);
            GetElement().SendKeys(text);
        }
    }
}
