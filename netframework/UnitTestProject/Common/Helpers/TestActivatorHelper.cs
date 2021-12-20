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
    /// Created: 20211209
    /// UpdatedBy:
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestActivatorHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void Test()
        {
            var i1 = ActivatorHelper.CreateInstance<StringBuilder>(typeof(StringBuilder)).GetHash();
            var i2 = ActivatorHelper.CreateInstance<StringBuilder>(typeof(StringBuilder)).GetHash();
            Assert.IsTrue(i1 != i2);
        }

    }
}
