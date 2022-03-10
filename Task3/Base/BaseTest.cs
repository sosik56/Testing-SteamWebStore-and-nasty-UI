﻿using NUnit.Framework;
using Task3.Utility;

namespace Task3.Base
{
    public abstract class  BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LogUtils.MakeSystemLog($"Test starting and go to {UtilityClass.ConfigData.Host}");
            DriverSinglton.InizializeWebDriver().Navigate().GoToUrl(UtilityClass.ConfigData.Host);            
        }

        [TearDown]
        public void End()
        {
            LogUtils.MakeSystemLog($"Test end");
            DriverSinglton.EndAndNull();
        }
    }
}
