using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFramework.Service.HistoricalData;

namespace TFramework.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string inputText = "20151102 00:00:02.730";
            var result = inputText.ToDateTime();
            Assert.AreEqual(2015, result.Year);
            Assert.AreEqual(11, result.Month);
            Assert.AreEqual(02, result.Day);
            Assert.AreEqual(00, result.Hour);
            Assert.AreEqual(00, result.Minute);
            Assert.AreEqual(02, result.Second);
            Assert.AreEqual(730, result.Millisecond);
        }
    }
}
