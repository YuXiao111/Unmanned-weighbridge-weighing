using Company.Core.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Config
{
    public class ConfigManager :IConfigManager
    {
        private const string root = "Config";
        public T Read<T>(ConfigKey key)
        {
            string fileName = GetFullName(key);
            return JsonHelper.Load<T>(fileName);
        }

        private string GetFullName(ConfigKey key)
        {
            string fullName = $"{root}/{key}.json";
            return fullName;
        }

        public void Write<T>(ConfigKey key, Object value)
        {
            Directory.CreateDirectory(root);
            string fileName = GetFullName(key);
            JsonHelper.Write(value, fileName, true);
        }

    }
}
