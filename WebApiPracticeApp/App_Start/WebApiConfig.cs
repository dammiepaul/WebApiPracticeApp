using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebApiPracticeApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Return JSON by default
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                                                                      .Add(new RequestHeaderMapping("Accept",
                                                                                                      "text/html",
                                                                                                      StringComparison.InvariantCultureIgnoreCase,
                                                                                                      true,
                                                                                                      "application/json"));
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();

            //Format the dates returned by the API
            jsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
