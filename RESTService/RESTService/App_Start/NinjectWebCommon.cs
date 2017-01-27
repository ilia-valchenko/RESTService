[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RESTService.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RESTService.App_Start.NinjectWebCommon), "Stop")]

namespace RESTService.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Infrastructure;
    using System.Web.Http;
    using ORM;
    using DAL.Interfacies.Repository;
    using DAL.Concrete;
    using System.Data.Entity;
    using DAL.Interfacies.Repository.ModelRepository;
    using DAL.Concrete.ModelRepository;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<TodoListDbContext>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
        }
    }
}
