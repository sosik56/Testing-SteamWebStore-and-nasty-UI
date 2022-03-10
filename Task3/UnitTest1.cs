using System.Collections.Generic;
using NUnit.Framework;
using Task3.Base;
using Task3.Models;
using Task3.PageObjects;
using Task3.Utility;
using System;
using System.Globalization;
using System.Threading;
using System.IO;


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
            MainPage mainPage = new MainPage();
            LeftPanel leftPanel = new LeftPanel();
            AlertsPage alertsPage = new AlertsPage();
           
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
            Assert.AreEqual($"You entered {AlertUtility.SendStrToAlert(UtilityClass.GetRandomGuid())}", alertsPage.GetPromptSpanText(),"Not equal value");
            Assert.IsFalse(AlertUtility.IsThereAlert(), "There is ALERT");
        }

        [Test]
        public void Test2()
        {
            MainPage mainPage = new MainPage();
            LeftPanel leftPanel = new LeftPanel();
            NestedFramesPage nestedFramesPage = new NestedFramesPage();
            FramesPage framesPage = new FramesPage();

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
            MainPage mainPage = new MainPage();
            LeftPanel leftPanel = new LeftPanel();
            WebTablesPage webTables = new WebTablesPage();
            RegistrationForm registrationForm = new RegistrationForm();

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
            MainPage mainPage = new MainPage();
            LeftPanel leftPanel = new LeftPanel();
            BrowserWindowsForm browserWindowsForm = new BrowserWindowsForm();
            SamplePage samplePage = new SamplePage();
            LinksPage linksPage = new LinksPage();
                       
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

        [Test]
        public void Test5()
        {
            MainPage mainPage = new MainPage();
            LeftPanel leftPanel = new LeftPanel();
            ProgressBarForm progressBar = new ProgressBarForm();
            SliderForm sliderForm = new SliderForm();

            LogUtils.MakeSystemLog("STEP 1");
            Assert.IsTrue(mainPage.IsPageOpen(), "Main Page is not open");

            LogUtils.MakeSystemLog("STEP 2");
            mainPage.ClickWidgetsButton();
            leftPanel.ClickSliderButton();
            Assert.IsTrue(sliderForm.IsPageOpen(), "Slider Form is not open");

            LogUtils.MakeSystemLog("STEP 3");            
            sliderForm.MoveSliderByX(-2000);
            int rndInt = UtilityClass.GetRandomInt(0, 100);
            sliderForm.SetSliderValue(rndInt);
            Assert.IsTrue(rndInt.ToString() == sliderForm.GetSliderValue(), "Not equal value");

            LogUtils.MakeSystemLog("STEP 4");
            leftPanel.ClickProgressBar();
            Assert.IsTrue(progressBar.IsPageOpen(), "ProgressBar Form is not open");

            LogUtils.MakeSystemLog("STEP 5");
            progressBar.ClickStartAndStopWhenValueApeears(Convert.ToInt32(UtilityClass.ReturnValue(UtilityClass.data, "age")));
            Assert.AreEqual(UtilityClass.ReturnValue(UtilityClass.data, "age"), progressBar.GetProgressBarValue(), "Not equal age");            
        }

        [Test]
        public void Test6()
        {
            MainPage mainPage = new MainPage();
            LeftPanel leftPanel = new LeftPanel();
            DatePickerPage datePickerPage = new DatePickerPage();

            LogUtils.MakeSystemLog("STEP 1");
            Assert.IsTrue(mainPage.IsPageOpen(), "Main Page is not open");

            LogUtils.MakeSystemLog("STEP 2");
            mainPage.ClickWidgetsButton();
            leftPanel.ClickDatePickerButton();
            Assert.IsTrue(datePickerPage.IsPageOpen(), "DatePicker page is not open");
            var culture = new CultureInfo("en-US");           
            string date = UtilityClass.GetDateTimeNow().ToString("MM/dd/yyyy",culture);
            string dateWithTime = UtilityClass.GetDateTimeNow().ToString("MMMM d, yyyy h:mm tt",culture);
            Assert.AreEqual(date, datePickerPage.GetSelectDateFieldValue(), "Select Date Field has diffirent value");
            Assert.AreEqual(dateWithTime, datePickerPage.GetDateAndTimeFieldValue(), "Date And Time Field has diffirent value");

            LogUtils.MakeSystemLog("STEP 3");           
            datePickerPage.ClickSelectDateField();
            datePickerPage.PickDateUsingWindow(DateTime.Parse(UtilityClass.ReturnValue(UtilityClass.data, "febrary")));
            DateTime data =  DateTime.Parse(UtilityClass.ReturnValue(UtilityClass.data, "febrary"));
            string appropriateView = data.ToString("MM/dd/yyyy",culture);
            Assert.AreEqual(appropriateView, datePickerPage.GetSelectDateFieldValue(), "Select Date Field has diffirent value");
        }

        [Test]
        public void Test7()
        {
            MainPage mainPage = new MainPage();
            LeftPanel leftPanel = new LeftPanel();
            UploadAndDownloadPage uploadAndDownload = new UploadAndDownloadPage();
            string temp = AppDomain.CurrentDomain.BaseDirectory;

            LogUtils.MakeSystemLog("STEP 1");
            Assert.IsTrue(mainPage.IsPageOpen(), "Main Page is not open");

            LogUtils.MakeSystemLog("STEP 2");
            mainPage.ClickElementsButton();
            leftPanel.ClickUploadAndDownload();
            Assert.IsTrue(uploadAndDownload.IsPageOpen(), "Upload and Download page is not open");

            LogUtils.MakeSystemLog("STEP 3");
            uploadAndDownload.ClickDownloadButton();           
            FileInfo fileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,uploadAndDownload.GetDownloadAttFromButton()));
            Assert.AreEqual(uploadAndDownload.GetDownloadAttFromButton(), fileInfo.Name, "Not equal names");

            LogUtils.MakeSystemLog("STEP 4");
            uploadAndDownload.SendUpload(fileInfo.FullName);
            Assert.IsTrue(uploadAndDownload.GetUploadFilePatheText().Contains(fileInfo.Name), "Path not contains fileName");
            UtilityClass.DeletFile(fileInfo.FullName);
        }
    }
}