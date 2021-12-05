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
    /// Updated: 20211205
    /// </summary>
    [TestClass]
    public class TestEnumHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetEnumDescription()
        {
            var retEnumStr = TestEnumModel.Ok.GetEnumDescription();
            Assert.AreEqual("Ok", retEnumStr);
            
            var retErrorStr = TestEnumModel.Error.GetEnumDescription();
            Assert.AreEqual("Error", retErrorStr);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// UpdatedBy:
        /// </summary>
        [TestMethod]
        public void TestStringToEnum()
        {
            var retEnumOk = "Ok".StringToEnum<TestEnumModel>();
            Assert.AreEqual(TestEnumModel.Ok, retEnumOk);
            
            var retEnum1 = "1".StringToEnum<TestEnumModel>();
            Assert.AreEqual(TestEnumModel.Ok, retEnum1);
        }
    }
}
