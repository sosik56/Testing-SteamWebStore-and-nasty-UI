using NUnit.Framework;
using OpenQA.Selenium;
using Task3.Base;

namespace Task3
{
    public class Tests:BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}