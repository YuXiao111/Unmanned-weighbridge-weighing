using Company.Sqlite.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Sqlite
{
    public class SqliteDbContext : DbContext
    {
        //读取配置文件connectionString，创建数据库映射
        public SqliteDbContext() : base("SqliteDbContext")
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //注入我们设置的SqliteDbContext，判断数据库是否存在？不存在则创建
            var sqliteConnect = new SqliteCreateDatabaseIfNotExists<SqliteDbContext>(modelBuilder);
            //执行
            Database.SetInitializer(sqliteConnect);
        }


    }
}
