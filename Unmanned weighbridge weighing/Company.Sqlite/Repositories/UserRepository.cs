using Company.Sqlite.Interfaces;
using Company.Sqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Sqlite.Repositories
{
    public class UserRepository :RepositoryBase, IUserRepository
    {
        //SqliteDbContext db = new SqliteDbContext();
        public int Delete(User entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

      public  List<User> GetAll(string keyword)
        {
           return db.Users.ToList().Where(t=>t.UserName.Contains(keyword)).ToList();
        }

        public int Insert(User entity)
        {
            db.Users.Add(entity);
            return db.SaveChanges();
        }

      public  User Select(string keyword)
        {
            return db.Users.ToList().Find(t => t.UserName == keyword);
        }

        public int Update(User entity)
        {
            db.Entry(entity).State=System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
