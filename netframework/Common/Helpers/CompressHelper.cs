using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211221
    /// UpdatedBy: 
    /// Updated: 
    /// </summary>
    public class CompressHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy: 
        /// Updated:
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string CompressTo64BaseString<T>(T data)
        {
            return Convert.ToBase64String(CompressGZipStreamHelper.Compress(data));
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy: 
        /// Updated:
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] CompressToByteArray<T>(T data)
        {
            return CompressGZipStreamHelper.Compress(data);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy: 
        /// Updated:
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DecompressFromString<T>(string data)
        {
            byte[] buffer = Convert.FromBase64String(data);
            byte[] decompressData = CompressGZipStreamHelper.Decompress(buffer);
            string decompressDataStr = Encoding.UTF8.GetString(decompressData);
            return JsonConvert.DeserializeObject<T>(decompressDataStr);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy: 
        /// Updated:
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] DecompressFromByte(byte[] data)
        {
            return CompressGZipStreamHelper.Decompress(data);
        }
    }
}
