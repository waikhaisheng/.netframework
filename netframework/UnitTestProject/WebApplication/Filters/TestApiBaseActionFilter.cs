using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
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
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApplication.Filters;
using WebApplication.Models.CommonModels;
using WebApplication.Models.Enums;

namespace UnitTestProject.WebApplication.Filters
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211211
    /// Updated: 20211216
    /// </summary>
    [TestClass]
    public class TestApiBaseActionFilter
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting()
        {
            //Arrange
            var context = new HttpActionContext();
            var request = new HttpRequestMessage();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = request;
            context.ControllerContext = httpControllerContext;
            context.ControllerContext.Configuration = new HttpConfiguration();

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuting(context);

            //Assert
            Assert.IsNotNull(context);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting_ModelState()
        {
            //Arrange
            var context = new HttpActionContext();
            var request = new HttpRequestMessage();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = request;
            context.ControllerContext = httpControllerContext;
            context.ControllerContext.Configuration = new HttpConfiguration();
            var modelStateKey = "key1";
            var ModelStateErrorMsg = "error key 1";
            context.ModelState.AddModelError(modelStateKey, ModelStateErrorMsg);

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuting(context);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context?.Response?.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211216
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting_ModelState_ListOfMsg()
        {
            //Arrange
            var context = new HttpActionContext();
            var request = new HttpRequestMessage();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = request;
            context.ControllerContext = httpControllerContext;
            context.ControllerContext.Configuration = new HttpConfiguration();
            for (int i = 0; i < 3; i++)
            {
                var modelStateKey = "key " + i.ToString();
                var ModelStateErrorMsg = "error key " + i.ToString();
                context.ModelState.AddModelError(modelStateKey, ModelStateErrorMsg);
            }

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuting(context);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context?.Response?.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting_ModelState_DeserializeObject()
        {
            //Arrange
            var context = new HttpActionContext();
            var request = new HttpRequestMessage();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = request;
            context.ControllerContext = httpControllerContext;
            context.ControllerContext.Configuration = new HttpConfiguration();
            var modelStateKey = "key1";
            var resBase = new ResponseBase(ApiStatusEnum.Error, "error key 1");
            var modelStateErrorMsg = JsonConvert.SerializeObject(resBase);
            context.ModelState.AddModelError(modelStateKey, modelStateErrorMsg);

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuting(context);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context?.Response?.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting_ModelState_DeserializeObject_null()
        {
            //Arrange
            var context = new HttpActionContext();
            var request = new HttpRequestMessage();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = request;
            context.ControllerContext = httpControllerContext;
            context.ControllerContext.Configuration = new HttpConfiguration();
            var modelStateKey = "key1";
            var mockException = new Mock<Exception>();
            mockException.Setup(e => e.Message).Returns("Test message");
            context.ModelState.AddModelError(modelStateKey, mockException.Object);

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuting(context);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context?.Response?.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting_ActionDescriptorActionName()
        {
            //Arrange
            var context = new HttpActionContext();
            var request = new HttpRequestMessage();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = request;
            context.ControllerContext = httpControllerContext;
            context.ControllerContext.Configuration = new HttpConfiguration();
            var mockActionDescriptor = new Mock<HttpActionDescriptor>();
            var actionName = "MyMethod";
            mockActionDescriptor.Setup(ad => ad.ActionName).Returns(actionName);
            context.ActionDescriptor = mockActionDescriptor.Object;

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuting(context);

            //Assert
            Assert.AreEqual(actionName, context?.ActionDescriptor?.ActionName);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting_RequestHeaders()
        {
            //Arrange
            var context = new HttpActionContext();
            var request = new HttpRequestMessage();
            var headerKey = "TestKey";
            var headerVal = "val1";
            request.Headers.Add(headerKey, headerVal);
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = request;
            context.ControllerContext = httpControllerContext;
            context.ControllerContext.Configuration = new HttpConfiguration();

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuting(context);
            IEnumerable<string> headerValues = new List<string>();
            var hasVal = context?.Request?.Headers?.TryGetValues(headerKey, out headerValues);
            var assertVal = headerValues.FirstOrDefault();

            //Assert
            Assert.AreEqual(true, hasVal);
            Assert.AreEqual(headerVal, assertVal);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuting_RequestRequestValue()
        {
            using (Stream stream = new MemoryStream())
            {
                //Arrange
                var context = new HttpActionContext();
                var request = new HttpRequestMessage();
                var propKey = "MS_HttpContext";
                var mockPropVal = new Mock<HttpContextBase>();
                var mockHttpRequestBase = new Mock<HttpRequestBase>();
                var streamJsonStr = JsonConvert.SerializeObject(new { Name = "test" });
                var writer = new StreamWriter(stream);
                writer.Write(streamJsonStr);
                writer.Flush();
                stream.Position = 0;
                mockHttpRequestBase.Setup(qb => qb.InputStream).Returns(stream);
                mockPropVal.Setup(cb => cb.Request).Returns(mockHttpRequestBase.Object);
                request.Properties.Add(propKey, mockPropVal.Object);
                var httpControllerContext = new HttpControllerContext();
                httpControllerContext.Request = request;
                context.ControllerContext = httpControllerContext;
                context.ControllerContext.Configuration = new HttpConfiguration();

                //Act
                var apiBaseActionFilter = new ApiBaseActionFilter();
                apiBaseActionFilter.OnActionExecuting(context);
                object contextObj = new object();
                var hasVal = context?.Request?.Properties?.TryGetValue("MS_HttpContext", out contextObj);
                var assertVal = contextObj as HttpContextBase;

                //Assert
                Assert.AreEqual(true, hasVal);
                Assert.IsNotNull(assertVal);
            }
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnActionExecuted()
        {
            //Arrange
            var context = new HttpActionExecutedContext();
            context.ActionContext = new HttpActionContext();
            context.Exception = new Exception();

            //Act
            var apiBaseActionFilter = new ApiBaseActionFilter();
            apiBaseActionFilter.OnActionExecuted(context);

            //Assert
            Assert.IsNotNull(context);
        }
    }
}
