using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Models;

namespace Task3.PageObjects
{
    public class WebTablesPage : BaseForm
    {        
        private Button _addButton = new Button(By.XPath("//button[@id='addNewRecordButton']"), "Add Button");

        private By LocatorForAllDeletButtons = By.XPath("//span[contains(@id,'delete')]");
        private By LocatorForDeletTheUserButton(User user) =>
            By.XPath($"//div[@class='rt-tbody']//div[@role='row']/div[@role='gridcell' and text()='{user.FirstName}']" +
                $"/following-sibling::div[@role='gridcell' and text()='{user.LastName}']" +
                $"/following-sibling::div[@role='gridcell' and text()='{user.Age}']" +
                $"/following-sibling::div[@role='gridcell' and text()='{user.Email}']" +
                $"/following-sibling::div[@role='gridcell' and text()='{user.Salary}']" +
                $"/following-sibling::div[@role='gridcell' and text()='{user.Department}']" +
                $"/following-sibling::div[@role='gridcell']//span[contains(@id,'delete')]");

        public WebTablesPage(BaseElement elem, string namePage) : base(elem, namePage) { }

        public void ClickAddButton()
        {
            _addButton.Click();
        }

        public bool IsUserInTable(User user)
        {
             if(new Button(LocatorForDeletTheUserButton(user), "User Delet Button").GetElements() == 1)
             {
                return true;
             }
            return false;

        }
        public void DeletTheUser(User user)
        {
            if (IsUserInTable(user))
            {
                new Button(LocatorForDeletTheUserButton(user), "User Delet Button").Click();
            }

        }

        public int HowManyUsersInTable()
        {
            int amountOfUsers = new Button(LocatorForAllDeletButtons, "Delets Buttons").GetElements();
            return amountOfUsers;
        }
    }
}
