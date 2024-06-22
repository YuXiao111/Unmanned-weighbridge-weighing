using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Sqlite.Repositories
{
    /// <summary>
    /// 基类
    /// </summary>
    public abstract class RepositoryBase
    {
        //Lazy
        protected static SqliteDbContext db {  get; set; }=new Lazy<SqliteDbContext>().Value;
    }
}
