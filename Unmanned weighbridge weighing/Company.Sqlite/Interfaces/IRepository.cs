using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Sqlite.Interfaces
{
    //泛型接口
    public interface IRepository<T>where T : class
    {
        T Get(int id);
        int Update(T entity);
        int Delete(T entity);
        int Insert(T entity);
        List<T> GetAll();
        //List<T> FindAll();
        List<T> GetAll(string keyword);

        T Select(string keyword);
    }
}
