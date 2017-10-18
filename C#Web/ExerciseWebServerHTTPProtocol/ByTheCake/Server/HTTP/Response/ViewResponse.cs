namespace ByTheCake.Server.HTTP.Response
{
    using System;
    using Enums;
    using global::ByTheCake.Server.Contracts;

    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode responseStatusCode, IView view) 
        {
            this.ValidateStatusCode(StatusCode);

            this.view = view;
            this.StatusCode = responseStatusCode;
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var status = (int)statusCode;
            if(299 < status && status < 400)
            {
                throw new InvalidOperationException("View response status code is invalid");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }
    }
}
