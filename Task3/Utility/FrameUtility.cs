
namespace Task3.Utility
{
    public static class FrameUtility
    {
        public static void SwitchToFrameByID(string IDOrName)
        {
            DriverSinglton.InizializeWebDriver().SwitchTo().Frame(IDOrName);
        }
        public static void SwitchToNextCHildFrame()
        {
            DriverSinglton.InizializeWebDriver().SwitchTo().Frame(0);
        }

        public static void ReturnToDefault()
        {
            DriverSinglton.InizializeWebDriver().SwitchTo().DefaultContent();
        }
    }
}
