using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

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
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112019
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authority"></param>
        /// <returns></returns>
        public static string GetHostName(HttpContext context, bool authority = false)
        {
            if (context == null)
                throw new ArgumentException("Context cannot be null.");
            if (context.Request == null)
                throw new ArgumentException("Request cannot be null.");
            if (context.Request.Url == null)
                throw new ArgumentException("Url cannot be null.");
            if (authority)
                return context.Request.Url.Authority;
            return context.Request.Url.Host;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="httpReqMsg"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static HttpResponseMessage SubmmitRequest(HttpRequestMessage httpReqMsg, HttpClient httpClient)
        {
            return httpClient.SendAsync(httpReqMsg).Result;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="httpReqMsg"></param>
        /// <param name="httpClient"></param>
        /// <param name="trackingIdHeader"></param>
        /// <returns></returns>
        public static HttpResponseMessage SubmmitRequest(HttpRequestMessage httpReqMsg, HttpClient httpClient, string trackingIdHeader)
        {
            var trackingId = Trace.CorrelationManager.ActivityId.ToString();
            if (Trace.CorrelationManager.ActivityId == default(Guid) || Trace.CorrelationManager.ActivityId == Guid.Empty)
                trackingId = Guid.NewGuid().ToString();
            httpReqMsg.Headers.Add(trackingIdHeader, trackingId);
            return httpClient.SendAsync(httpReqMsg).Result;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="httpReqMsg"></param>
        /// <param name="httpClient"></param>
        /// <param name="timeOutInSecond"></param>
        /// <returns></returns>
        public static HttpResponseMessage SubmmitRequest(HttpRequestMessage httpReqMsg, HttpClient httpClient, int timeOutInSecond)
        {
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeOutInSecond)))
            {
                return httpClient.SendAsync(httpReqMsg, cts.Token).Result;
            }
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="httpReqMsg"></param>
        /// <param name="httpClient"></param>
        /// <param name="trackingIdHeader"></param>
        /// <param name="timeOutInSecond"></param>
        /// <returns></returns>
        public static HttpResponseMessage SubmmitRequest(HttpRequestMessage httpReqMsg, HttpClient httpClient, 
            string trackingIdHeader, int timeOutInSecond)
        {
            var trackingId = Trace.CorrelationManager.ActivityId.ToString();
            if (Trace.CorrelationManager.ActivityId == default(Guid) || Trace.CorrelationManager.ActivityId == Guid.Empty)
                trackingId = Guid.NewGuid().ToString();

            httpReqMsg.Headers.Add(trackingIdHeader, trackingId);

            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeOutInSecond)))
            {
                return httpClient.SendAsync(httpReqMsg, cts.Token).Result;
            }
        }
    }
}
