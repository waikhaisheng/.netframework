using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Filters;

namespace WebApplication.Controllers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// Updated: 
    /// </summary>
    [RoutePrefix("api/web")]
    [ApiUnhandledExceptionFilter]
    public class WebController : ApiController
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            return Ok("Ok");
        }

        [HttpGet]
        [Route("TestGet")]
        public IHttpActionResult TestGet()
        {
            var a = Convert.ToInt32("a");
            return Ok("Ok");
        }
    }
}
