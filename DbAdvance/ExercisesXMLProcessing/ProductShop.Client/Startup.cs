namespace ProductShop.Client
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var ctx = new ShopContext();
            //3. Import Data
            //ImportData(ctx);

            //Query 1 - Products In Range
            //ProductsInRangeToXml(ctx);

            //Query 2 - Sold Products
            //SoldProducts(ctx);

            //Query 3 - Categories By Products Count
            //CategoriesByProducts(ctx);

            //Query 4 - Users and Products
            //UsersProducts(ctx);
        }

        private static void UsersProducts(ShopContext ctx)
        {
            var users = ctx.Users
                .Where(u => u.SoldProducts.Count > 0)
                .OrderByDescending(u => u.SoldProducts.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = u.SoldProducts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                }).ToList();

            var xml = new XDocument(
                new XElement("users", new XAttribute("count", users.Count),
                    users.Select(u => new XElement("user",
                        u.FirstName == null ? null : new XAttribute("first-name", u.FirstName),
                        new XAttribute("last-name", u.LastName), u.Age == null ? null : new XAttribute("age", u.Age),
                        new XElement("sold-products", new XAttribute("count", u.soldProducts.Count()),
                            u.soldProducts.Select(
                                p =>
                                    new XElement("product", new XAttribute("name", p.Name),
                                        new XAttribute("price", p.Price))))))));
            xml.Save("../../users-and-products.xml");
            Console.WriteLine(xml);
        }

        private static void CategoriesByProducts(ShopContext ctx)
        {
            var categories = ctx.Categories
                .Select(c => new
                {
                    c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenu = c.Products.Sum(p => p.Price)
                })
                .OrderByDescending(c => c.productsCount)
                .ToList();

            var xml = new XDocument(
                new XElement("categories",
                    categories.Select(c => new XElement("category", new XAttribute("name", c.Name),
                        new XElement("products-count", c.productsCount),
                        new XElement("average-price", c.averagePrice),
                        new XElement("total-revenu", c.totalRevenu)))));
            xml.Save("../../categories-by-products.xml");
            Console.WriteLine(xml);
        }

        private static void SoldProducts(ShopContext ctx)
        {
            var users = ctx.Users
                .Where(u => u.SoldProducts.Count > 0)
                .Select(u => new
                {
                    FirstName = u.FirstName ?? string.Empty,
                    u.LastName,
                    soldProducts = u.SoldProducts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            var xml =
                new XDocument(
                    new XElement("users",
                        users.Select(u => new XElement("user",
                            new XAttribute("first-name", u.FirstName), new XAttribute("last-name", u.LastName),
                            new XElement("sold-products",
                                u.soldProducts.Select(p => new XElement("product",
                                    new XElement("name", p.Name),
                                    new XElement("price", p.Price))))))));
            xml.Save("../../users-sold-products.xml");

            Console.WriteLine(xml);
        }

        private static void ProductsInRangeToXml(ShopContext ctx)
        {
            var products = ctx.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .ToList();

            var productsXml =
                new XDocument(
                    new XElement("products",
                        products.Select(p => new XElement("product",
                            new XAttribute("name", p.Name), new XAttribute("price", p.Price), new XAttribute("buyer", p.buyer)))
                    ));

            productsXml.Save("../../products-in-range.xml");
            Console.WriteLine(productsXml);
        }

        private static void ImportData(ShopContext ctx)
        {
            ImportUsers(ctx);
            ImportCategories(ctx);
            ImportProducts(ctx);
        }

        private static void ImportCategories(ShopContext ctx)
        {
            var catDoc = XDocument.Load("../../DataImports/categories.xml");
            var categories = catDoc.Root.Elements().Select(c => new Categorie()
            {
                Name = c.Element("name").Value
            }).ToList();
            ctx.Categories.AddRange(categories);
            ctx.SaveChanges();
        }

        private static void ImportProducts(ShopContext ctx)
        {
            var prodDoc = XDocument.Load("../../DataImports/products.xml");
            var products = prodDoc.Root.Elements().Select(p => new Product()
            {
                Name = p.Element("name").Value,
                Price = decimal.Parse(p.Element("price").Value)
            }).ToList();

            var categories = ctx.Categories.ToList();
            int catCount = categories.Count;
            var users = ctx.Users.ToList();
            int userCount = users.Count;
            Random rnd = new Random();
            for (int i = 0; i < products.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    products[i].Categories.Add(categories[rnd.Next(catCount)]);
                }

                products[i].Seller = users[rnd.Next(userCount)];
                if (i % 2 == 0)
                {
                    products[i].Buyer = users[rnd.Next(userCount)];
                }
            }

            ctx.Products.AddRange(products);
            ctx.SaveChanges();
        }

        private static void ImportUsers(ShopContext ctx)
        {
            var userDoc = XDocument.Load("../../DataImports/users.xml");
            var users = userDoc.Root.Elements();

            foreach (var u in users)
            {
                string firstName = u.Attribute("first-name") != null ? u.Attribute("first-name").Value : null;
                string lastName = u.Attribute("last-name").Value;
                int? age = null;
                if (u.Attribute("age") != null)
                {
                    age = int.Parse(u.Attribute("age").Value);
                }

                var user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                ctx.Users.Add(user);
            }

            ctx.SaveChanges();
        }
    }
}
