using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class FramesPage:BaseForm
    {
        private Text _frameHeader = new Text(By.XPath("//h1[@id='sampleHeading']"), "Frame Header");
        
        public FramesPage() : base(new Text(By.XPath("//div[@class='main-header' and text()='Frames']"), "Frame Header"),"Frame Page") { }

        public string GetTextFromFrameHeader()
        {
           return _frameHeader.GetText();
        }
    }
}
