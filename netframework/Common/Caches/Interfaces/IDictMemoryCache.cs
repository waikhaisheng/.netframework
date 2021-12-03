using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Caches.Interfaces
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211201
    /// Updated: 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IDictMemoryCache<TKey, T>
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        Task<ConcurrentDictionary<TKey, T>> GetAllCacheAsync();
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetCacheAsync(TKey key);
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<T> AddOrUpdateAsync(TKey key, T obj);
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> RemovedAsync(TKey key);
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        Task CancelTask();
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        Task ClearCacheAsync();
    }
}
