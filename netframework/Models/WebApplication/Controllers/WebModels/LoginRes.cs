using Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WebApplication.Controllers.WebModels
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211223
    /// UpdatedBy:
    /// Updated:
    /// </summary>
    public class LoginRes : ResponseBase
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public string Token { get; set; }
    }
}
