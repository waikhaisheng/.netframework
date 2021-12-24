using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
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
    public class TestJwtManager
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestSecret()
        {
            var assertJwtSecret = ConfigurationManager.AppSettings["JwtSecret"];
            var secretField = typeof(JwtManager).GetField("Secret",
                            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField);

            var val = secretField.GetValue(null);

            Assert.AreEqual(assertJwtSecret, val);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGenerateToken()
        {
            var username = "testUser";

            var token = JwtManager.GenerateToken(username);

            Assert.IsNotNull(token);
            Assert.IsTrue(token.Length > 0);
        }

    }
}
