using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class NestedFramesPage:BaseForm
    {
        private Frame _parentFrameBody = new Frame(By.XPath("//body"), "Perent Frame Body");
        private Frame _childFrameParagraph = new Frame(By.XPath("//body//p"), "Perent Frame Body");

        public NestedFramesPage() : base(new Text(By.XPath("//div[@class='main-header' and text()='Nested Frames']"),
            "Header Nested Frame Page"), "Nested Frame Page") { }

        public string GetTextFromParentFrame()
        {
            return _parentFrameBody.GetText();            
        }

        public string GetTextFromChildFrame()
        {
            return _childFrameParagraph.GetText();            
        }
    }
}
