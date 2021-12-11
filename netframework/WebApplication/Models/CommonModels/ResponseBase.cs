using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Enums;

namespace WebApplication.Models.CommonModels
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211209
    /// UpdatedBy:
    /// Updated: 
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public ResponseBase() { }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDesc"></param>
        public ResponseBase(ApiStatusEnum statusCode, string statusDesc)
        {
            StatusCode = statusCode;
            StatusDesc = statusDesc;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public string ServerTime
        {
            get { return DateTime.Now.ToString("O"); }
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public ApiStatusEnum StatusCode { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public string StatusDesc { get; set; }
    }
}