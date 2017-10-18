namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Enums;
    using Exceptions;
    using HTTP.Contracts;
    using Common;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; } 

        public IDictionary<string, string> FormData { get; private set; }

        public IDictionary<string, string> QueryParameters { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }
       
        public void AddUrlParameters(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            var requestLines = requestString.Split(new [] { Environment.NewLine }, StringSplitOptions.None);

            if (!requestLines.Any())
            {
                throw new BadRequestException("Request is not valid");
            }

            var requestLine = requestLines[0].Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if(requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);
            this.ParseParameters();

            if(this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length -1], this.FormData);
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split("?")[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split("&");
            foreach (var pair in queryPairs)
            {
                string[] queryArgs = pair.Split("=");
                if(queryArgs.Length != 2)
                {
                    continue;
                }

                dict.Add(WebUtility.UrlDecode(queryArgs[0]), WebUtility.UrlDecode(queryArgs[1]));
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, string.Empty);
            for (int i = 1; i < endIndex; i++)
            {
                var headerArgs = requestLines[i].Split(new[] { ": " }, StringSplitOptions.None);

                if(headerArgs.Length != 2)
                {
                    continue;
                }

                var httpHeader = new HttpHeader(headerArgs[0], headerArgs[1]);

                this.HeaderCollection.Add(httpHeader);
            }

            if(!this.HeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Invalid headers");
            }
        }

        private HttpRequestMethod ParseRequestMethod(string method)
        {
            try
            {
                return Enum.Parse<HttpRequestMethod>(method, true);
            }
            catch (Exception)
            {

                throw new BadRequestException("Invalid request method");
            }
        }
    }
}
