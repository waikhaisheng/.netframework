using Common.Caches.Interfaces;
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
    /// Updated: 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class DictMemoryCache<TKey, T> : IDictMemoryCache<TKey, T>
    {
        private CancellationTokenSource _cancellationTokenSource { get; set; }
        private ConcurrentDictionary<TKey, T> cacheDict { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        public DictMemoryCache()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            cacheDict = new ConcurrentDictionary<TKey, T>();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public async Task<ConcurrentDictionary<TKey, T>> GetAllCacheAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return cacheDict;
            }, _cancellationTokenSource.Token);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetCacheAsync(TKey key)
        {
            return await Task.Factory.StartNew(() =>
            {
                cacheDict.TryGetValue(key, out T ret);
                return ret;
            }, _cancellationTokenSource.Token);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<T> AddOrUpdateAsync(TKey key, T obj)
        {
            return await Task.Factory.StartNew(() =>
            {
                return cacheDict.AddOrUpdate(key, obj, (k, v) => obj);
            }, _cancellationTokenSource.Token);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> RemovedAsync(TKey key)
        {
            return await Task.Factory.StartNew(() =>
            {
                cacheDict.TryRemove(key, out T obj);
                return obj;
            }, _cancellationTokenSource.Token);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public Task CancelTask()
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211201
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public async Task ClearCacheAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                cacheDict = new ConcurrentDictionary<TKey, T>();
            }, _cancellationTokenSource.Token);
        }
    }
}
