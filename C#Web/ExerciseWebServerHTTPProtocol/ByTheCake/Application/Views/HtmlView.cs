namespace ByTheCake.Application.Views
{
    using System.IO;

    public static class HtmlView
    {
        private const string ResourcesFolderPath = "/Application/Resources/";

        public static string GetHtml(string fileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var filePath = $"{currentDirectory}{ResourcesFolderPath}{fileName}";
            var result = string.Empty;
            if (File.Exists(filePath))
            {
                result = File.ReadAllText(filePath);
            }

            return result;
        }
    }
}
