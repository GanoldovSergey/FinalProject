using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Ninject;
using Ninject.Web.Common;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            Configure();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Configure()
        {
            kernel.Bind<DbContext>().To<Context>().InRequestScope();
            kernel.Bind<IFileRepository>().To<FileRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
        }
    }
}