namespace WebServer.Server.Handlers
{
    using System;
    using Handlers.Contracts;
    using Server.HTTP.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> func;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse response = this.func(httpContext.Request);
            response.AddHeader("Content-Type", "text/html");

            return response;
        }
    }
}
