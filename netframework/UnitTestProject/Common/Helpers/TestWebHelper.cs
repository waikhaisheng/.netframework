using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication;

namespace UnitTestProject.Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestWebHelper
    {
        [TestMethod]
        public void Test()
        {

        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112010
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetWebByte()
        {
            var url = "https://google.com";
            var st = WebHelper.GetWebBytes(url);
            Assert.IsNotNull(st);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112010
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetWebString()
        {
            var url = "https://google.com";
            var st = WebHelper.GetWebString(url);
            Assert.IsNotNull(st);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112010
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestDownloadString()
        {
            var url = "https://docs.microsoft.com/dotnet/";
            var st = WebHelper.DownloadString(url);
            Assert.IsNotNull(st);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112019
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Context cannot be null.")]
        public void TestGetHostName()
        {
            string filename = "";
            string url = "https://docs.microsoft.com";
            string queryString = "";
            var request = new HttpRequest(filename, url, queryString);
            var mockWriter = new Mock<TextWriter>();
            var response = new HttpResponse(mockWriter.Object);
            var currentContext = new HttpContext(request, response);

            var ret = WebHelper.GetHostName(currentContext);
            Assert.AreEqual("docs.microsoft.com", ret);

            ret = WebHelper.GetHostName(currentContext, true);
            Assert.AreEqual("docs.microsoft.com", ret);

            ret = WebHelper.GetHostName(HttpContext.Current);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestSubmmitRequest_HttpRequestMessage_HttpClient()
        {
            // Arrange
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var server = new HttpServer(config);
            var url = $"https://localhost/api/value/Action";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = WebHelper.SubmmitRequest(httpReqMsg, httpClient);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                }
            }

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestSubmmitRequest_HttpRequestMessage_HttpClient_TrackingIdHeader()
        {
            // Arrange
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var server = new HttpServer(config);
            var url = $"https://localhost/api/value/Action";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var trackingIdHeader = "traceId";

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = WebHelper.SubmmitRequest(httpReqMsg, httpClient, trackingIdHeader);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                    var reqMsgHeaderValues = response.RequestMessage.Headers.GetValues(trackingIdHeader);
                    Assert.IsNotNull(reqMsgHeaderValues.FirstOrDefault());
                }
            }

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestSubmmitRequest_HttpRequestMessage_HttpClient_TimeOutInSecond()
        {
            // Arrange
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var server = new HttpServer(config);
            var url = $"https://localhost/api/value/Action";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var timeOutInSecond = 10;

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = WebHelper.SubmmitRequest(httpReqMsg, httpClient, timeOutInSecond);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                }
            }

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211221
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestSubmmitRequest_HttpRequestMessage_HttpClient_TrackingIdHeader_TimeOutInSecond()
        {
            // Arrange
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var server = new HttpServer(config);
            var url = $"https://localhost/api/value/Action";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var trackingIdHeader = "traceId";
            var timeOutInSecond = 10;

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = WebHelper.SubmmitRequest(httpReqMsg, httpClient, trackingIdHeader, timeOutInSecond);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                    var reqMsgHeaderValues = response.RequestMessage.Headers.GetValues(trackingIdHeader);
                    Assert.IsNotNull(reqMsgHeaderValues.FirstOrDefault());
                }
            }

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
    }
}
