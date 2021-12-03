using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211130
    /// Updated: 
    /// </summary>
    public static class DatetimeUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211130
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long ToTick(this DateTime d)
        {
            return d.Ticks;
        }

    }
}
