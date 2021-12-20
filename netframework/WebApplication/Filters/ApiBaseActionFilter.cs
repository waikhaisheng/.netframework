using Common.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApplication.Models.CommonModels;
using WebApplication.Models.Enums;

namespace WebApplication.Filters
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211211
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20211216
    /// </summary>
    public class ApiBaseActionFilter : ActionFilterAttribute, IActionFilter
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211216
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                var errorRes = new ResponseBase();
                IEnumerable<string> modelStateErrors = from state in filterContext.ModelState.Values
                                                        from error in state.Errors
                                                        where !string.IsNullOrEmpty(error.ErrorMessage)
                                                        select error.ErrorMessage;
                string errorStr = JsonConvert.SerializeObject(modelStateErrors);
                IEnumerable<string> modelStateException = from state in filterContext.ModelState.Values
                                                       from error in state.Errors
                                                       where null != error.Exception
                                                          select error.Exception.Message;
                string errorEx = JsonConvert.SerializeObject(modelStateException);
                try
                {
                    errorRes = JsonConvert.DeserializeObject<ResponseBase>(errorStr);
                    if (errorRes == null && errorEx != null)
                    {
                        errorRes = new ResponseBase(ApiStatusEnum.Error, errorEx);
                    }
                }
                catch (Exception)
                {
                    errorRes = new ResponseBase(ApiStatusEnum.Error, errorStr);
                }
                filterContext.Response = filterContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest, 
                    errorRes, 
                    filterContext.ControllerContext?.Configuration?.Formatters?.JsonFormatter);
                return;
            }

            var reqMethod = filterContext.ActionDescriptor?.ActionName;
            var reqHeader = filterContext.Request.Headers.TryGetValues("TestKey", out IEnumerable<string> headerValues);

            var reqValue = string.Empty;

            using (var stream = new MemoryStream())
            {
                var hasMS_HttpContext = filterContext.Request.Properties.TryGetValue("MS_HttpContext", out object contextObj);
                if (hasMS_HttpContext)
                {
                    var context = contextObj as HttpContextBase;
                    if (context != null)
                    {
                        context.Request.InputStream.Seek(0, SeekOrigin.Begin);
                        context.Request.InputStream.CopyTo(stream);
                        reqValue = Encoding.ASCII.GetString(stream.ToArray());
                    }
                }
            }

            dynamic data = JsonConvert.DeserializeObject(reqValue);

            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211211
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}