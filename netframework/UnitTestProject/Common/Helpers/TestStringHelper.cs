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
    public class TestStringHelper
    {
        [TestMethod]
        public void TestReplaceZeroWidthSpace()
        {
            var str = "​​";
            Assert.IsTrue(str.Contains("\u200B"));
            var ret = str.ReplaceZeroWidthSpace();
            Assert.IsTrue(!ret.Contains("\u200B"));
        }
    }
}
