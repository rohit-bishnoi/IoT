using System;
using System.Collections.Generic;
using System.Linq;
using IoT.Services; // Replace with the actual namespace
using YourProjectNamespace.Models;

namespace IoT.Tests
{
    [TestFixture]
    public class Tests
    {
        private IIoTDataService _iotDataService;

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