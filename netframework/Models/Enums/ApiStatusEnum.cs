using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211210
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20211223
    /// </summary>
    public enum ApiStatusEnum
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        [Description("Ok")]
        OK = 200,
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211210
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20211223
        /// </summary>
        [Description("Error")]
        Error = 400
    }
}
