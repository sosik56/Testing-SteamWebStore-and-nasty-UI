
namespace Task3.Utility
{
    public static class AlertUtility
    {
        public static string GetTextFromAlert()
        {
            Expectations.WaintUntilAlert();
            return DriverSinglton.InizializeWebDriver().SwitchTo().Alert().Text;
        }

        public static void AcceptAlert()
        {
            LogUtils.MakeSystemLog($"Alert was accepted");
            Expectations.WaintUntilAlert();
            DriverSinglton.InizializeWebDriver().SwitchTo().Alert().Accept();
        } 

        public static void DismisAlert()
        {
            LogUtils.MakeSystemLog($"Alert was dismiss");
            Expectations.WaintUntilAlert();
            DriverSinglton.InizializeWebDriver().SwitchTo().Alert().Dismiss();
        }

        public static string SendStrToAlert(string str)
        {
            LogUtils.MakeSystemLog($"Send to alert {str}");
            Expectations.WaintUntilAlert();
            DriverSinglton.InizializeWebDriver().SwitchTo().Alert().SendKeys(str);
            AcceptAlert();
            return str;
        }
        
        public static bool IsThereAlert()
        {
            try
            {
                LogUtils.MakeSystemLog($"Alert here");
                Expectations.WaintUntilAlert();
                DriverSinglton.InizializeWebDriver().SwitchTo().Alert().GetHashCode();
                return true;
            }
            catch
            {
                LogUtils.MakeSystemLog($"Alert not here");
                return false;
            }               
        }
    }
}
