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
    internal class CompressGZipStreamHelper
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
        public static byte[] Compress<T>(T data)
        {
            byte[] ret;
            var dataStr = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(dataStr);
            using (var ms = new MemoryStream())
            {
                using (var gZipCompress = new GZipStream(ms, CompressionMode.Compress))
                {
                    gZipCompress.Write(buffer, 0, buffer.Length);
                }
                ret = ms.ToArray();
            }
            return ret;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy: 
        /// Updated:
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            byte[] res;
            using (var tempMs = new MemoryStream())
            {
                using (var ms = new MemoryStream(data))
                {
                    using (var gZipStream = new GZipStream(ms, CompressionMode.Decompress))
                    {
                        gZipStream.CopyTo(tempMs);
                    }
                    res = tempMs.ToArray();
                }
            }
            return res;
        }
    }
}
