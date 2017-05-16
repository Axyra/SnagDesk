using System.Web.Http;
using Newtonsoft.Json.Serialization;
using SnagDesk.Extensions.Filters;

namespace SnagDesk
{
    public static class WebApiConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new ExceptionHandleFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
