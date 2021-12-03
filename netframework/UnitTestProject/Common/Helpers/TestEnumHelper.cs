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
    }
}
