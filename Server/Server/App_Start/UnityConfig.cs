using Microsoft.Practices.Unity;
using Repository;
using Repository.Domain;
using Repository.Repositories;
using System.Data.Entity;
using System.Web.Http;
using Unity.WebApi;

namespace Server
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IFieldRepository,FieldRepository>();
            container.RegisterType<DbContext,FacilityContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IReservationRepository, ReservationRepository>();
            container.RegisterType<IUnitOfWork,UnitOfWork>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
           
        }
    }
}