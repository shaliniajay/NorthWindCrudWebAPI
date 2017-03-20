using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NorthWindWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var formatters = GlobalConfiguration.Configuration.Formatters;

            formatters.Remove(formatters.XmlFormatter);
            //formatter.SerializerSettings.ContractResolver =
            //    new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(newMediaTypeHeaderValue("text/html"));
        }
    }
}
