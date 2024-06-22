using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Helper
{
    /// <summary>
    /// JSON文件读写
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 读JSON文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Load<T>(string path)
        {
            if (!File.Exists(path))
            {
                return default(T);
            }

            string content = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// 将对象写成JSON文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fullName"></param>
        /// <param name="indented"></param>
        public static string Write(object obj, string fullName, bool indented = false)
        {
            Formatting f = indented ? Formatting.Indented : Formatting.None;
            var content = JsonConvert.SerializeObject(obj, f);
            File.WriteAllText(fullName, content);
            return content;
        }
    }
}
