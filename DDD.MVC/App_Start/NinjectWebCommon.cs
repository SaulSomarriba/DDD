using DDD.Aplicacion.AppService;
using DDD.Aplicacion.Interface;
using DDD.Dominio.Interface.Repositories;
using DDD.Dominio.Interface.Services;
using DDD.Dominio.Servicio;
using DDD.Infra.Data.Repositorios;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace DDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
            //Objetos Base
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            #region General

            kernel.Bind<IBancoAppService>().To<BancoAppService>();
            kernel.Bind<IBancoService>().To<BancoService>();
            kernel.Bind<IBancoRepository>().To<BancoRepository>();

            kernel.Bind<ITipoBancoAppService>().To<TipoBancoAppService>();
            kernel.Bind<ITipoBancoService>().To<TipoBancoService>();
            kernel.Bind<ITipoBancoRepository>().To<TipoBancoRepository>();

            #endregion General
        }
    }
}
