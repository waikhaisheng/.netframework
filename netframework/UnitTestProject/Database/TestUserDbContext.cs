using Database.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DatabaseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication;

namespace UnitTestProject.Database
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211222
    /// UpdatedBy:
    /// Updated:
    /// </summary>
    [TestClass]
    public class TestUserDbContext
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private static UserDbContext _dbContext = new UserDbContext("Data Source=localhost;Initial Catalog=.netframework;User Id=sa;Password=pass123;");
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private List<User> _usrs = new List<User>
        {
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Email = $"unittest1@gmail.com",
                Password = $"test123",
                Username = $"unittest1"
            },
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Email = $"unittest2@gmail.com",
                Password = $"test123",
                Username = $"unittest2"
            },
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Email = $"unittest3@gmail.com",
                Password = $"test123",
                Username = $"unittest3"
            },
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Email = $"unittest4@gmail.com",
                Password = $"test123",
                Username = $"unittest4"
            },
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Email = $"unittest5@gmail.com",
                Password = $"test123",
                Username = $"unittest5"
            }
        };
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        [TestMethod]
        public void TestUser()
        {
            var usr = new User
            {
                Id = Guid.NewGuid(),
                Email = "TestUser@gmail.com",
                Password = "test123",
                Username = "TestUser"
            };
            var addUsr = _dbContext.AddUser(usr);
            Assert.IsNotNull(addUsr);

            //login
            var loginUsr = _dbContext.Login(usr.Email, usr.Password);
            Assert.AreEqual(usr.Id, loginUsr.Id);

            //update
            usr.Email = "update@gmail.com";
            usr.Password = "update123";
            usr.Username = "updateusr";
            var updateUsr = _dbContext.UpdateUser(usr);
            Assert.IsNotNull(updateUsr);

            //remove
            var removeUsr = _dbContext.RemoveUser(usr.Id);
            Assert.IsTrue(removeUsr);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        [TestMethod]
        public void TestParallelRequest()
        {
            TestParallelRequest_Source_Add();
            TestParallelRequest_Source_Remove();
        }
        [TestMethod]
        public void TestRemoveUser()
        {

        }
        [TestMethod]
        public void TestUpdateUser()
        {

        }
        [TestMethod]
        public void TestLogin()
        {

        }

        #region Private Testcases
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private void TestParallelRequest_Source_Add()
        {
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 10 };
            Parallel.ForEach(_usrs, parallelOptions, paramObj =>
            {
                // Arrange
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var server = new HttpServer(config);
                var url = $"https://localhost/api/web/TestAddUser";
                var httpMethod = HttpMethod.Post;
                var httpClient = new HttpClient(server);
                HttpStatusCode statusCode = HttpStatusCode.BadRequest;
                // Act
                using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
                {
                    httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json");

                    var response = httpClient.SendAsync(httpReqMsg).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        var ret = JsonConvert.DeserializeObject(responseContent);
                        statusCode = response.StatusCode;
                        Assert.AreEqual(HttpStatusCode.OK, statusCode);
                    }
                    System.Diagnostics.Debug.WriteLine($"i: {paramObj.Username}, {response.IsSuccessStatusCode}");
                }

            });
            // Assert
            Assert.AreEqual(1, 1);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private void TestParallelRequest_Source_Remove()
        {
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 10 };
            Parallel.ForEach(_usrs, parallelOptions, paramObj =>
            {
                // Arrange
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var server = new HttpServer(config);
                var url = $"https://localhost/api/web/TestRemoveUser";
                var httpMethod = HttpMethod.Post;
                var httpClient = new HttpClient(server);
                HttpStatusCode statusCode = HttpStatusCode.BadRequest;
                // Act
                using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
                {
                    httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json");

                    var response = httpClient.SendAsync(httpReqMsg).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        var ret = JsonConvert.DeserializeObject(responseContent);
                        statusCode = response.StatusCode;
                        Assert.AreEqual(HttpStatusCode.OK, statusCode);
                    }
                    System.Diagnostics.Debug.WriteLine($"i: {paramObj.Username}, {response.IsSuccessStatusCode}");
                }

            });
            // Assert
            Assert.AreEqual(1, 1);
        }
        #endregion
    }
}
