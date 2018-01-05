using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace api_demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Setting up JSON serialization
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase, true, "application/json"));


            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DemoApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
