using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using NBT.Core.Datas;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NBT.Core.Datas.Factories;
using System.Linq;
using NBT.Core.Services.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using NBT.Core.Domain.Identity;
using Microsoft.AspNet.Identity;
using NBT.Infra.Services.Identity;
using System.Web;
using Microsoft.Owin.Security.DataProtection;
using NBT.Core.Datas.Repositories;
using NBT.Infra.Services;
using NBT.Core.Services;
using NBT.Core.Datas.Repositories.System;
using NBT.Infra.Services.System;
using System.Web.Mvc;
using System.Web.Http;
using System.Reflection;
using NBT.Core.Services.DomainServices.Security;
using NBT.Infra.Services.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Core.Services.ApplicationServices.Blog;
using NBT.Infra.Services.Blog;
using NBT.Core.Services.ApplicationServices.System;

[assembly: OwinStartup(typeof(NBT.Web.App_Start.Startup))]

namespace NBT.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
            ConfigurationAuth(app);
            UpdateMigration();
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var assembliesGtripWebApi = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("NBT.Web.Api"));
            builder.RegisterApiControllers(assembliesGtripWebApi.ToArray());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<MasterDBContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<PermissionProvider>().As<IPermissionProvider>().InstancePerRequest();
            builder.RegisterType<TourTypeProvider>().As<ITourTypeProvider>().InstancePerRequest();
            builder.RegisterType<BlogPostTypeProvider>().As<IBlogPostTypeProvider>().InstancePerRequest();
            builder.RegisterType<SettingsProvider>().As<ISettingsProvider>().InstancePerRequest();

            builder.RegisterType<RoleStore<AppRole>>().As<IRoleStore<AppRole, string>>();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<AppUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IService<>)).InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(ErrorRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(ErrorService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }

        private void UpdateMigration()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MasterDBContext, NBT.Core.Datas.Migrations.Configuration>());
        }
    }
}
