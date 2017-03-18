namespace _3.SalesDatabase
{
    using System;
    using System.Data.Entity;
    using Models;

    public class CreateDatabaseAndSeed : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            this.SeedCustomers(context);
            this.SeedProducts(context);
            this.SeedStoreLocations(context);
            this.SeedSales(context);

            base.Seed(context);
        }

        private void SeedSales(SalesContext context)
        {
            var sale1 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = context.StoreLocations.Find(1),
                Customer = context.Customers.Find(1),
                Product = context.Products.Find(1)
            };

            var sale2 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = context.StoreLocations.Find(1),
                Customer = context.Customers.Find(1),
                Product = context.Products.Find(1)
            };

            var sale3 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = context.StoreLocations.Find(1),
                Customer = context.Customers.Find(1),
                Product = context.Products.Find(1)
            };


            var sale4 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = context.StoreLocations.Find(1),
                Customer = context.Customers.Find(1),
                Product = context.Products.Find(1)
            };

            var sale5 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = context.StoreLocations.Find(1),
                Customer = context.Customers.Find(1),
                Product = context.Products.Find(1)
            };

            context.Sales.Add(sale1);
            context.Sales.Add(sale2);
            context.Sales.Add(sale3);
            context.Sales.Add(sale4);
            context.Sales.Add(sale5);
            context.SaveChanges();
        }

        private void SeedStoreLocations(SalesContext context)
        {
            var location1 = new StoreLocation()
            {
                LocationName = "HighGarden"
            };

            var location2 = new StoreLocation()
            {
                LocationName = "Pyke"
            };

            var location3 = new StoreLocation()
            {
                LocationName = "Winterfell"
            };

            var location4 = new StoreLocation()
            {
                LocationName = "White Harbor"
            };

            var location5 = new StoreLocation()
            {
                LocationName = "Sunspear"
            };

            context.StoreLocations.Add(location1);
            context.StoreLocations.Add(location2);
            context.StoreLocations.Add(location3);
            context.StoreLocations.Add(location4);
            context.StoreLocations.Add(location5);
            context.SaveChanges();
        }

        private void SeedProducts(SalesContext context)
        {
            var product1 = new Product()
            {
                Name = "Arrow",
                Price = 1m,
                Quantity = 2111
            };

            var product2 = new Product()
            {
                Name = "Schield",
                Price = 12.5m,
                Quantity = 69
            };

            var product3 = new Product()
            {
                Name = "Sword",
                Price = 220m,
                Quantity = 13
            };

            var product4 = new Product()
            {
                Name = "BreastPlate",
                Price = 570.78m,
                Quantity = 1
            };

            var product5 = new Product()
            {
                Name = "Helm",
                Price = 78.99m,
                Quantity = 21
            };

            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            context.Products.Add(product5);
            context.SaveChanges();
        }

        private void SeedCustomers(SalesContext context)
        {
            var customer1 = new Customer()
            {
                Name = "John",
                Email = "john@snow.westeros",
                CreditCardNumber = "456-5841-4741"
            };

            var customer2 = new Customer()
            {
                Name = "Aria",
                Email = "aria@stark.westeros",
                CreditCardNumber = "4326-5841-4741"
            };

            var customer3 = new Customer()
            {
                Name = "Kevan",
                Email = "kevan@lanister.westeros",
                CreditCardNumber = "976-5841-4741"
            };

            var customer4 = new Customer()
            {
                Name = "Nimeria",
                Email = "nimeria@sand.westeros",
                CreditCardNumber = "126-5841-4721"
            };

            var customer5 = new Customer()
            {
                Name = "Melissandra",
                Email = "melissandra@witch.westeros",
                CreditCardNumber = "4236-4567-3241"
            };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.Customers.Add(customer4);
            context.Customers.Add(customer5);
            context.SaveChanges();
        }
    }
}
