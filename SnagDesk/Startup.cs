using System.Web.Http;
using Microsoft.Owin;
using Owin;
using SnagDesk;

[assembly: OwinStartup(typeof(Startup))]
namespace SnagDesk
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            NlogConfig.Configure();
            WebApiConfig.Configure(config);
            AutofacConfig.Configure(app, config);

            app.UseWebApi(config);
        }
    }
}