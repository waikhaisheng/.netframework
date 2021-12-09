using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Caches
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211201
    /// Updated: 20211209
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class DictMemoryCache<TKey, T>
    {
        private ConcurrentDictionary<TKey, T> cacheDict { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy: Wai Khai Sheng
        /// Updated:  20211209
        /// </summary>
        public DictMemoryCache()
        {
            cacheDict = new ConcurrentDictionary<TKey, T>();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy: Wai Khai Sheng
        /// Updated:  20211209
        /// </summary>
        /// <returns></returns>
        public ConcurrentDictionary<TKey, T> GetAllCache()
        {
            return cacheDict;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy: Wai Khai Sheng
        /// Updated:  20211209
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCache(TKey key)
        {
            cacheDict.TryGetValue(key, out T ret);
            return ret;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy: Wai Khai Sheng
        /// Updated:  20211209
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T AddOrUpdate(TKey key, T obj)
        {
            return cacheDict.AddOrUpdate(key, obj, (k, v) => obj);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy: Wai Khai Sheng
        /// Updated:  20211209
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Removed(TKey key)
        {
            cacheDict.TryRemove(key, out T obj);
            return obj;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy: Wai Khai Sheng
        /// Updated:  20211209
        /// </summary>
        /// <returns></returns>
        public void ClearCache()
        {
            cacheDict = new ConcurrentDictionary<TKey, T>();
        }
    }
}
