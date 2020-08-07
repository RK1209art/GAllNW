﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPIDemonstration_1.UtilityClasses;

namespace WebAPIDemonstration_1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            config.DependencyResolver = new CustomDependencyResolver();

            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}