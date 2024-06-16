using Company.Sqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unmanned_weighbridge_weighing.Interfaces
{
    /// <summary>
    /// 会话缓存
    /// </summary>
    public interface ISession
    {
        string Title { get; set; }
        User CurrentUser { get; set; }
    }
}
