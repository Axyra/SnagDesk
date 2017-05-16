using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using NLog;
using Owin;
using SnagDesk.DAL.EntityFramework;
using SnagDesk.DAL.Repositories;
using SnagDesk.Extensions.Filters;

namespace SnagDesk
{
    public static class AutofacConfig
    {
        public static void Configure(IAppBuilder app, HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterDependencies(builder);

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(configuration);
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<SnagdeskDb>().As<DbContext>().InstancePerRequest();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IRepository<,>)))
                .Where(c => c.Namespace?.Contains("EntityFramework") == true && c.Name.Contains("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            Mapper.Initialize(c => c.AddProfiles(Assembly.GetExecutingAssembly()));

            builder.Register(c => Mapper.Instance).As<IMapper>().SingleInstance();
        }
    }
}