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
    /// Created: 20211206
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestEncodingUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestEncodeStringToByte()
        {
            var f = true;
            var str = "test123";
            var encode = new byte[] { 116, 101, 115, 116, 49, 50, 51 };
            var ret = EncodingUtil.EncodeStringToByte(str);
            for (int i = 0; i < ret.Length; i++)
            {
                if (ret[i] != encode[i])
                {
                    f = false;
                    break;
                }
            }
            Assert.AreEqual(true, f);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestDecodeByteToString()
        {
            var str = "test123";
            var encode = new byte[] { 116, 101, 115, 116, 49, 50, 51 };
            var ret = EncodingUtil.DecodeByteToString(encode);
            Assert.AreEqual(str, ret);
        }
    }
}
