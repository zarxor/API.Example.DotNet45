// -------------------------------------------------------------------------------------------------
//  <copyright file="Startup.cs">
//      © 2017
//  </copyright>
// -------------------------------------------------------------------------------------------------

using API.Example.DotNet45;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace API.Example.DotNet45
{
    using System.Web.Http;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}