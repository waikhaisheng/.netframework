using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.TestModels;

namespace UnitTestProject.Common
{
    [TestClass]
    public class TestJsonHelper
    {
        [TestMethod]
        public void TestGetConfig()
        {
            var path = @"..\..\Common\TestLocalFiles\TestJsonHelper.txt";
            var obj = JsonHelper.GetConfig<TestJsonHelperModel>(path);
            Assert.AreEqual(1, obj.Id);

            var pathNotExist = @"..\..\Common\TestLocalFiles\TestJsonHelperNotExist.txt";
            var objNotExist = JsonHelper.GetConfig<TestJsonHelperModel>(pathNotExist);
            Assert.AreEqual(null, objNotExist);
        }
    }
}
