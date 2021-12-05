using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211205
    /// Updated: 
    /// </summary>
    internal static class CryptographySha256
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static byte[] HashBytes(byte[] bytes)
        {
            byte[] hashValue;
            using (var sha256Alg = SHA256.Create())
            {
                hashValue = sha256Alg.ComputeHash(bytes).ToArray();
            }
            return hashValue;
        }
    }
}
