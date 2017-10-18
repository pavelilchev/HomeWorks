namespace ByTheCake.Server.Handlers
{
    using System.Text.RegularExpressions;
    using Handlers.Contracts;
    using HTTP.Contracts;
    using Routing.Contracts;
    using HTTP.Response;

    public class HttpHandler : IRequestHandler
    {
        private static string ImagesDirectory = "/Application/Resources/Images/";

        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWith(ImagesDirectory))
            {
                return new ImageResponse(httpContext.Request.Path);
            }

            foreach (var kvp in this.serverRouteConfig.Routes[httpContext.Request.RequestMethod])
            {
                string pattern = kvp.Key;
                var regex = new Regex(pattern);
                var match = regex.Match(httpContext.Request.Path);

                if (!match.Success)
                {
                    continue;
                }

                foreach (var parameter in kvp.Value.Parameters)
                {
                    httpContext.Request.AddUrlParameters(parameter, match.Groups[parameter].Value);
                }

                return kvp.Value.RequestHandler.Handle(httpContext);
            }

            return new NotFoundResponse();
        }
    }
}
