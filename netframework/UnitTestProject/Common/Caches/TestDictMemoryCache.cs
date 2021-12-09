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
            var ret = cache.GetAllCache();
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
            var ret = cache.GetCache(0);
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
            var ret = cache.AddOrUpdate(1, 1);
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
            var add = cache.AddOrUpdate(1, 1);
            Assert.AreEqual(1, add);
            var ret = cache.Removed(1);
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
            var add = cache.AddOrUpdate(1, 1);
            Assert.AreEqual(1, add);
            cache.ClearCache();
            var ret = cache.GetAllCache();
            Assert.AreEqual(0, ret.Count);
        }
    }
}
