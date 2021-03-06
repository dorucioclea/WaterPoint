﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using WaterPoint.Core.Domain.Exceptions;

namespace WaterPoint.Api.Common.AppStart
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name : "DefaultApi",
            //    routeTemplate : "{controller}/{id}",
            //    defaults : new { id = RouteParameter.Optional }
            //    //,
            //    //constraints: new { accountId = @"\d+" }
            //);
            //---

            AddJsonFormatter(config);

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Filters.Add(new ApiExceptionHandlerFilterAttribute());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static void AddJsonFormatter(HttpConfiguration config)
        {
            config.Formatters.Clear();

            var jsonFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = { ContractResolver = new DeltaCamelCaseContractResolver() }
            };
            jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });

            config.Formatters.Add(jsonFormatter);
        }
    }
}
