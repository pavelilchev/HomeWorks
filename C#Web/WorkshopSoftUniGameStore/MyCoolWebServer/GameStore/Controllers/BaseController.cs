namespace MyCoolWebServer.GameStore.Controllers
{
    using MyCoolWebServer.Infrastructure;

    public class BaseController : Controller
    {
        protected override string ApplicationDirectory => "GameStore";
    }
}
