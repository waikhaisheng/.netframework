using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    public class TestJwtAuthenticationFailureResult
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestJwtAuthenticationFailureResult_Ctor()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            var responseContent = new object();
            
            var ctor = new JwtAuthenticationFailureResult<object>(request, responseContent);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestExecuteAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            var responseContent = new object();
            var cancellationToken = new CancellationTokenSource();

            var jwt = new JwtAuthenticationFailureResult<object>(request, responseContent);
            jwt.ExecuteAsync(cancellationToken.Token);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestExecute()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            var responseContent = new object();
            //var cancellationToken = new CancellationTokenSource();
            var method = typeof(JwtAuthenticationFailureResult<object>).GetMethod("Execute",
                            BindingFlags.NonPublic | BindingFlags.Instance);

            var jwt = new JwtAuthenticationFailureResult<object>(request, responseContent);
            var args = new object[] { };
            var executeMethod = method.Invoke(jwt, args) as HttpResponseMessage;

            Assert.AreEqual(HttpStatusCode.Unauthorized, executeMethod.StatusCode);
        }
    }
}
