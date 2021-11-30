using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class JsonHelper
    {
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
