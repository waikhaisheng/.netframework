using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211203
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestFileUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetDirectoryByFolderName()
        {
            var path = @"..\..\";
            var fName = "Common";
            var ret = FileUtil.GetDirectoryByFolderName(path, fName);
            Assert.AreEqual(1, ret.Count);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetDirectoryByFileName()
        {
            var path = @"..\..\Common\Utils";
            var fName = "TestFileUtil";
            var ret = FileUtil.GetDirectoryByFileName(path, fName);
            Assert.AreEqual(1, ret.Count);
        }
    }
}
