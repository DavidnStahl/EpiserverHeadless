using EPiServer.ContentApi.Routing;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServer.Web.Routing.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiHeadless.Business.Initialization
{
    public class CustomContentApiRoutingEventHandler : RoutingEventHandler
    {
        public CustomContentApiRoutingEventHandler(
            IContentRouteEvents routeEvents,
            ServiceAccessor<HttpContextBase> httpContextAccessor,
            ContentApiRouteService contentApiRouteService)
            : base(routeEvents, httpContextAccessor, contentApiRouteService)
        {
        }

        // If language does not exists in the routing context, we return ContentLanguage.PreferredCulture as default language
        protected override string GetLanguage(SegmentContext routingContext, HttpRequestBase request)
        {
            var language = routingContext.Language ?? routingContext.ContentLanguage ?? ContentLanguage.PreferredCulture.Name;

            return language;
        }
    }
}