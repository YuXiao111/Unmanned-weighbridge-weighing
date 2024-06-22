using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Config
{
    /// <summary>
    /// JSON配置助手
    /// </summary>
    public interface IConfigManager
    {
        T Read<T>(ConfigKey key);
        void Write<T>(ConfigKey key, object value);
    }
}
