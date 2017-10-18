namespace ByTheCake.Application
{
    using ByTheCake.Application.Controllers;
    using ByTheCake.Server.Contracts;
    using ByTheCake.Server.Handlers;
    using ByTheCake.Server.HTTP.Response;
    using ByTheCake.Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute("/about", new GetHandler(httpContext => new HomeController().About()));

            appRouteConfig.AddRoute("/add", new GetHandler(httpContext => new CakeController().Add()));

            appRouteConfig.AddRoute(
                "/add",
                new PostHandler(
                    httpContext => new CakeController()
                    .AddPost(httpContext.FormData["name"], httpContext.FormData["price"])));

            appRouteConfig.AddRoute("/search", new GetHandler(httpContext => new CakeController().Search(httpContext.QueryParameters)));

            appRouteConfig.AddRoute("/calculator", new GetHandler(httpContext => new CalculatorController().Index()));

            appRouteConfig.AddRoute(
               "/calculator",
               new PostHandler(
                   httpContext => new CalculatorController()
                   .Calculate(httpContext.FormData["first-operand"],
                   httpContext.FormData["second-operand"],
                   httpContext.FormData["operator"])));

            //appRouteConfig.AddRoute(
            //    "/register",
            //    new GetHandler(httpRequest => new UserController().RegisterGet()));

            //appRouteConfig.AddRoute(
            //   "/user/{(?<name>[a-z]+)}",
            //   new GetHandler(httpRequest => new UserController().Details(httpRequest.UrlParameters["name"])));
        }
    }
}
