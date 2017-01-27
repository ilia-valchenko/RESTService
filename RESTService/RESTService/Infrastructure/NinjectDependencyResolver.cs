using System;
using System.Collections.Generic;
using Ninject;
using DependencyResolver;
using System.Web.Http.Dependencies;

namespace RESTService.Infrastructure
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
            //kernel.ConfigurateResolverWeb();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetService(Type serviceType) => kernel.TryGet(serviceType);

        //public IEnumerable<object> GetServices(Type serviceType) => kernel.GetAll(serviceType);

        private IKernel kernel;
    }
}