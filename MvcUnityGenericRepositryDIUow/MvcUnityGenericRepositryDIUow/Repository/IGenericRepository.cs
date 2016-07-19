using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnityGenericRepositryDIUow.DAL
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> Get();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }

    //class Test<TEntity> : Atest, IGenericRepository<TEntity> where TEntity : class
    //{

    //    public IEnumerable<TEntity> Get()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public virtual IEnumerable<TEntity> Get()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void MyTest()
    //    {
    //    }

    //    public new void MyTest1()
    //    {
    //        base.MyTest1();
    //    }
    //}

    //abstract class Atest
    //{
    //    public abstract void MyTest();
    //    public virtual void MyTest1()
    //    {
    //    }
    //}
}
