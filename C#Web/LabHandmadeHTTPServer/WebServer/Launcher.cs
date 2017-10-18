namespace WebServer
{
    using System;
    using System.Collections.Generic;
    using WebServer.Application;
    using WebServer.Server;
    using WebServer.Server.Contracts;
    using WebServer.Server.Routing;

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
