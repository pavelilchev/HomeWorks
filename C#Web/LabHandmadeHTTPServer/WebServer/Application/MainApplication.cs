namespace WebServer.Application
{
    using WebServer.Application.Controllers;
    using WebServer.Server.Contracts;
    using WebServer.Server.Handlers;
    using WebServer.Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute(
                "/register",
                new PostHandler(
                    httpRequest => new UserController()
                    .RegisterPost(httpRequest.FormData["name"])));

            appRouteConfig.AddRoute(
                "/register",
                new GetHandler(httpRequest => new UserController().RegisterGet()));

            appRouteConfig.AddRoute(
               "/user/{(?<name>[a-z]+)}",
               new GetHandler(httpRequest => new UserController().Details(httpRequest.UrlParameters["name"])));
        }
    }
}
