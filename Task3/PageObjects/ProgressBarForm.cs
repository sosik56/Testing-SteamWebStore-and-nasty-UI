using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Utility;

namespace Task3.PageObjects
{
    public class ProgressBarForm : BaseForm
    {
        private Button _startStopButton = new Button(By.XPath("//button[@id='startStopButton']"),"Start/Stop Button");
        private Button _resetButton = new Button(By.XPath("//button[@id='resetButton']"), "Reset Button");
        private Text progressValue = new Text(By.XPath("//div[@id='progressBar']//div[@role='progressbar']"),"Proggres Value");        

        public ProgressBarForm() : base(new Text(By.XPath("//div[@id='progressBar']//div[@role='progressbar']"), "Proggres Value"),"Progress Bar Form") { }        

        public void ClickStartStopButton()
        {
            _startStopButton.Click();
        }

        public void ClickStartAndStopWhenValueApeears(int value)
        {
            if(value>100 || value < 0)
            {
                LogUtils.MakeSystemLog("The Value was incorrect. Method was break");
                return;
            }

            LogUtils.MakeSystemLog($"Progress bar will stop on {value}");
            string nowValue;           
            ClickStartStopButton();
            
            do
            {                
                nowValue = progressValue.GetAtribute("aria-valuenow");                
            }
            while (nowValue != value.ToString() || nowValue =="100");
            ClickStartStopButton();
        }

        public string GetProgressBarValue()
        {
           return progressValue.GetAtribute("aria-valuenow");
        }
    }
}
