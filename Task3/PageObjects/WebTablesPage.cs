﻿using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Models;
using Task3.Utility;

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

        public WebTablesPage() : base(new Button(By.XPath("//button[@id='addNewRecordButton']"), "Add Button"),"WebTable Page") { }

        public void ClickAddButton()
        {
            _addButton.Click();
        }

        public bool IsUserInTable(User user)
        {
            return new Button(LocatorForDeletTheUserButton(user), "User Delet Button").GetElements() == 1;           
        }

        public void DeletTheUser(User user)
        {
            if (IsUserInTable(user))
            {
                LogUtils.MakeSystemLog($"User deleted {user.FirstName}  {user.LastName}");
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
