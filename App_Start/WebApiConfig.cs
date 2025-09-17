using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace apiRESTAdminUsuarioTADS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "tads/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
