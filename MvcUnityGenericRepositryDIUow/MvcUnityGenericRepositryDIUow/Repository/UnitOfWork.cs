using MvcUnityGenericRepositryDIUow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnityGenericRepositryDIUow.DAL
{
    //public class UnitOfWork<T> :IDisposable where T:class
    public class UnitOfWork :IUnitOfWork 
    {        
        //private TestDBEntities context;
        private DbContext context;
        //private GenericRepository<T> myRepository;

        //public GenericRepository<T> MyRepository
        //{
        //    get
        //    {
        //        if (this.myRepository == null)
        //            this.myRepository = new GenericRepository<T>(context);
        //        return myRepository;
        //    }
        //}


        public IGenericRepository<T> MyRepo<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }

        //public UnitOfWork(TestDBEntities context)
        //{
        //    this.context = context;
        //}

        //public UnitOfWork(DbContext context)
        //{
        //    this.context = context;
        //}


        public UnitOfWork()
        {
            this.context = new TestDBEntities();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
