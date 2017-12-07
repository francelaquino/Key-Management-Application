using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KeyIssuingAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                           name: "CustomActionApi",
                           routeTemplate: "api/{controller}/{action}");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi1",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
              name: "DefaultApi2",
              routeTemplate: "api/{controller}/{action}/{id}/{gid}",
              defaults: new { id = RouteParameter.Optional, gid = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
              name: "DefaultApi3",
              routeTemplate: "api/{controller}/{action}/{id}/{gid}/{hid}",
              defaults: new { id = RouteParameter.Optional, gid = RouteParameter.Optional, hid = RouteParameter.Optional }
          );
           

           
            var enableCorsAttribute = new EnableCorsAttribute("*",
                                               "Origin, Content-Type, Accept",
                                               "GET, PUT, POST, DELETE, OPTIONS");
        }


    }
}
