using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Filters;
using WebApplication.Models.Enums;
using WebApplication.Models.ValueModels;

namespace WebApplication.Controllers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211209
    /// Updated: 20211210
    /// </summary>
    [RoutePrefix("api/[Controller]")]
    [ApiBaseActionFilter]
    [ApiUnhandledExceptionFilter]
    public class ValueController : ApiController
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var ret = new ValueRes(ApiStatusEnum.OK, "Custom desc");
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(ValueReq obj)
        {
            var objStr = JsonConvert.SerializeObject(obj);
            var ret = new ValueRes(ApiStatusEnum.OK, objStr);
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(ValueReq obj)
        {
            var objStr = JsonConvert.SerializeObject(obj);
            var ret = new ValueRes(ApiStatusEnum.OK, objStr);
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211210
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(ValueReq obj)
        {
            var objStr = JsonConvert.SerializeObject(obj);
            var ret = new ValueRes(ApiStatusEnum.OK, objStr);
            return Ok(ret);
        }
    }
}
