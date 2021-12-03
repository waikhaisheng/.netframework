using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211202
    /// Updated: 
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211202
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool TolowerCompare(this string left, string right)
        {
            var l = left.ToLower();
            var r = right.ToLower();
            return l == r;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211202
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="wordBetween"></param>
        /// <returns></returns>
        public static string ToString(this string[] left, string wordBetween = "")
        {
            var sb = new StringBuilder();
            var stop = left.Length - 1;
            for (int i = 0; i < left.Length; i++)
            {
                sb.Append(left[i]);
                if (i < stop)
                {
                    sb.Append(wordBetween);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211202
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="wordBetween"></param>
        /// <returns></returns>
        public static string ToString(this IList<string> left, string wordBetween = "")
        {
            var sb = new StringBuilder();
            var stop = left.Count - 1;
            for (int i = 0; i < left.Count; i++)
            {
                sb.Append(left[i]);
                if (i < stop)
                {
                    sb.Append(wordBetween);
                }
            }
            return sb.ToString();
        }
    }
}
