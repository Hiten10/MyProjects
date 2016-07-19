using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnityGenericRepositryDIUow.Service
{
    public interface IService<T> where T:class
    {
        IEnumerable<T> Get();
        T FindByID(int id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        void Delete(T obj);
    }
}
