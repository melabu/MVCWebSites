using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCClinica
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Rutas Personalizadas
            routes.MapRoute(
                name: "TraerNombreCompleto",
                url: "{controller}/TraerNombreCompleto/{name}/{lastName}",
                defaults: new { controller = "Medico", action = "SearchByNombreCompleto" }
            );

            routes.MapRoute(
                name: "TraerPorEspecialidad",
                url: "{controller}/TraerPorEspecialidad/{especialidad}",
                defaults: new { controller = "Medico", action = "SearchByEspecialidad" }
            );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
