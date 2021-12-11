using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestWebHelper
    {
        [TestMethod]
        public void Test()
        {

        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112010
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetWebByte()
        {
            var url = "https://google.com";
            var st = WebHelper.GetWebBytes(url);
            Assert.IsNotNull(st);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112010
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetWebString()
        {
            var url = "https://google.com";
            var st = WebHelper.GetWebString(url);
            Assert.IsNotNull(st);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112010
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestDownloadString()
        {
            var url = "https://docs.microsoft.com/dotnet/";
            var st = WebHelper.DownloadString(url);
            Assert.IsNotNull(st);
        }
    }
}
