using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;


namespace RESTService.Infrastructure
{
    public class NinjectDependencyScope : IDependencyScope
    {
        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public void Dispose()
        {
            IDisposable disposable = resolver as IDisposable;

            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed.");

            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return resolver.GetAll(serviceType);
        }

        private IResolutionRoot resolver;
    }
}