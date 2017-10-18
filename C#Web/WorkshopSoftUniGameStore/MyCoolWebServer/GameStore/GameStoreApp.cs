namespace MyCoolWebServer.GameStore
{
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.GameStore.Controllers;
    using MyCoolWebServer.GameStore.Data;
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class GameStoreApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new GameStoreContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add("/");

            appRouteConfig
                .Get("/", req => new HomeController().Index());
        }
    }
}
