namespace ByTheCake.Server.HTTP.Response
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = Enums.HttpStatusCode.NotFound;
        }
    }
}
