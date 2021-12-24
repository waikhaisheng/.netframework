using Models.CommonModels;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WebApplication.Controllers.ValuesModels
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20211223
    /// </summary>
    public class ValueRes : ResponseBase
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        public ValueRes() : base()
        {

        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDesc"></param>
        public ValueRes(ApiStatusEnum statusCode, string statusDesc) : base(statusCode, statusDesc)
        {

        }
    }
}
