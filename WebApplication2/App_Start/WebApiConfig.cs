﻿using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // remove xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //for cross origin connection //mirosoft.aspnet.webapi.cors download
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*"); // (origin,header,method)
            config.EnableCors(cors);
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                           Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
              new DefaultContractResolver();
        }
    }
}