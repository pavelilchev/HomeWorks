namespace Shop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using Models;
    using Newtonsoft.Json;

    public class DropCreateSeed : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext ctx)
        {
            this.SeedUsers(ctx);
            this.SeedCategories(ctx);
            this.SeedProducts(ctx);
        }

        private void SeedProducts(ShopContext ctx)
        {
            List<Product> products;
            using (var r = new StreamReader(@"../../../Shop.Data/DataFiles/products.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }

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


        private void SeedCategories(ShopContext ctx)
        {
            using (var r = new StreamReader(@"../../../Shop.Data/DataFiles/categories.json"))
            {
                string json = r.ReadToEnd();
                List<Categorie> categories = JsonConvert.DeserializeObject<List<Categorie>>(json);

                ctx.Categories.AddRange(categories);
                ctx.SaveChanges();
            }
        }

        private void SeedUsers(ShopContext ctx)
        {
            using (StreamReader r = new StreamReader(@"../../../Shop.Data/DataFiles/users.json"))
            {
                string json = r.ReadToEnd();
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                ctx.Users.AddRange(users);
                ctx.SaveChanges();

                Random rnd = new Random();
                var newUsers = ctx.Users.ToList();
                for (int i = 0; i < newUsers.Count; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        newUsers[i].Friends.Add(newUsers[rnd.Next(newUsers.Count)]);
                    }
                }

                ctx.SaveChanges();
            }
        }
    }
}
