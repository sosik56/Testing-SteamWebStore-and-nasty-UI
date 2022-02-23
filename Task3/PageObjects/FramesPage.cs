using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class FramesPage:BaseForm
    {
        private WebContent _frameHeader = new WebContent(By.XPath("//h1[@id='sampleHeading']"), "Frame Header");
        
        public FramesPage(BaseElement elem, string namePage) : base(elem, namePage) { }

        public string GetTextFromFrameHeader()
        {
           return _frameHeader.GetText();
        }
    }
}
