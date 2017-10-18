namespace ByTheCake.Server
{
    using Contracts;
    using global::ByTheCake.Server.Routing;
    using Routing.Contracts;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System;

    public class WebServer : IRunnable
    {
        private const string  IP = "127.0.0.1";
        private readonly int port;
        private readonly IServerRouteConfig serverRouteConfig;
        private readonly TcpListener tcpListener;
        private bool isRuning;

        public WebServer(int port, IAppRouteConfig routeConfig)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse(IP), port);

            this.serverRouteConfig = new ServerRouteConfig(routeConfig);
        }

        public void Run()
        {
            this.tcpListener.Start();
            this.isRuning = true;

            Console.WriteLine($"Server started. Listening to TCP clients at {IP}:{port}");

            Task.Run(this.ListenLoop).Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRuning)
            {
                try
                {
                    var client = await this.tcpListener.AcceptSocketAsync();
                    var connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);
                    await connectionHandler.ProcessRequestAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
