using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211203
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestObjectHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetCurrentClassName()
        {
            var ret = this.GetCurrentClassName();
            Assert.AreEqual("TestObjectHelper", ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetCurrentMethodName()
        {
            var ret = ObjectHelper.GetCurrentMethodName();
            Assert.AreEqual("TestGetCurrentMethodName", ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestDeepClone()
        {
            var list = new List<int>();
            var listHash = list.GetHashCode();
            var cloneList = list.DeepClone();
            var cloneListHash = cloneList.GetHashCode();
            Assert.IsTrue(listHash != cloneListHash);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetHash()
        {
            var ret = this.GetHashCode();
            Assert.IsTrue(ret > 0);
        }
    }
}
