using Common.Helpers;
using Models.DatabaseModels;
using Models.WebApplication.Controllers.WebModels;
using Newtonsoft.Json;
using Services.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Filters;
using Models.CommonModels;
using Models.Enums;
using Common.Tools;
using Database.FileConfigs;
using Common.Utils;

namespace WebApplication.Controllers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// Updated: 
    /// </summary>
    [RoutePrefix("api/web")]
    [ApiUnhandledExceptionFilter]
    [AllowAnonymous]
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
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 202112019
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestGet")]
        public IHttpActionResult TestGet()
        {
            var a = Convert.ToInt32("a");
            return Ok("Ok");
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser(User usr)
        {
            //var css = ConfigurationManager.ConnectionStrings["LocalSqlServer"]?.ConnectionString;
            var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            var usrSer = new UserService(cs);
            usrSer.AddUser(usr);
            return Ok("Ok");
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("RemoveUser")]
        public IHttpActionResult TestRemoveUser(User usr)
        {
            var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            var usrSer = new UserService(cs);
            usrSer.RemoveUser(usr);
            return Ok("Ok");
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(LoginReq req)
        {
            var ret = new LoginRes();
            var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            var usrSer = new UserService(cs);
            var user = usrSer.UserLogin(req.Email, req.Password);
            if (user.Username != null)
            {
                ret.StatusCode = ApiStatusEnum.OK;
                ret.StatusDesc = ApiStatusEnum.OK.GetEnumDescription();
                ret.Token = JwtManager.GenerateToken(user.Username);
                return Ok(ret);
            }
            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
            ret.StatusCode = ApiStatusEnum.Error;
            ret.StatusDesc = ApiStatusEnum.Error.GetEnumDescription();
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211224
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LoginAuthenticate")]
        [JwtAuthentication]
        public IHttpActionResult LoginAuthenticate()
        {
            var ret = new ResponseBase(ApiStatusEnum.OK, ApiStatusEnum.OK.GetEnumDescription());
            return Ok(ret);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220106
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetConfig")]
        public IHttpActionResult GetConfig()
        {
            var ret = FileSystemWatcherConfig.DictConfigInstance?.ObjectData;
            return Ok(ret);
        }
    }
}
