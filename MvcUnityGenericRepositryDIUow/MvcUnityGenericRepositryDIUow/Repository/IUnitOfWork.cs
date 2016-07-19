using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnityGenericRepositryDIUow.DAL
{
    public interface IUnitOfWork:IDisposable
    {
        void Save();
        IGenericRepository<T> MyRepo<T>() where T : class;
    }
}
