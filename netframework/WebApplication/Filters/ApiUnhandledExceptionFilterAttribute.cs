using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using WebApplication.Models.CommonModels;
using WebApplication.Models.Enums;

namespace WebApplication.Filters
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211209
    /// UpdatedBy: 
    /// Updated: 
    /// </summary>
    public class ApiUnhandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211209
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var response = new ResponseBase();
            if (filterContext != null && filterContext.Exception != null)
            {
                if (filterContext.Exception is AggregateException)
                {
                    var ex = filterContext.Exception as AggregateException;
                    if (ex.InnerExceptions != null && ex.InnerExceptions.Any())
                    {
                        foreach (var innerException in ex.InnerExceptions)
                        {
                            response = new ResponseBase(ApiStatusEnum.Error, innerException.Message);
                            filterContext.Response = filterContext.Request.CreateResponse(
                                HttpStatusCode.BadRequest, 
                                response, 
                                filterContext.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
                            return;
                        }
                    }
                }

                var exceptionMessage = filterContext.ActionContext.ModelState.Values
                    .SelectMany(x => x.Errors).Where(y => y.Exception != null).Select(m => m.Exception).FirstOrDefault();
                response = new ResponseBase(ApiStatusEnum.Error, filterContext.Exception.Message);
                filterContext.Response = filterContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    response,
                    filterContext.ActionContext.ControllerContext.Configuration?.Formatters?.JsonFormatter);
                return;
            }

            response = new ResponseBase(ApiStatusEnum.Error, ApiStatusEnum.Error.GetEnumDescription());
            filterContext.Response = filterContext.Request.CreateResponse(
                HttpStatusCode.BadRequest,
                response,
                filterContext.ActionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            return;
        }
    }
}