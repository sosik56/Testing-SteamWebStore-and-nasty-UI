using System;

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
            Expectations.WaintUntilAlert();
            DriverSinglton.InizializeWebDriver().SwitchTo().Alert().Accept();
        } 

        public static void DismisAlert()
        {
            Expectations.WaintUntilAlert();
            DriverSinglton.InizializeWebDriver().SwitchTo().Alert().Dismiss();
        }

        public static string SendRandomStr()
        {
            Guid g = Guid.NewGuid();
            Expectations.WaintUntilAlert();
            DriverSinglton.InizializeWebDriver().SwitchTo().Alert().SendKeys(g.ToString());
            AcceptAlert();
            return g.ToString();
        }
        
        public static bool IsThereAlert()
        {
            try
            {
                Expectations.WaintUntilAlert();
                DriverSinglton.InizializeWebDriver().SwitchTo().Alert().GetHashCode();
                return true;
            }
            catch
            {
                return false;
            }               
        }
    }
}
