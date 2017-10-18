namespace WebServer.Server.HTTP.Contracts
{
    public interface IHttpResponse
    {
		string Response { get; }

        HttpHeaderCollection HeaderCollection { get;  }
        
        void AddHeader(string key, string value);
    }
}
