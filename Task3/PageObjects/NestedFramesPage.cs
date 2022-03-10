using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class NestedFramesPage:BaseForm
    {
        private Text _parentFrameBody = new Text(By.XPath("//body"), "Perent Frame Text");
        private Text _childFrameParagraph = new Text(By.XPath("//body//p"), "Child Frame Text");

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
