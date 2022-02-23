using NUnit.Framework;
using Task3.Utility;

namespace Task3.Base
{
    abstract public class  BaseTest
    {
        [SetUp]
        public void Setup()
        {
            DriverSinglton.InizializeWebDriver().Navigate().GoToUrl(UtilityClass.ConfigData.Host);            
        }

        [TearDown]
        public void End()
        {
            DriverSinglton.EndAndNull();
        }
    }
}
