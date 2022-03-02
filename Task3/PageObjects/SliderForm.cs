using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Utility;

namespace Task3.PageObjects
{
    public class SliderForm : BaseForm
    {
        private Slider _mainSlider = new Slider(By.XPath("//input[@type='range']"), "Slider on Form");
        private TextField _sliderTextField = new TextField(By.XPath("//input[@id='sliderValue']"), "Slider Text Field");

        public SliderForm() : base(new Slider(By.XPath("//input[@type='range']"), "Slider on Form"),"Slider Form") { }

        public void MoveSliderByX(int xValue)
        {
            _mainSlider.MoveSliderByX(xValue);
        }       
        
        public void MoveToRightByOneMS()
        {
            _mainSlider.MoveByOneToRight();
        }

        public void SetSliderValue(int value)
        {
            if(value>100 || value < 0)
            {
                LogUtils.MakeSystemLog("Uncorrect value! Value must be from 0 to 100");
            }            

            while(_mainSlider.GetAtribute("value") != value.ToString())
            {
                MoveToRightByOneMS();
            }
        }

        public string GetSliderValue()
        {
            return _sliderTextField.GetAtribute("value");
        }
    }
}
