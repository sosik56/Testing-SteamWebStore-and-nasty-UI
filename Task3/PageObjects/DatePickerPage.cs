using System;
using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Utility;

namespace Task3.PageObjects
{
    public class DatePickerPage : BaseForm
    {
        private TextField _selectDateField = new TextField(By.XPath("//input[@id='datePickerMonthYearInput']"), "Select date field");
        private TextField _dateAndTimeField = new TextField(By.XPath("//input[@id='dateAndTimePickerInput']"), "Date and Time field");
        private Button _nextMonth = new Button(By.XPath("//button[contains(@class,'next')]"),"Next month button");        

        private DropList _monthDropList = new DropList(By.XPath("//select[contains(@class,'month-select')]"), "Month drop List");
        private DropList _yearDropList = new DropList(By.XPath("//select[contains(@class,'year-select')]"), "Year drop List");
        private Text _currentMonthAndYear = new Text(By.XPath("//div[contains(@class,'current-month')]"),"Current month and year");

        private By _locatorForDay(string month, string day) 
            => By.XPath($"//div[contains(@class,'datepicker__month')]//div[contains(@aria-label,'{month}') and text()='{day}']");

        public DatePickerPage() : base(new TextField(By.XPath("//input[@id='dateAndTimePickerInput']"), "Date and Time field"),"Data Picker Page") { }

        public string GetSelectDateFieldValue()
        {
            return _selectDateField.GetAtribute("value");
        }

        public string GetDateAndTimeFieldValue()
        {
            return _dateAndTimeField.GetAtribute("value");
        }

        public void ClickSelectDateField()
        {
            _selectDateField.Click();
        }

        public void ClickNextMonthButton()
        {            
             _nextMonth.Click();                      
        }

        public void ClickMonthDropList()
        {
            _monthDropList.Click();
        }

        public void SelectMonth(int value)
        {
            value -= 1;  //month value starts with 0;
            _monthDropList.SelectElementByValue(value);
        }

        public void SelectYear(int value)
        {
            _yearDropList.SelectElementByValue(value);
        }

        public void PickDateUsingWindow(DateTime data)
        {
            SelectMonth(data.Month);
            SelectYear(data.Year);
            Button dayButton = new Button(_locatorForDay(GetCurrentMonth(),data.Day.ToString()),$"Day {data.Day} button");
            dayButton.Click();
        }

        public string GetCurrentMonth()
        {
           return UtilityClass.GetRidOfNumbers(_currentMonthAndYear.GetText());
        }        
    }
}
