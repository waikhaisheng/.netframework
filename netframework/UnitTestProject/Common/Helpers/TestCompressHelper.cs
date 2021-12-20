using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.Common.TestModels;

namespace UnitTestProject.Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211221
    /// UpdatedBy:
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestCompressHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestCompressTo64BaseString()
        {
            var obj = new TestCompressHelperModel { Id = 1, Name = "test123" };
            var compressStr = CompressHelper.CompressTo64BaseString(obj);
            Assert.IsNotNull(compressStr);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestCompressToByteArray()
        {
            var obj = new TestCompressHelperModel { Id = 1, Name = "test123" };
            var compressArray = CompressHelper.CompressToByteArray(obj);
            Assert.IsTrue(compressArray.Length > 0);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestDecompressFromString()
        {
            var obj = new TestCompressHelperModel { Id = 1, Name = "test123" };
            var compressStr = CompressHelper.CompressTo64BaseString(obj);
            var decompressStr = CompressHelper.DecompressFromString<TestCompressHelperModel>(compressStr);
            Assert.IsNotNull(decompressStr);
            Assert.AreEqual(decompressStr.Id, obj.Id);
            Assert.AreEqual(decompressStr.Name, obj.Name);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestDecompressFromByte()
        {
            var obj = new TestCompressHelperModel { Id = 1, Name = "test123" };
            var compressArray = CompressHelper.CompressToByteArray(obj);
            var decompressArray = CompressHelper.DecompressFromByte(compressArray);
            Assert.IsTrue(decompressArray.Length > 0);
            string decompressDataStr = Encoding.UTF8.GetString(decompressArray);
            var ret = JsonConvert.DeserializeObject<TestCompressHelperModel>(decompressDataStr);
            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Id, obj.Id);
            Assert.AreEqual(ret.Name, obj.Name);
        }
        #region Compare Size
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestCompressToByteArray_Size()
        {
            var obj = new TestCompressHelperModel { Id = 1, Name = "test123" };

            var compressArray = CompressHelper.CompressToByteArray(obj);
            float small = BitConverter.ToSingle(compressArray, 0);

            var dataStr = JsonConvert.SerializeObject(obj);
            var array = Encoding.UTF8.GetBytes(dataStr);
            float big = BitConverter.ToSingle(array, 0);

            Assert.IsTrue(small < big);
        }
        #endregion
    }
}
