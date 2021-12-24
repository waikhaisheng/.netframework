using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Filters;
using Models.Enums;
using Models.WebApplication.Controllers.ValuesModels;
using System.Web.Http.Cors;//Microsoft.AspNet.WebApi.Cors

namespace WebApplication.Controllers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211209
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20211219
    /// </summary>
    //[EnableCors(origins: "http://localhost:4200",
    //    headers: "accept,content-type,origin,x-my-header",
    //    methods: "get,post,put,delete")]
    [ApiCorsPolicy]
    [RoutePrefix("api/value")]
    [ApiBaseActionFilter]
    [ApiUnhandledExceptionFilter]
    [AllowAnonymous]
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
        /// Created: 20211219
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var ret = new ValueRes(ApiStatusEnum.OK, $"Custom desc {id}");
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

        #region Action
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211219
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("Action")]
        public IHttpActionResult Action()
        {
            var ret = new ValueRes(ApiStatusEnum.OK, $"Action {Guid.NewGuid()}");
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211219
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("Action/{id}")]
        public IHttpActionResult Action(int id)
        {
            var ret = new ValueRes(ApiStatusEnum.OK, $"Action {id}");
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211219
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("Action/{id}/{name}")]
        public IHttpActionResult Action(int id, string name)
        {
            var ret = new ValueRes(ApiStatusEnum.OK, $"Action {id} {name}");
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211219
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Action")]
        public IHttpActionResult ActionPost(ValueReq obj)
        {
            var objStr = JsonConvert.SerializeObject(obj);
            var ret = new ValueRes(ApiStatusEnum.OK, $"ActionPost {objStr}");
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211219
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Action")]
        public IHttpActionResult ActionPut(ValueReq obj)
        {
            var objStr = JsonConvert.SerializeObject(obj);
            var ret = new ValueRes(ApiStatusEnum.OK, $"ActionPut {objStr}");
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211219
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Action/{id}")]
        public IHttpActionResult ActionDelete(Guid id)
        {
            var ret = new ValueRes(ApiStatusEnum.OK, $"ActionDelete {id}");
            return Ok(ret);
        }
        #endregion
    }
}
