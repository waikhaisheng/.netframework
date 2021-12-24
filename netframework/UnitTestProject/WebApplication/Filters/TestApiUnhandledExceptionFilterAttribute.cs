using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApplication.Filters;
using Models.CommonModels;
using Models.Enums;

namespace UnitTestProject.WebApplication.Filters
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211211
    /// UpdatedBy: 
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestApiUnhandledExceptionFilterAttribute
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnException()
        {
            //Arrange
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage();
            var actionContext = new HttpActionContext(httpControllerContext, Mock.Of<HttpActionDescriptor>());
            actionContext.ControllerContext.Configuration = new HttpConfiguration();
            var context = new HttpActionExecutedContext(actionContext, null);

            //Act
            var filter = new ApiUnhandledExceptionFilterAttribute();
            filter.OnException(context);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context.Response.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnException_Exception()
        {
            //Arrange
            var mockException = new Mock<Exception>();
            mockException.Setup(e => e.StackTrace).Returns("Test stacktrace");
            mockException.Setup(e => e.Message).Returns("Test message");
            mockException.Setup(e => e.Source).Returns("Test source");
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage();
            var actionContext = new HttpActionContext(httpControllerContext, Mock.Of<HttpActionDescriptor>());
            actionContext.ControllerContext.Configuration = new HttpConfiguration();
            var context = new HttpActionExecutedContext(actionContext, mockException.Object);

            //Act
            var filter = new ApiUnhandledExceptionFilterAttribute();
            filter.OnException(context);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context.Response.StatusCode);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnException_Exception_ActionContextModelState()
        {
            //Arrange
            var mockException = new Mock<Exception>();
            var eStackTrace = "Test stacktrace";
            var eMessage = "Test message";
            var eSource = "Test source";
            mockException.Setup(e => e.StackTrace).Returns(eStackTrace);
            mockException.Setup(e => e.Message).Returns(eMessage);
            mockException.Setup(e => e.Source).Returns(eSource);
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage();
            var actionContext = new HttpActionContext(httpControllerContext, Mock.Of<HttpActionDescriptor>());
            actionContext.ControllerContext.Configuration = new HttpConfiguration();
            var modelStateKey = "key1";
            var modelStateErrorMsg = "error key 1";
            actionContext.ModelState.AddModelError(modelStateKey, mockException.Object);
            actionContext.ModelState.AddModelError(modelStateKey, modelStateErrorMsg);
            var context = new HttpActionExecutedContext(actionContext, mockException.Object);


            //Act
            var filter = new ApiUnhandledExceptionFilterAttribute();
            filter.OnException(context);
            var modelStateMsg = context.ActionContext.ModelState.Values
                    .SelectMany(x => x.Errors).Where(y => y.Exception != null).Select(m => m.Exception).FirstOrDefault();

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context?.Response?.StatusCode);
            Assert.AreEqual(eMessage, modelStateMsg?.Message);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOnException_Exception_AggregateException()
        {
            //Arrange
            var mockException = new Mock<Exception>();
            var eStackTrace = "Test stacktrace";
            var eMessage = "Test message";
            var eSource = "Test source";
            mockException.Setup(e => e.StackTrace).Returns(eStackTrace);
            mockException.Setup(e => e.Message).Returns(eMessage);
            mockException.Setup(e => e.Source).Returns(eSource);
            var aggregateException = new AggregateException(mockException.Object);
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage();
            var actionContext = new HttpActionContext(httpControllerContext, Mock.Of<HttpActionDescriptor>());
            actionContext.ControllerContext.Configuration = new HttpConfiguration();
            var context = new HttpActionExecutedContext(actionContext, aggregateException);

            //Act
            var filter = new ApiUnhandledExceptionFilterAttribute();
            filter.OnException(context);
            var ret = context?.Response?.Content?.ReadAsStringAsync()?.Result;
            var resBase = JsonConvert.DeserializeObject<ResponseBase>(ret); 

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, context?.Response?.StatusCode);
            Assert.AreEqual(ApiStatusEnum.Error, resBase?.StatusCode);
        }
    }
}
