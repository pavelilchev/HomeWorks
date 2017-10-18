namespace ByTheCake.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Handlers;
    using HTTP;
    using Routing.Contracts;
    using ByTheCake.Server.HTTP.Response;
    using ByTheCake.Server.Enums;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            string request = await this.ReadRequest();

            var context = new HttpContext(request);

            var handler = new HttpHandler(this.serverRouteConfig);
            var response = handler.Handle(context);

            var toBytes = new ArraySegment<byte>(Encoding.ASCII.GetBytes(response.Response));

            await this.client.SendAsync(toBytes, SocketFlags.None);
            if (response is ImageResponse && response.StatusCode == HttpStatusCode.OK)
            {
                await this.client.SendAsync(response.Data, SocketFlags.None);
            }

            Console.WriteLine(request);
            Console.WriteLine(response);

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            string request = string.Empty;
            var data = new ArraySegment<byte>(new byte[1024]);

            int numBytesRead;

            while ((numBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None)) > 0)
            {
                request += Encoding.ASCII.GetString(data.Array, 0, numBytesRead);

                if (numBytesRead < 1023)
                {
                    break;
                }
            }

            return request;
        }
    }
}
