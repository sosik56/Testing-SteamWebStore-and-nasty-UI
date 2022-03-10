using OpenQA.Selenium;

namespace Task3.Utility
{
    public static class JSexecuter
    {
        public static void ExecuteJSript(string script)
        {
            LogUtils.MakeSystemLog($"{script} was executed");
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverSinglton.InizializeWebDriver();
            js.ExecuteScript(script);           
        }        
    }
}
