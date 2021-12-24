using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211203
    /// Updated: 20211205
    /// </summary>
    public static class CryptographyUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public static (byte[], byte[]) GenerateKeyIv()
        {
            byte[] k, iv;
            using (Aes aesAlg = Aes.Create())
            {
                k = aesAlg.Key.ToArray();
                iv = aesAlg.IV.ToArray();
            }
            return (k, iv);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateKey()
        {
            byte[] k;
            using (Aes aesAlg = Aes.Create())
            {
                k = aesAlg.Key.ToArray();
            }
            return k;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateIv()
        {
            byte[] iv;
            using (Aes aesAlg = Aes.Create())
            {
                iv = aesAlg.IV.ToArray();
            }
            return iv;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static byte[] EncryptStringToBytes(this string plainText, byte[] key, byte[] iv)
        {
            return CryptographyAes.EncryptStringToBytesAes(plainText, key, iv);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string DecryptStringFromBytes(this byte[] cipherText, byte[] key, byte[] iv)
        {
            return CryptographyAes.DecryptStringFromBytesAes(cipherText, key, iv);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] HashBytes(this byte[] bytes)
        {
            return CryptographySha256.HashBytes(bytes);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HashString(this string str)
        {
            return CryptographySha256.HashString(str);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public static (RSAParameters, RSAParameters) RsaKeys()
        {
            return CryptographyRsa.RasKeys();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="DataToEncrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(this byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            return CryptographyRsa.RSAEncrypt(DataToEncrypt, RSAKeyInfo, DoOAEPPadding);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="DataToDecrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSADecrypt(this byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            return CryptographyRsa.RSADecrypt(DataToDecrypt, RSAKeyInfo, DoOAEPPadding);
        }
    }
}
