namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Application.Views;
    using ByTheCake.Models;
    using ByTheCake.Server.Enums;
    using ByTheCake.Server.HTTP.Contracts;
    using ByTheCake.Server.HTTP.Response;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class CakeController
    {
        private const string FilePath = "/Application/Resources/database.csv";

        public string DbPath => Directory.GetCurrentDirectory() + FilePath;

        private static List<Cake> cakes = new List<Cake>();

        public IHttpResponse Add()
        {
            return new ViewResponse(HttpStatusCode.OK, new CakeAddView(cakes));
        }

        public IHttpResponse AddPost(string name, string price)
        {
            decimal parsedPrice;
            Cake cake = null;
            if (decimal.TryParse(price, out parsedPrice) && !string.IsNullOrWhiteSpace(name))
            {
                cake = new Cake(name, parsedPrice);
            }

            File.AppendAllText(DbPath, $"{Environment.NewLine}{cake.ToString()},");

            cakes.Add(cake);
            return new ViewResponse(HttpStatusCode.OK, new CakeAddView(cakes));
        }

        public IHttpResponse Search(IDictionary<string, string> query)
        {
            var result = new List<string>();
            string search = string.Empty;
            if (query.ContainsKey("search"))
            {
                search = query["search"];

                if (File.Exists(DbPath))
                {
                    var tetx = File.ReadAllText(DbPath).ToLower();
                    var lines = tetx.Split(',');
                    foreach (var line in lines)
                    {
                        if (line.IndexOf(search.ToLower()) >= 0)
                        {
                            result.Add(line);
                        }
                    }
                }
            }

            return new ViewResponse(HttpStatusCode.OK, new CakeSearchView(result));
        }        
    }
}
