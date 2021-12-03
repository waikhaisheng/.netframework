using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.TestModels;

namespace UnitTestProject.Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211203
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestJsonHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
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
