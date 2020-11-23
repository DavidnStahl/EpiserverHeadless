using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiHeadless.Business.Rendering;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;

//using EPiServer.ContentApi.Infrastructure;
using EPiServer.ContentApi.Cms;
using System.Web.Http;
using Newtonsoft.Json;
using EPiHeadless.Business.WebApi;
using EPiServer.ContentApi.Routing;
using EPiServer.ContentApi.Core.Configuration;

namespace EPiHeadless.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(ContentApiCmsInitialization))]
    public class DependencyResolverInitialization : IConfigurableModule
    {

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            //Implementations for custom interfaces can be registered here.
            context.Services.Configure<ContentApiConfiguration>(config =>
            {
                config.Default().SetMinimumRoles(string.Empty);
            });

            context.ConfigurationComplete += (o, e) =>
            {
                //Register custom implementations that should be used in favour of the default implementations
                context.Services.AddTransient<IContentRenderer, ErrorHandlingContentRenderer>()
                    .AddTransient<ContentAreaRenderer, AlloyContentAreaRenderer>();

            };
        }

        public void Initialize(InitializationEngine context)
        {
            DependencyResolver.SetResolver(new ServiceLocatorDependencyResolver(context.Locate.Advanced));
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
