using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Common
{
    [TestClass]
    public class TestFileUtil
    {
        [TestMethod]
        public void TestGetDirectoryByFolderName()
        {
            var path = @"..\..\";
            var fName = "Common";
            var ret = FileUtil.GetDirectoryByFolderName(path, fName);
            Assert.AreEqual(1, ret.Count);
        }
        
        [TestMethod]
        public void TestGetDirectoryByFileName()
        {
            var path = @"..\..\Common";
            var fName = "TestFileUtil";
            var ret = FileUtil.GetDirectoryByFileName(path, fName);
            Assert.AreEqual(1, ret.Count);
        }
    }
}
