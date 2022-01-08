using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20220106
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20220108
    /// </summary>
    [TestClass]
    public class TestFileSystemWatcherUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220106
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20220108
        /// </summary>
        [TestMethod]
        public void TestCtor()
        {
            var path = ConfigurationManager.AppSettings["DictConfig"];
            var fileSystemWatcherUtil = new FileSystemWatcherUtil<Dictionary<string, string>>();
            fileSystemWatcherUtil.Initialization(path);
        }
    }
}
