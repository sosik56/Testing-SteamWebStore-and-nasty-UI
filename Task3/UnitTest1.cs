using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using Task3.Base;
using Task3.Elements;
using Task3.Models;
using Task3.PageObjects;
using Task3.Utility;

namespace Task3
{
    public class Tests : BaseTest
    {
        public static IEnumerable<TestCaseData> GetUserByIndx()
        {
            foreach (var item in UtilityClass.UsersData.Users)
            {
                yield return new TestCaseData(item);
            }                     
        }

        [Test]
        public void Test1()
        {
            MainPage mainPage = new MainPage(new WebContent(By.XPath("//div[@class ='home-content']"), "MainPage Content"), "Main Page");
            LeftPanel leftPanel = new LeftPanel(new WebContent(By.XPath("//div[@class ='left-pannel']"), "Left Panel Content"), "Left Panel");
            AlertsPage alertsPage = new AlertsPage(new WebContent(By.XPath("//div[contains(@id,'javascriptAlerts')]"), "Alerts Form"), "Alerts Page");

            LogUtils.MakeSystemLog("STEP 1");
            Assert.IsTrue(mainPage.IsPageOpen(), "Page is not open");

            LogUtils.MakeSystemLog("STEP 2");
            mainPage.ClickAlertFrameButton();
            leftPanel.ClickAlertButton();
            Assert.IsTrue(alertsPage.IsPageOpen(), "Page is not open");

            LogUtils.MakeSystemLog("STEP 3");
            alertsPage.ClickStandartAlertButton();
            Assert.AreEqual("You clicked a button", AlertUtility.GetTextFromAlert(), "Sentences are not equal");

            LogUtils.MakeSystemLog("STEP 4");
            AlertUtility.AcceptAlert();
            Assert.IsFalse(AlertUtility.IsThereAlert(), "There is ALERT");

            LogUtils.MakeSystemLog("STEP 5");
            alertsPage.ClickConfirmAlertButton();
            Assert.AreEqual("Do you confirm action?", AlertUtility.GetTextFromAlert(), "Sentences are not equal");

            LogUtils.MakeSystemLog("STEP 6");
            AlertUtility.AcceptAlert();
            Assert.IsFalse(AlertUtility.IsThereAlert(), "There is ALERT");
            Assert.AreEqual("You selected Ok", alertsPage.GetConfirmSpanText(), "Sentences are not equal");

            LogUtils.MakeSystemLog("STEP 7");
            alertsPage.ClickPromtButton();
            Assert.AreEqual("Please enter your name", AlertUtility.GetTextFromAlert(), "Sentences are not equal");

            LogUtils.MakeSystemLog("STEP 8");
            Assert.AreEqual($"You entered {AlertUtility.SendRandomStr()}", alertsPage.GetPromptSpanText());
            Assert.IsFalse(AlertUtility.IsThereAlert(), "There is ALERT");
        }

        [Test]
        public void Test2()
        {
            MainPage mainPage = new MainPage(new WebContent(By.XPath("//div[@class ='home-content']"), "MainPage Content"), "Main Page");
            LeftPanel leftPanel = new LeftPanel(new WebContent(By.XPath("//div[@class ='left-pannel']"), "Left Panel Content"), "Left Panel");
            NestedFramesPage nestedFramesPage = new NestedFramesPage(new WebContent(By.XPath("//div[@class='main-header' and text()='Nested Frames']")
                , "Header Nested Frame Page"), "Nested Frame Page");
            FramesPage framesPage = new FramesPage(new WebContent(By.XPath("//div[@class='main-header' and text()='Frames']"), "Header Frame Page"), "Frame Page");


            LogUtils.MakeSystemLog("STEP 1");
            Assert.IsTrue(mainPage.IsPageOpen(), "Page is not open");

            LogUtils.MakeSystemLog("STEP 2");
            mainPage.ClickAlertFrameButton();
            leftPanel.ClickNestedFramesButton();
            Assert.IsTrue(nestedFramesPage.IsPageOpen(), "Page is not open");

            FrameUtility.SwitchToFrameByID("frame1");
            Assert.AreEqual("Parent frame", nestedFramesPage.GetTextFromParentFrame(), "Parent Frame sentencses are not equal");
            FrameUtility.SwitchToNextCHildFrame();
            Assert.AreEqual("Child Iframe", nestedFramesPage.GetTextFromChildFrame(), "Child Frame sentencses are not equal");
            FrameUtility.ReturnToDefault();

            LogUtils.MakeSystemLog("STEP 3");
            leftPanel.ClickFramesButton();
            Assert.IsTrue(framesPage.IsPageOpen(), "Page is not open");

            FrameUtility.SwitchToFrameByID("frame1");
            string frame1Str = framesPage.GetTextFromFrameHeader();
            FrameUtility.ReturnToDefault();
            FrameUtility.SwitchToFrameByID("frame2");
            string frame2Str = framesPage.GetTextFromFrameHeader();
            Assert.AreEqual(frame1Str, frame2Str, "Sentences are not equal");
        }                    
       
        
        [TestCaseSource("GetUserByIndx")]
        public void Test3(User user)
        {           
            MainPage mainPage = new MainPage(new WebContent(By.XPath("//div[@class ='home-content']"), "MainPage Content"), "Main Page");
            LeftPanel leftPanel = new LeftPanel(new WebContent(By.XPath("//div[@class ='left-pannel']"), "Left Panel Content"), "Left Panel");
            WebTablesPage webTables = new WebTablesPage(new WebContent(By.XPath("//div[@class='web-tables-wrapper']"), "Web Tables Content"), "Web Tables");
            RegistrationForm registrationForm = new RegistrationForm(new WebContent(By.XPath("//form[@id='userForm']"), "Registration Form Content"), "Registration Form");

            LogUtils.MakeSystemLog("STEP 1");
            Assert.IsTrue(mainPage.IsPageOpen(), "Page is not open");

            LogUtils.MakeSystemLog("STEP 2");
            mainPage.ClickElementsButton();
            leftPanel.ClickWebTablesButton();
            Assert.IsTrue(webTables.IsPageOpen(), "Page is not Open");

            LogUtils.MakeSystemLog("STEP 3");
            webTables.ClickAddButton();
            Assert.IsTrue(registrationForm.IsPageOpen(), "Registration Form is not open");

            LogUtils.MakeSystemLog("STEP 4");
            registrationForm.FillTheForm(user);
            registrationForm.ClickSubmitButton();
            Assert.IsTrue(webTables.IsUserInTable(user), "There is no such user");

            LogUtils.MakeSystemLog("STEP 5");
            int amountOfUserBeforeDelet =  webTables.HowManyUsersInTable();
            webTables.DeletTheUser(user);
            Assert.IsFalse(webTables.IsUserInTable(user), "Ther is the user");
            int amountOfUsersAfterDelet = webTables.HowManyUsersInTable();
            Assert.AreNotEqual(amountOfUserBeforeDelet,amountOfUsersAfterDelet, "Amounts are equal");            
        }        

        [Test]
        public void Test4()
        {
            MainPage mainPage = new MainPage(new WebContent(By.XPath("//div[@class ='home-content']"), "MainPage Content"), "Main Page");
            LeftPanel leftPanel = new LeftPanel(new WebContent(By.XPath("//div[@class ='left-pannel']"), "Left Panel Content"), "Left Panel");
            BrowserWindowsForm browserWindowsForm = new BrowserWindowsForm(new WebContent(By.XPath("//div[@id='browserWindows']")
                ,"Browser Windows Content"), "Browser Windows Page");
            SamplePage samplePage = new SamplePage(new Text(By.XPath("//h1[@id='sampleHeading']"),"Sample Page Text"),"Sample Page");
            LinksPage linksPage = new LinksPage(new WebContent(By.XPath("//div[@id='linkWrapper']"), "Links Forms"), "Links Page");
                       
            LogUtils.MakeSystemLog("STEP 1");            
            Assert.IsTrue(mainPage.IsPageOpen(), "Main Page is not open");

            LogUtils.MakeSystemLog("STEP 2");
            mainPage.ClickAlertFrameButton();
            leftPanel.ClickBrowserWindowsButton();
            Assert.IsTrue(browserWindowsForm.IsPageOpen(), "Browser Windows page is not open");

            LogUtils.MakeSystemLog("STEP 3");
            int beforeClickAmountOfTabs = DriverSinglton.CountOfTabs();
            browserWindowsForm.ClickNewTabButton();
            int afterClickAmountOfTabs = DriverSinglton.CountOfTabs();
            Assert.IsTrue(afterClickAmountOfTabs == beforeClickAmountOfTabs+1, "The amount of tabs is not correct");
            DriverSinglton.SwitchToTheTabByIndx(1);
            string tabUrl = DriverSinglton.GetUrl();            
            Assert.IsTrue(tabUrl.Contains("/sample"), "Not /sample TAB");
            Assert.IsTrue(samplePage.IsPageOpen(), "Sample Page page is not open");            

            LogUtils.MakeSystemLog("STEP 4");
            DriverSinglton.CloseCurrentTab();
            DriverSinglton.SwitchToTheTabByIndx(0);
            Assert.IsTrue(browserWindowsForm.IsPageOpen(), "Browser Windows page is not open");
            
            LogUtils.MakeSystemLog("STEP 5");
            leftPanel.ClickElementsButton();
            leftPanel.ClickLinksButton();
            Assert.IsTrue(linksPage.IsPageOpen(), "Browser Windows page is not open");
            
            LogUtils.MakeSystemLog("STEP 6");
            beforeClickAmountOfTabs = DriverSinglton.CountOfTabs();
            linksPage.ClickHomeLink();
            afterClickAmountOfTabs = DriverSinglton.CountOfTabs();
            Assert.IsTrue(afterClickAmountOfTabs == beforeClickAmountOfTabs+1, "The amount of tabs is not correct");
            DriverSinglton.SwitchToTheTabByIndx(1);            
            Assert.IsTrue(mainPage.IsPageOpen(), "Main Page is not open");
            
            LogUtils.MakeSystemLog("STEP 7");
            DriverSinglton.SwitchToTheTabByIndx(0);
            Assert.IsTrue(linksPage.IsPageOpen(), "Browser Windows page is not open");            
        }
    }
}