using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DatabaseModels;
using Models.WebApplication.Controllers.WebModels;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication;
using WebApplication.Controllers;
using WebApplication.Filters;
using Models.CommonModels;
using Models.Enums;
using Database.FileConfigs;
using Common.Utils;
using Moq.Protected;
using System.Configuration;

namespace UnitTestProject.WebApplication.Controllers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestApiWebController
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private User usr = new User
        {
            Id = Guid.Parse("00000000-0000-0000-0001-000000000001"),
            Email = $"TestApiWebController1@gmail.com",
            Password = $"test123{DateTime.Now.Ticks}",
            Username = $"TestApiWebController1"
        };
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220106
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private HttpServer _server;
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220106
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20220108
        /// </summary>
        public TestApiWebController()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            _server = new HttpServer(config);

            new FileSystemWatcherConfig().SetupFileSystemWatcherConfig();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGet()
        {
            // Arrange
            var controller = new WebController();

            // Act
            var actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            Assert.AreEqual("Ok", contentResult.Content);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        [TestMethod]
        public void TestUser()
        {
            TestAddUser();
            TestRemoveUser();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        [TestMethod]
        public void TestLoginAuthenticate_MissingJwtToken()
        {
            // Arrange
            var url = $"https://localhost/api/web/LoginAuthenticate";
            var httpMethod = HttpMethod.Get;
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new ResponseBase();
            var httpClient = new HttpClient(_server);

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(usr), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (!response.IsSuccessStatusCode)
                {
                    statusCode = response.StatusCode;
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<ResponseBase>(responseContent);
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, statusCode);
            Assert.AreEqual(ApiStatusEnum.Error, ret.StatusCode);
            Assert.AreEqual("Missing Jwt Token", ret.StatusDesc);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211224
        /// </summary>
        [TestMethod]
        public void TestLogin()
        {
            Login();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211224
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        [TestMethod]
        public void TestLoginAuthenticate()
        {
            var jwt = Login();

            // Arrange
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var url = $"https://localhost/api/web/LoginAuthenticate";
            var httpMethod = HttpMethod.Get;
            var ret = new LoginRes();

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<LoginRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert 
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual(ApiStatusEnum.OK, ret.StatusCode);
            Assert.AreEqual(ApiStatusEnum.OK.GetEnumDescription(), ret.StatusDesc);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220106
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        [TestMethod]
        public void TestGetConfig()
        {
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var url = $"https://localhost/api/web/GetConfig";
            var httpMethod = HttpMethod.Get;
            var ret = new Dictionary<string, string>();

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = httpClient.SendAsync(httpReqMsg).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert 
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual("value1", ret["key1"]);
        }

        #region Private Testcase
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        private void TestAddUser()
        {
            // Arrange
            var url = $"https://localhost/api/web/AddUser";
            var httpMethod = HttpMethod.Post;
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var httpClient = new HttpClient(_server);

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(usr), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var ret = JsonConvert.DeserializeObject(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        private void TestRemoveUser()
        {
            // Arrange
            var url = $"https://localhost/api/web/RemoveUser";
            var httpMethod = HttpMethod.Post;
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var httpClient = new HttpClient(_server);

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(usr), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var ret = JsonConvert.DeserializeObject(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211224
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <returns></returns>
        private string Login()
        {
            // Arrange
            var param = new LoginReq { Email = "test@gmail.com", Password = "test123" };
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var url = $"https://localhost/api/web/Login";
            var httpMethod = HttpMethod.Post;
            var ret = new LoginRes();
            var jwt = string.Empty;
            var httpClient = new HttpClient(_server);

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<LoginRes>(responseContent);
                    statusCode = response.StatusCode;
                    jwt = ret.Token;
                }
            }
            // Assert 
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual(ApiStatusEnum.OK, ret.StatusCode);
            Assert.AreEqual(ApiStatusEnum.OK.GetEnumDescription(), ret.StatusDesc);

            return jwt;
        }
        #endregion
    }
}
