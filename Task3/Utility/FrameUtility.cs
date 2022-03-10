
namespace Task3.Utility
{
    public static class FrameUtility
    {
        public static void SwitchToFrameByID(string IDOrName)
        {
            LogUtils.MakeSystemLog($"Switch to frame : {IDOrName}");
            DriverSinglton.InizializeWebDriver().SwitchTo().Frame(IDOrName);
        }

        public static void SwitchToNextCHildFrame()
        {
            LogUtils.MakeSystemLog($"Switched to child frame");
            DriverSinglton.InizializeWebDriver().SwitchTo().Frame(0);
        }

        public static void ReturnToDefault()
        {
            LogUtils.MakeSystemLog($"Return to default");
            DriverSinglton.InizializeWebDriver().SwitchTo().DefaultContent();
        }
    }
}
