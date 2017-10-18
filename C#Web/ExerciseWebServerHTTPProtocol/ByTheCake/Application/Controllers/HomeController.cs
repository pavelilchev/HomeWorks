namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Application.Views;
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.HTTP.Contracts;
    using ByTheCake.Server.HTTP.Response;

    public class HomeController
    {
		public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }

        public IHttpResponse About()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeAboutView());
        }
    }
}
