using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;

namespace Task3.PageObjects
{
    public class LeftPanel:BaseForm
    {
        private Button _alertButton = new Button(By.XPath("//span[text()='Alerts']"), "Alert Button");
        private Button _nestedFramesButton = new Button(By.XPath("//span[text()='Nested Frames']"), "Nested Frame Button");
        private Button _framesButton = new Button(By.XPath("//span[text()='Frames']"), "Frames Button");
        private Button _webTables = new Button(By.XPath("//span[text()='Web Tables']"), "Web Tables Button");
        private Button _browserWindows = new Button(By.XPath("//span[text()='Browser Windows']"),"Browser Windows Button");
        private Button _elementsButton = new Button(By.XPath("//div[text()='Elements']"), "Elements Windows Button");
        private Button _linksButton = new Button(By.XPath("//span[text()='Links']"), "Links Button");
        private Button _sliderButton = new Button(By.XPath("//span[text()='Slider']"), "Slider Button");
        private Button _progresBarButton = new Button(By.XPath("//span[text()='Progress Bar']"), "Progress Bar Button");
        private Button _datePickerButton = new Button(By.XPath("//span[text()='Date Picker']"), "Date Picker Button");
        private Button _uploadAndDownloadButton = new Button(By.XPath("//span[text()='Upload and Download']"), "Upload and Download Button");


        public LeftPanel() : base(new Button(By.XPath("//span[text()='Alerts']"), "Alert Button"),"Left Panel") { }

        public void ClickUploadAndDownload()
        {
            _uploadAndDownloadButton.Click();
        }

        public void ClickProgressBar()
        {
            _progresBarButton.Click();
        }

        public void ClickAlertButton()
        {
            _alertButton.Click();
        }

        public void ClickNestedFramesButton()
        {
            _nestedFramesButton.Click();
        }

        public void ClickFramesButton()
        {
            _framesButton.Click();
        }

        public void ClickWebTablesButton()
        {
            _webTables.Click();
        }

        public void ClickBrowserWindowsButton()
        {
            _browserWindows.Click();
        }

        public void ClickElementsButton()
        {
            _elementsButton.Click();
        }

        public void ClickLinksButton()
        {
            _linksButton.Click();
        }

        public void ClickSliderButton()
        {
            _sliderButton.Click();
        }

        public void ClickDatePickerButton()
        {
            _datePickerButton.Click();
        }
    }
}
