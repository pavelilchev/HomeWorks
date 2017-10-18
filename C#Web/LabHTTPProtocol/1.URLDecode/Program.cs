using System;
using System.Net;

namespace _1.URLDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(url);

            Console.WriteLine(decodedUrl);
        }
    }
}
