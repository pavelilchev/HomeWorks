namespace ByTheCake.Server.HTTP.Contracts
{
    using ByTheCake.Server.Enums;

    public interface IHttpResponse
    {
        string Response { get; }

        HttpStatusCode StatusCode { get; }

        HttpHeaderCollection HeaderCollection { get; }

        byte[] Data { get; }

        void AddHeader(string key, string value);
    }
}
