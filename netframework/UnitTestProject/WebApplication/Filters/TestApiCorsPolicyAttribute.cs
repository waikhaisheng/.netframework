using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
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
    public class TestApiCorsPolicyAttribute
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGetCorsPolicyAsync()
        {
            var apiCorsPolicyAttribute = new ApiCorsPolicyAttribute();
            var request = new HttpRequestMessage();
            var cancellationToken = new CancellationTokenSource();

            CorsPolicy corsPolicy = apiCorsPolicyAttribute.GetCorsPolicyAsync(request, cancellationToken.Token).Result;

            Assert.IsTrue(corsPolicy.AllowAnyHeader);
            Assert.IsTrue(corsPolicy.AllowAnyMethod);
            Assert.IsTrue(corsPolicy.Origins.Count > 0);
            Assert.IsTrue(corsPolicy.Origins.Contains("http://localhost:4200"));
        }
    }
}
