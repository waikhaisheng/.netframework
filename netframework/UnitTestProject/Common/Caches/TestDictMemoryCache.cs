using Common.Caches;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Common.Caches
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211203
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestDictMemoryCache
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetAllCacheAsync()
        {
            var cache = new DictMemoryCache<int, int>();
            var ret = cache.GetAllCacheAsync().GetAwaiter().GetResult();
            Assert.IsNotNull(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetCacheAsync()
        {
            var cache = new DictMemoryCache<int, int>();
            var ret = cache.GetCacheAsync(0).GetAwaiter().GetResult();
            Assert.AreEqual(0, ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAddOrUpdateAsync()
        {
            var cache = new DictMemoryCache<int, int>();
            var ret = cache.AddOrUpdateAsync(1, 1).GetAwaiter().GetResult();
            Assert.AreEqual(1, ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestRemovedAsync()
        {
            var cache = new DictMemoryCache<int, int>();
            var add = cache.AddOrUpdateAsync(1, 1).GetAwaiter().GetResult();
            Assert.AreEqual(1, add);
            var ret = cache.RemovedAsync(1).GetAwaiter().GetResult();
            Assert.AreEqual(1, ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211203
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestClearCacheAsync()
        {
            var cache = new DictMemoryCache<int, int>();
            var add = cache.AddOrUpdateAsync(1, 1).GetAwaiter().GetResult();
            Assert.AreEqual(1, add);
            cache.ClearCacheAsync().GetAwaiter().GetResult();
            var ret = cache.GetAllCacheAsync().GetAwaiter().GetResult();
            Assert.AreEqual(0, ret.Count);
        }
    }
}
