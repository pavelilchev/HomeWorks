namespace Shop.App
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public static class Startup
    {
        public static void Main()
        {
            var ctx = new ShopContext();
            // Query 1 - Products In Range
            ListProductsInRange(ctx);

            // Query 2 - Successfully Sold Products
            // ListSoldProducts(ctx);

            // Query 3 - Categories By Products Count
            // ListCategories(ctx);

            // Query 4 - Users and Products
            // ListUsersAndProducts(ctx);
        }

        private static void ListUsersAndProducts(ShopContext ctx)
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
                    soldProducts = new
                    {
                        count = u.SoldProducts.Count,
                        products = u.SoldProducts.Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                    }
                })
                .ToList();

            var usersObj = new
            {
                usersCount = users.Count,
                users
            };

            var json = JsonConvert.SerializeObject(usersObj, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ListCategories(ShopContext ctx)
        {
            var categories = ctx.Categories.Select(c => new
            {
                c.Name,
                ProductsCount = c.Products.Count,
                AveragePrice = c.Products.Average(p => p.Price),
                TotalSum = c.Products.Sum(p => p.Price)
            });

            var jsoncategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
            Console.WriteLine(jsoncategories);
        }

        private static void ListSoldProducts(ShopContext ctx)
        {
            var usersSold = ctx.Users
                .Where(u => u.SoldProducts.Any(sp => sp.BuyerId != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.SoldProducts.Where(p => p.BuyerId != null).Select(p => new
                    {
                        p.Name,
                        p.Price,
                        p.Buyer.FirstName,
                        p.Buyer.LastName
                    })
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            var jsonUsersSold = JsonConvert.SerializeObject(usersSold, Formatting.Indented);
            Console.WriteLine(jsonUsersSold);
        }

        private static void ListProductsInRange(ShopContext ctx)
        {
            var productsInRange = ctx.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    FullName = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.Price)
                .ToList();

            var jsonproductsInRange = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            Console.WriteLine(jsonproductsInRange);
        }
    }
}
