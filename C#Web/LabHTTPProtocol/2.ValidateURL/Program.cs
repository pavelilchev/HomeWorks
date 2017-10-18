using System;
using System.Net;

namespace _2.ValidateURL
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(url);

            try
            {
                var uri = new Uri(decodedUrl);
                if (string.IsNullOrWhiteSpace(uri.Scheme)
                    || string.IsNullOrWhiteSpace(uri.Host)
                    || string.IsNullOrWhiteSpace(uri.AbsolutePath))
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }

                if((uri.Scheme == "http" && uri.Port == 443)
                    || (uri.Scheme == "https" && uri.Port == 80))
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }

                Console.WriteLine($"Protocol: {uri.Scheme}");
                Console.WriteLine($"Host: {uri.Host}");
                Console.WriteLine($"Port: {uri.Port}");
                Console.WriteLine($"Path: {uri.AbsolutePath}");
                Console.WriteLine($"Query: {uri.Query}");
                Console.WriteLine($"Fragment: {uri.Fragment}");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
