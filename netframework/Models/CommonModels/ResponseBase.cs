using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommonModels
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211209
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20211223
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        public ResponseBase() { }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
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
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        public string ServerTime
        {
            get { return DateTime.Now.ToString("O"); }
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        public ApiStatusEnum StatusCode { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        public string StatusDesc { get; set; }
    }
}
