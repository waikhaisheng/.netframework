using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class DatetimeUtil
    {
        public static long ToTick(this DateTime d)
        {
            return d.Ticks;
        }
    }
}
