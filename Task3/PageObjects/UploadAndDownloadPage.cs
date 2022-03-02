using System;
using System.IO;
using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Utility;

namespace Task3.PageObjects
{
    public class UploadAndDownloadPage: BaseForm
    {
        private TextField _uploadFile = new TextField(By.XPath("//input[@id='uploadFile']"), "Upload Button");
        private Button _downloadButton = new Button(By.Id("downloadButton"), "Download Button");
        private Text _uploadFilePath = new Text(By.Id("uploadedFilePath"),"Upload Path");

        public UploadAndDownloadPage() : base(new TextField(By.XPath("//input[@id='uploadFile']"), "Upload Button"), "Upload and Download page") { }

        public void SendUpload(string text)
        {
            _uploadFile.SendText(text);
        }

        public void ClickDownloadButton()
        {
            _downloadButton.Click();
            Expectations.WaitUntilDownload(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,GetDownloadAttFromButton()));
        }

        public string GetDownloadAttFromButton()
        {            
            return _downloadButton.GetAtribute("download");
        }

        public string GetUploadFilePatheText()
        {
            return _uploadFilePath.GetText();
        }


    }
}
