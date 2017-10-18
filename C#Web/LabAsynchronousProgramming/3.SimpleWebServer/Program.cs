namespace _3.SimpleWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var address = IPAddress.Parse("127.0.0.1");
            var port = 1330;
            var listener = new TcpListener(address, port);
            listener.Start();

            Console.WriteLine($"Server listen at {address}:{port}");

            Task
                .Run(async () => await ConnectWithTcpClient(listener))
                .GetAwaiter()
                .GetResult();
        }

        public static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected");

                var buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, buffer.Length);

                var message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(message);

                var response = @"HTTP/1.1 200 OK
Content-Type: text/plain

Hello from server!";

                var data = Encoding.UTF8.GetBytes(response);
                client.GetStream().Write(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }
    }
}
