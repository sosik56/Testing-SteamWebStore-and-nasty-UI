using OpenQA.Selenium;

namespace Task3.Utility
{
    public static class JSexecuter
    {
        public static void ExecuteJSript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverSinglton.InizializeWebDriver();
            js.ExecuteScript(script);
            LogUtils.MakeSystemLog($"{script} was executed");
        }        
    }
}
