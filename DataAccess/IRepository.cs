using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        void Create(T obj);
        T ReadById(int id);
        void Delete(T obj);
        IEnumerable<T> ReadAll();
    }
}
