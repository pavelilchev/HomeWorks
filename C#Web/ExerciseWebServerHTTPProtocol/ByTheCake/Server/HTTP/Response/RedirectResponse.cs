namespace ByTheCake.Server.HTTP.Response
{
    using global::ByTheCake.Server.Common;
    using global::ByTheCake.Server.Enums;

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
