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
    /// Created: 20211206
    /// Updated: 
    /// </summary>
    internal static class CryptographyRsa
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        internal static (RSAParameters, RSAParameters) RasKeys()
        {
            RSAParameters publicKey, privateKey;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                publicKey = RSA.ExportParameters(false);
                privateKey = RSA.ExportParameters(true);
            }
            return (publicKey, privateKey);
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
        internal static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKeyInfo);
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            return encryptedData;
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
        internal static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKeyInfo);
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            return decryptedData;
        }
    }
}
