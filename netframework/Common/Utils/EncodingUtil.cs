using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211206
    /// Updated: 
    /// </summary>
    public static class EncodingUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] EncodeStringToByte(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string DecodeByteToString(this byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
