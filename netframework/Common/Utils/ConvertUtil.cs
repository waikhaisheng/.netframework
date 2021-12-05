using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211204
    /// Updated: 20211205
    /// </summary>
    public static class ConvertUtil
    {
        /// <summary>
        /// Standard unit in gram
        /// </summary>
        public const double OunceUnit = 28.3495;
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="oz"></param>
        /// <returns></returns>
        public static double OunceToGram(this double oz)
        {
            return oz * OunceUnit;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="oz"></param>
        /// <param name="significantDigits"></param>
        /// <returns></returns>
        public static double OunceToGram(this double oz, ushort significantDigits)
        {
            return Math.Round(oz * OunceUnit, significantDigits);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double GramToOunce(this double g)
        {
            return g / OunceUnit;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="significantDigits"></param>
        /// <returns></returns>
        public static double GramToOunce(this double g, ushort significantDigits)
        {
            return Math.Round(g / OunceUnit, significantDigits);
        }
    }
}
