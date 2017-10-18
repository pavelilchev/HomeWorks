namespace WebServer.Server.HTTP.Response
{
    using global::WebServer.Server.Common;
    using global::WebServer.Server.Enums;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.AddHeader("Location", redirectUrl);
            this.StatusCode = HttpStatusCode.Found;
        }
    }
}
