using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Proj0",
                routeTemplate: "{controller}/{id}",
                defaults: new { contoller = "proj0", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Proj1",
                routeTemplate: "{controller}/{id}",
                defaults: new { contoller = "proj1", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Proj2",
                routeTemplate: "{controller}/{id}",
                defaults: new { contoller = "proj2", id = RouteParameter.Optional }
            );
        }
    }
}
