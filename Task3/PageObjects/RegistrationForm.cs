using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Models;

namespace Task3.PageObjects
{
    public class RegistrationForm:BaseForm
    {
        private Button _submitButton = new Button(By.XPath("//button[@id='submit']"), "Add Button");

        private TextField _firstNameField = new TextField(By.XPath("//input[@id='firstName']"),"First Name Field");
        private TextField _lastNameField = new TextField(By.XPath("//input[@id='lastName']"), "Last Name Field");
        private TextField _emailField = new TextField(By.XPath("//input[@id='userEmail']"), "Email Field");
        private TextField _ageField = new TextField(By.XPath("//input[@id='age']"), "Age Field");
        private TextField _salaryField = new TextField(By.XPath("//input[@id='salary']"), "Salary Field");
        private TextField _departmentField = new TextField(By.XPath("//input[@id='department']"), "Department Field");

        public RegistrationForm(BaseElement elem, string namePage) : base(elem, namePage) { }

        public void ClickSubmitButton()
        {
            _submitButton.Click();
        }

        public void FillTheForm(User user)
        {
            SendTextToFirstNameField(user.FirstName);
            SendTextToLastNameField(user.LastName);
            SendTextToEmailField(user.Email);
            SendTextToAgeField(user.Age);
            SendTextToSalaryField(user.Salary);
            SendTextToDepartmentField(user.Department);
        }

        public void SendTextToFirstNameField(string text)
        {
            _firstNameField.SendText(text);
        }

        public void SendTextToLastNameField(string text)
        {
            _lastNameField.SendText(text);
        }

        public void SendTextToEmailField(string text)
        {
            _emailField.SendText(text);
        }

        public void SendTextToAgeField(string text)
        {
            _ageField.SendText(text);
        }

        public void SendTextToSalaryField(string text)
        {
            _salaryField.SendText(text);
        }

        public void SendTextToDepartmentField(string text)
        {
            _departmentField.SendText(text);
        }
    }
}
