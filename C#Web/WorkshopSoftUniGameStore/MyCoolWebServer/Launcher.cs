namespace MyCoolWebServer
{
    using MyCoolWebServer.GameStore;
    using MyCoolWebServer.Server;
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Routing;

    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            var mainApplication = new GameStoreApp();
            mainApplication.InitializeDatabase();

            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}
