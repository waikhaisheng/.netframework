using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.CommonModels;
using WebApplication.Models.Enums;

namespace WebApplication.Models.ValueModels
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// UpdatedBy:
    /// Updated:
    /// </summary>
    public class ValueRes : ResponseBase
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public ValueRes() : base()
        {

        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDesc"></param>
        public ValueRes(ApiStatusEnum statusCode, string statusDesc) : base(statusCode, statusDesc)
        {

        }
    }
}