namespace CarDealer.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using Models;
    using Newtonsoft.Json;

    public class CreateIfNotExistSeed : CreateDatabaseIfNotExists<CarDealerContext>
    {
        protected override void Seed(CarDealerContext ctx)
        {
            var rnd = new Random();
            this.SeedSuppliers(ctx);
            this.SeedParts(ctx, rnd);
            this.SeedCars(ctx, rnd);
            this.SeedCustomers(ctx);
            this.SeedSales(ctx, rnd);
        }

        private void SeedSales(CarDealerContext ctx, Random rnd)
        {
            var cars = ctx.Cars.ToList();
            var customers = ctx.Customers.ToList();
            var discounts = new[] {0, 5, 10, 15, 20, 30, 40, 50};

            var sales = new List<Sale>();
            for (int i = 0; i < 300; i++)
            {
                var car = cars[rnd.Next(cars.Count)];
                var customer = customers[rnd.Next(customers.Count)];
                var discount = discounts[rnd.Next(discounts.Length)];
                if (customer.IsYoungDriver)
                {
                    discount += 5;
                }

                sales.Add(new Sale()
                {
                    Car = car,
                    Customer = customer,
                    Discount = discount 
                });
            }

            ctx.Sales.AddRange(sales);
            ctx.SaveChanges();
        }

        private void SeedCustomers(CarDealerContext ctx)
        {
            using (var r = new StreamReader(@"../../../CarDealer.Data/DataImport/customers.json"))
            {
                string json = r.ReadToEnd();

                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);

                ctx.Customers.AddRange(customers);
                ctx.SaveChanges();
            }
        }

        private void SeedCars(CarDealerContext ctx, Random rnd)
        {
            using (StreamReader r = new StreamReader("../../../CarDealer.Data/DataImport/cars.json"))
            {
                string json = r.ReadToEnd();
                var cars = JsonConvert.DeserializeObject<List<Car>>(json);
                var parts = ctx.Parts.ToList();

                foreach (var car in cars)
                {
                    int partsToAddCount = rnd.Next(10, 21);
                    var partsToAdd = new HashSet<int>();
                    while (partsToAdd.Count < partsToAddCount)
                    {
                        partsToAdd.Add(rnd.Next(parts.Count));
                    }
                    foreach (var p in partsToAdd)
                    {
                        car.Parts.Add(parts[p]);
                    }
                }

                ctx.Cars.AddRange(cars);
                ctx.SaveChanges();
            }
        }

        private void SeedParts(CarDealerContext ctx, Random rnd)
        {
            using (StreamReader r = new StreamReader("../../../CarDealer.Data/DataImport/parts.json"))
            {
                string json = r.ReadToEnd();
                var parts = JsonConvert.DeserializeObject<List<Part>>(json);
                var supliers = ctx.Suppliers.ToList();
                
                foreach (Part t in parts)
                {
                    t.Supplier = supliers[rnd.Next(supliers.Count)];
                }

                ctx.Parts.AddRange(parts);
                ctx.SaveChanges();
            }
        }

        private void SeedSuppliers(CarDealerContext ctx)
        {

            using (var r = new StreamReader(@"../../../CarDealer.Data/DataImport/suppliers.json"))
            {
                string json = r.ReadToEnd();
                List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(json);

                ctx.Suppliers.AddRange(suppliers);
                ctx.SaveChanges();
            }
        }
    }
}
