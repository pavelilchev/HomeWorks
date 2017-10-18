namespace ByTheCake.Server.HTTP.Response
{
    using ByTheCake.Server.Enums;
    using Contracts;
    using System.IO;
    using System.Text;

    public class ImageResponse : HttpResponse
    {
        private string imagePath;

        public ImageResponse(string imagePath)
        {
            this.imagePath = imagePath;
        }

        public override string Response
        {
            get
            {
                var response = new StringBuilder();
                var currentDir = Directory.GetCurrentDirectory();
                var fullPath = $"{currentDir}{this.imagePath}";
                if (File.Exists(fullPath))
                {
                    this.StatusCode = HttpStatusCode.OK;

                    response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StausCodeMessage}");

                    byte[] imgData = File.ReadAllBytes(fullPath);
                    this.Data = imgData;

                    this.AddHeader("Content-Type", "image/png,image/jpg,image");
                    this.AddHeader("Content-Length", $"{imgData.Length}");

                    response.AppendLine(this.HeaderCollection.ToString());
                    response.AppendLine();
                }
                else
                {
                    this.StatusCode = HttpStatusCode.NotFound;

                    return base.ToString();
                }

                return response.ToString();
            }
        }
    }
}
