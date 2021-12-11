using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using WebApplication.Controllers;
using WebApplication.Models.Enums;
using WebApplication.Models.ValueModels;

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
    }
}
