using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class SamplePage:BaseForm
    {
        public SamplePage() : base(new Text(By.XPath("//h1[@id='sampleHeading']"), "Sample Page Text"), "Sample Page") { }
    }
}
