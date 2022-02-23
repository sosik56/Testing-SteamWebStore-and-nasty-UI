using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class LinksPage:BaseForm
    {
        private Link _homeLink = new Link(By.XPath("//a[@id='simpleLink']"), "Home Link");
        public LinksPage(BaseElement elem, string namePage) : base(elem, namePage) { }

        public void ClickHomeLink()
        {
            _homeLink.Click();
        }
    }
}
