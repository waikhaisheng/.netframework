using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    public static class JsonHelper
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211130
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T GetConfig<T>(string path)
        {
            T res = default;

            if (!File.Exists(path))
            {
                return default(T);
            }

            var configStr = File.ReadAllText(path);
            res = JsonConvert.DeserializeObject<T>(configStr);
            return res;
        }
    }
}
