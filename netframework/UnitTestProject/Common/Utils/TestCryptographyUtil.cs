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
    public class TestCryptographyUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGenerateKeyIv()
        {
            var ret = CryptographyUtil.GenerateKeyIv();
            Assert.IsTrue(ret.Item1.Length > 0);
            Assert.IsTrue(ret.Item2.Length > 0);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGenerateKey()
        {
            var ret = CryptographyUtil.GenerateKey();
            Assert.IsTrue(ret.Length > 0);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGenerateIv()
        {
            var ret = CryptographyUtil.GenerateIv();
            Assert.IsTrue(ret.Length > 0);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestEncryptStringToBytes()
        {
            var str = "test123";
            var keyIv = CryptographyUtil.GenerateKeyIv();
            var key = keyIv.Item1;
            var iv = keyIv.Item2;
            var ret = CryptographyUtil.EncryptStringToBytes(str, key, iv);
            Assert.IsTrue(ret.Length > 0);
            var ret2 = str.EncryptStringToBytes(key, iv);
            Assert.IsTrue(ret2.Length > 0);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestDecryptStringFromBytes()
        {
            var str = "test123";
            var key = CryptographyUtil.GenerateKey();
            var iv = CryptographyUtil.GenerateIv();
            var encryp = CryptographyUtil.EncryptStringToBytes(str, key, iv);
            var ret = CryptographyUtil.DecryptStringFromBytes(encryp, key, iv);
            Assert.AreEqual(str, ret);
            var ret2 = encryp.DecryptStringFromBytes(key, iv);
            Assert.AreEqual(str, ret2);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestHashBytes()
        {
            var bytes = new byte[ 1 ];
            var ret = CryptographyUtil.HashBytes(bytes);
            Assert.IsTrue(ret.Length > 0);
        }
    }
}
