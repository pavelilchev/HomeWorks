﻿namespace ByTheCake.Server.Handlers.Contracts
{
    using HTTP.Contracts;

    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext httpContext);
    }
}
