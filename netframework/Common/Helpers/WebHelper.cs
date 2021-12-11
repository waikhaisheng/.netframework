using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// Updated:
    /// </summary>
    public static class WebHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] GetWebBytes(string url)
        {
            using (var client = new WebClient())
            {
                using (Stream stream = client.OpenRead(url))
                {
                    long originalPosition = 0;

                    if (stream.CanSeek)
                    {
                        originalPosition = stream.Position;
                        stream.Position = 0;
                    }

                    try
                    {
                        byte[] readBuffer = new byte[4096];

                        int totalBytesRead = 0;
                        int bytesRead;

                        while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                        {
                            totalBytesRead += bytesRead;

                            if (totalBytesRead == readBuffer.Length)
                            {
                                int nextByte = stream.ReadByte();
                                if (nextByte != -1)
                                {
                                    byte[] temp = new byte[readBuffer.Length * 2];
                                    Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                                    Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                                    readBuffer = temp;
                                    totalBytesRead++;
                                }
                            }
                        }

                        byte[] buffer = readBuffer;
                        if (readBuffer.Length != totalBytesRead)
                        {
                            buffer = new byte[totalBytesRead];
                            Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                        }
                        return buffer;
                    }
                    finally
                    {
                        if (stream.CanSeek)
                        {
                            stream.Position = originalPosition;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetWebString(string url)
        {
            using (var client = new WebClient())
            {
                using (Stream response = client.OpenRead(url))
                {
                    using (StreamReader reader = new StreamReader(response))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112010
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadString(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
