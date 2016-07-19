using MvcUnityGenericRepositryDIUow.DAL;
using MvcUnityGenericRepositryDIUow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcUnityGenericRepositryDIUow.Service
{
    public class Service<T>:IService<T> where T:class
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<T> repository;
        //TestDBEntities db;
 
        public Service(IUnitOfWork unitOfWork)
        {
            //db = new TestDBEntities();
            this.unitOfWork = unitOfWork;
            this.repository = unitOfWork.MyRepo<T>();
        }
          
        public IEnumerable<T> Get()
        {            
            var result = repository.Get().ToList();
            return result;
        }

        public T FindByID(int id)
        {
            var result = repository.GetByID(id);
            return result;
        }
       

        public void Add(T obj)
        {
            repository.Insert(obj);
            unitOfWork.Save();
        }

        public void Update(T obj)
        {
            repository.Update(obj);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            unitOfWork.Save();
        }

        public void Delete(T obj)
        {
            repository.Delete(obj);
            unitOfWork.Save();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var result = repository.FindBy(predicate);

            return result;
        }
    }
}