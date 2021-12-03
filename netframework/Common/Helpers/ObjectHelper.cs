using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211130
    /// Updated: 20211203
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// Created: 20211203
        /// Updated: 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetCurrentClassName(this object obj)
        {
            return obj.GetType().Name;
        }
        /// <summary>
        /// Created: 20211203
        /// Updated: 
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            return methodBase.Name;
        }
        /// <summary>
        /// Created: 20211203
        /// Updated: 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
        /// <summary>
        /// Created: 20211203
        /// Updated: 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetHash(this object obj)
        {
            return obj.GetHashCode();
        }
    }
}
