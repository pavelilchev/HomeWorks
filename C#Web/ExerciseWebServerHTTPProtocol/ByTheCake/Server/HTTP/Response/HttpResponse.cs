namespace ByTheCake.Server.HTTP.Response
{
    using System.Text;
    using Contracts;
    using Enums;

    public abstract class HttpResponse : IHttpResponse
    {
        protected string StausCodeMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        public virtual string Response
        {
            get
            {
                return this.ToString();
            }
        }

        public HttpStatusCode StatusCode { get; set; }

        public HttpHeaderCollection HeaderCollection { get; set; }

        public byte[] Data { get; set; }

        public void AddHeader(string key, string value)
        {
            this.HeaderCollection.Add(new HttpHeader(key, value));
        }

        public override string ToString()
        {
            var response = new StringBuilder();
            var statusCode = (int)this.StatusCode;
            response.AppendLine($"HTTP/1.1 {statusCode} {this.StausCodeMessage}");

            response.AppendLine(this.HeaderCollection.ToString());
            response.AppendLine();

            return response.ToString();
        }
    }
}
