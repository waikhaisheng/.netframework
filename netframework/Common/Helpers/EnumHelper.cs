using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211130
    /// Updated: 
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211130
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String GetEnumDescription(this Enum obj)
        {
            System.Reflection.FieldInfo fieldInfo = obj.GetType().GetField(obj.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length > 0)
            {
                var attrib = attribArray[0] as DescriptionAttribute;

                if (attrib != null)
                    return attrib.Description;
            }
            return obj.ToString();
        }

    }
}
