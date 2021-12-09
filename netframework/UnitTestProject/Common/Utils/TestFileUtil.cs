using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestWriteAllBytes()
        {
            var str = "test123";
            var path = @"..\..\Common\TestLocalFiles\TestWriteBytes.txt";
            var bytes = Encoding.ASCII.GetBytes(str);
            FileUtil.WriteAllBytes(path, bytes);
            Assert.IsTrue(true);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestReadAllBytes()
        {
            var str = "test123";
            var path = @"..\..\Common\TestLocalFiles\TestWriteBytes.txt";
            var bytes = FileUtil.ReadAllBytes(path);
            var ret = Encoding.ASCII.GetString(bytes);
            Assert.AreEqual(str, ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestWriteEnBytes()
        {
            var str = "test123";
            var pathKey = @"..\..\Common\TestLocalFiles\TestWriteEnBytesKey";
            var pathIv = @"..\..\Common\TestLocalFiles\TestWriteEnBytesIv";
            var path = @"..\..\Common\TestLocalFiles\TestWriteEnBytes";
            var key = CryptographyUtil.GenerateKey();
            FileUtil.WriteAllBytes(pathKey, key);
            var iv = CryptographyUtil.GenerateIv();
            FileUtil.WriteAllBytes(pathIv, iv);
            var encryp = CryptographyUtil.EncryptStringToBytes(str, key, iv);
            FileUtil.WriteAllBytes(path, encryp);
            Assert.IsTrue(true);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestReadDeBytes()
        {
            var str = "test123";
            var pathKey = @"..\..\Common\TestLocalFiles\TestWriteEnBytesKey";
            var pathIv = @"..\..\Common\TestLocalFiles\TestWriteEnBytesIv";
            var path = @"..\..\Common\TestLocalFiles\TestWriteEnBytes";
            var key = FileUtil.ReadAllBytes(pathKey);
            var iv = FileUtil.ReadAllBytes(pathIv);
            var encrypBytes = FileUtil.ReadAllBytes(path);
            var ret = CryptographyUtil.DecryptStringFromBytes(encrypBytes, key, iv);
            Assert.AreEqual(str, ret);
        }
    }
}
