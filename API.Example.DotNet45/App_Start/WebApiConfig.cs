// -------------------------------------------------------------------------------------------------
//  <copyright file="WebApiConfig.cs">
//      © 2017
//  </copyright>
// -------------------------------------------------------------------------------------------------

namespace API.Example.DotNet45
{
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Routing;
    using Microsoft.Web.Http.Routing;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region Routes

            var constraintResolver = new DefaultInlineConstraintResolver
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof(ApiVersionRouteConstraint)
                }
            };

            GlobalConfiguration.Configure(s => s.MapHttpAttributeRoutes(constraintResolver, new GlobalPrefixProvider("api/v{version:apiVersion}")));

            config.AddApiVersioning();

            #endregion


            #region Json Setup

            // Remove XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // CamelCase Json
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            #endregion
        }
    }

    public class GlobalPrefixProvider : DefaultDirectRouteProvider
    {
        private readonly string globalPrefix;

        public GlobalPrefixProvider(string globalPrefix)
        {
            this.globalPrefix = globalPrefix;
        }

        protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
        {
            var existingPrefix = base.GetRoutePrefix(controllerDescriptor);

            return existingPrefix == null ? globalPrefix : $"{globalPrefix}/{existingPrefix}";
        }
    }
}