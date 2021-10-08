using ServiceCL.Services;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace TrainingProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IFileService, FileService>( new TransientLifetimeManager());
            container.RegisterType<IFolderService, FolderService>(new TransientLifetimeManager());
            container.RegisterType<IRouteService, RouteService>(new TransientLifetimeManager());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}