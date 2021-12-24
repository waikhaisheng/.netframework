using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using WebApplication;
using WebApplication.Controllers;
using Models.Enums;
using Models.WebApplication.Controllers.ValuesModels;

namespace UnitTestProject.WebApplication.Controllers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211209
    /// Updated: 20211210
    /// </summary>
    [TestClass]
    public class TestValueController
    {
        private HttpServer _server;
        private string _url = "https://localhost";
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211220
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        public TestValueController()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            _server = new HttpServer(config);
        }

        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        [TestMethod]
        public void TestGet()
        {
            // Arrange
            var controller = new ValueController();

            // Act
            var actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<ValueRes>;

            // Assert
            Assert.AreEqual(ApiStatusEnum.OK, contentResult.Content.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        [TestMethod]
        public void TestPost()
        {
            var controller = new ValueController();

            var actionResult = controller.Post(new ValueReq { Name = "" });
            var contentResult = actionResult as OkNegotiatedContentResult<ValueRes>;

            Assert.AreEqual(ApiStatusEnum.OK, contentResult.Content.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        [TestMethod]
        public void TestPut()
        {
            var controller = new ValueController();

            var actionResult = controller.Put(new ValueReq { Name = "" });
            var contentResult = actionResult as OkNegotiatedContentResult<ValueRes>;

            Assert.AreEqual(ApiStatusEnum.OK, contentResult.Content.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            var controller = new ValueController();

            var actionResult = controller.Delete(new ValueReq { Name = "" });
            var contentResult = actionResult as OkNegotiatedContentResult<ValueRes>;

            Assert.AreEqual(ApiStatusEnum.OK, contentResult.Content.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGet_Filter()
        {
            // Arrange
            var controller = new ValueController();
            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://localhost:44357/api/Value")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "Value",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            //controller.RequestContext.RouteData = new HttpRouteData(
            //    route: new HttpRoute(),
            //    values: new HttpRouteValueDictionary { { "controller", "products" } });

            // Act
            var actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<ValueRes>;

            // Assert
            Assert.AreEqual(ApiStatusEnum.OK, contentResult.Content.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211220
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAction_Action_Get()
        {
            // Arrange
            var url = $"{_url}/api/value/Action";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = httpClient.SendAsync(httpReqMsg).Result;

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
        /// Created: 20211220
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAction_Action_GetId()
        {
            // Arrange
            var id = 1;
            var url = $"{_url}/api/value/Action/{id}";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new ValueRes();
            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<ValueRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual($"Action {id}", ret.StatusDesc);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211220
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAction_Action_GetIdName()
        {
            // Arrange
            var id = 1;
            var name = "test123";
            var url = $"{_url}/api/value/Action/{id}/{name}";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new ValueRes();
            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<ValueRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual($"Action {id} {name}", ret.StatusDesc);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211220
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAction_Action_Post()
        {
            // Arrange
            var url = $"{_url}/api/value/Action";
            var httpMethod = HttpMethod.Post;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new ValueRes();
            var paramObj = new ValueReq { Id = Guid.NewGuid(), Name = "test" };

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<ValueRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual($"ActionPost {JsonConvert.SerializeObject(paramObj)}", ret.StatusDesc);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211220
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAction_Action_Put()
        {
            // Arrange
            var url = $"{_url}/api/value/Action";
            var httpMethod = HttpMethod.Put;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new ValueRes();
            var paramObj = new ValueReq { Id = Guid.NewGuid(), Name = "test" };

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<ValueRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual($"ActionPut {JsonConvert.SerializeObject(paramObj)}", ret.StatusDesc);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211220
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAction_Action_Delete()
        {
            // Arrange
            var id = Guid.NewGuid();
            var url = $"{_url}/api/value/Action/{id}";
            var httpMethod = HttpMethod.Delete;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new ValueRes();
            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<ValueRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual($"ActionDelete {id}", ret.StatusDesc);
        }
    }
}
