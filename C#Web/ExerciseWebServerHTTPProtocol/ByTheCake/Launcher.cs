namespace WebServer
{
    using System;
    using System.Collections.Generic;
    using ByTheCake.Application;
    using ByTheCake.Server;
    using ByTheCake.Server.Contracts;
    using ByTheCake.Server.Routing;

    public class Launcher : IRunnable
    {
        private WebServer webServer;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            var app = new MainApplication();
            var routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new WebServer(8230, routeConfig);
            this.webServer.Run();
        }
    }
}
