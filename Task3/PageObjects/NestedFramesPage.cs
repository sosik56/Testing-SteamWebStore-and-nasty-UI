using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class NestedFramesPage:BaseForm
    {
        private WebContent _parentFrameBody = new WebContent(By.XPath("//body"), "Perent Frame Body");
        private WebContent _childFrameParagraph = new WebContent(By.XPath("//body//p"), "Perent Frame Body");

        public NestedFramesPage(BaseElement elem, string namePage) : base(elem, namePage) { }

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
