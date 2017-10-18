namespace WebServer.Server.Routing
{
    using System.Collections.Generic;
    using Handlers;
    using Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler handler, IEnumerable<string> parameters)
        {
            this.Parameters = parameters;
            this.RequestHandler = handler;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler RequestHandler { get; private set; }
    }
}
