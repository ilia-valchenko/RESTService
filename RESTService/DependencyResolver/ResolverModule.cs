using Ninject;
using Ninject.Web.Common;
using System.Data.Entity;
using DAL.Concrete.ModelRepository;
using DAL.Interfacies.Repository;
using DAL.Interfacies.Repository.ModelRepository;
using DAL.Concrete;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        public static void Configure(IKernel kernel, bool isWeb)
        {
            if(isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<TodoListDbContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<TodoListDbContext>().InSingletonScope();
            }

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
        }
    }
}
