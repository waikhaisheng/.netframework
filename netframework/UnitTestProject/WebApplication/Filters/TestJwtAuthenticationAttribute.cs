using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using WebApplication.Filters;

namespace UnitTestProject.WebApplication.Filters
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211223
    /// UpdatedBy:
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestJwtAuthenticationAttribute
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestAuthenticateAsync()
        {
            var assertUsername = "testJwtUser";
            string scheme = "Bearer";
            IPrincipal principal = null;
            var cancellationToken = new CancellationTokenSource();
            var controllerContext = new HttpControllerContext();
            var mockActionDescriptor = new Mock<HttpActionDescriptor>();
            var jwtAuthenticationAttribute = new JwtAuthenticationAttribute();
            var request = new HttpRequestMessage();
            
            string parameter = JwtManager.GenerateToken(assertUsername);
            var actionContext = new HttpActionContext(controllerContext, mockActionDescriptor.Object);
            var context = new HttpAuthenticationContext(actionContext, principal);
            request.Headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
            controllerContext.Request = request;
            jwtAuthenticationAttribute.AuthenticateAsync(context, cancellationToken.Token).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestValidateToken()
        {
            var assertUsername = "testJwtUser";
            var jwtAuthenticationAttribute = new JwtAuthenticationAttribute();
            PrivateObject privateObject = new PrivateObject(jwtAuthenticationAttribute);
            string username = string.Empty;
            var method = typeof(JwtAuthenticationAttribute).GetMethod("ValidateToken",
                            BindingFlags.NonPublic | BindingFlags.Static);
            
            var jwt = JwtManager.GenerateToken(assertUsername);
            var args = new object[] { jwt, username };
            var validateTokenMethod = method.Invoke(jwtAuthenticationAttribute, args);
            var outUsername = args[1];

            Assert.AreEqual(assertUsername, outUsername);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestChallengeAsync()
        {
            var cancellationToken = new CancellationTokenSource();
            var actionContext = new HttpActionContext();
            var jwtAuthenticationAttribute = new JwtAuthenticationAttribute();
            var request = new HttpRequestMessage();
            var mockOkResult = new Mock<OkResult>(request);
            IHttpActionResult iHttpActionResult = mockOkResult.Object;

            var context = new HttpAuthenticationChallengeContext(actionContext, iHttpActionResult);
            jwtAuthenticationAttribute.ChallengeAsync(context, cancellationToken.Token).GetAwaiter().GetResult();
        }
    }
}
