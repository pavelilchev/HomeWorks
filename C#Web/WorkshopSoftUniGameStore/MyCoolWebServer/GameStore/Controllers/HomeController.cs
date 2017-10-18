namespace MyCoolWebServer.GameStore.Controllers
{
    using MyCoolWebServer.Server.Http.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.FileViewResponse("home/user-home");
        }
    }
}
