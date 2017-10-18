namespace WebServer.Server.HTTP.Response
{
    using System.Text;
    using Contracts;
    using Enums;
    using global::WebServer.Server.Contracts;

    public abstract class HttpResponse : IHttpResponse
    {
        private readonly IView view;
        private string StausCodeMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }        

        public string Response
        {
            get
            {
                return this.ToString();
            }
        }

        public IView View { get { return this.view; } }

        public HttpStatusCode StatusCode { get; set; }      

        public HttpHeaderCollection HeaderCollection { get; set; }

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
