using Microsoft.Practices.Unity;
using MvcUnityGenericRepositryDIUow.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc4;
using MvcUnityGenericRepositryDIUow.Service;
using MvcUnityGenericRepositryDIUow.Models;

namespace MvcUnityGenericRepositryDIUow
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //TestDBEntities db = new TestDBEntities();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            var container = new UnityContainer();
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(),
            // new InjectionConstructor(db));
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            container.RegisterType(typeof(IService<>), typeof(Service<>), new InjectionConstructor(typeof(IUnitOfWork)));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}