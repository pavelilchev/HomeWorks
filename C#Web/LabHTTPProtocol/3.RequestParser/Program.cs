using System;
using System.Collections.Generic;

namespace _3.RequestParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                var line = Console.ReadLine();
                if(line == "END")
                {
                    break;
                }

                var parts = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                var path = parts[0];
                var method = parts[1];
                if(!data.ContainsKey(path))
                {
                    data[path] = new HashSet<string>();
                }

                data[path].Add(method);
            }

            var requestLine = Console.ReadLine();
            var reqParts = requestLine.Split(new char[] { '/', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var reqMethod = reqParts[0].ToLower();
            var reqPath = reqParts[1];

            var response = @"HTTP/1.1 {0}
Content-Length: {1}
Content-Type: text/plain
                            
{2}";

            if (data.ContainsKey(reqPath) && data[reqPath].Contains(reqMethod))
            {
                response = string.Format(response, "200 OK", 2, "OK");
            }
            else
            {
                response = string.Format(response, "404 NotFound", 9, "NotFound");
            }

            Console.WriteLine(new string('-', 20));
            Console.WriteLine(response);
        }
    }
}
