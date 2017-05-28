namespace CarDealer.App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;
    using Models;
    using Newtonsoft.Json;
    using Store.Models;

    public class Startup
    {
        public static void Main()
        {
            var ctx = new CarDealerContext();
            //Query 1 – Ordered Customers
            //ListCustomers(ctx);

            //Query 2 – Cars from make Toyota
            //ListCarsByMake(ctx);

            //Query 3 – Local Suppliers
            //ListSuppliers(ctx);

            //Query 4 – Cars with Their List of Parts
            //ListCarsAndParts(ctx);

            //Query 5 – Total Sales by Customer
            //ListCustomersSales(ctx);

            //Query 6 – Sales with Applied Discount
            //var sales = ctx.Sales
            //    .Select(s => new
            //    {
            //        car = new
            //        {
            //            s.Car.Make,
            //            s.Car.Model,
            //            s.Car.TravelledDistance
            //        },
            //        customerName = s.Customer.Name,
            //        s.Discount,
            //        price = s.Car.Parts.Sum(p => p.Price),
            //        priceWithDiscount = s.Car.Parts.Sum(p => p.Price)- s.Car.Parts.Sum(p => p.Price) * s.Discount/100
            //    })
            //    .ToList();
            //var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            using (var r = new StreamReader(@"../../../CarDealer.Data/DataImport/products.json"))
            {
                string json = r.ReadToEnd();

                var product = JsonConvert.DeserializeObject<List<Product>>(json);

            }
           
        }

        private static void ListCustomersSales(CarDealerContext ctx)
        {
            var customers = ctx.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();
            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ListCarsAndParts(CarDealerContext ctx)
        {
            var list = new List<Dictionary<string, object>>();
            var cars = ctx.Cars.Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                },
                parts = c.Parts.Select(p => new
                {
                    p.Name,
                    p.Price
                })
            }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ListSuppliers(CarDealerContext ctx)
        {
            var suppliers = ctx.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Parts.Count
                })
                .ToList();
            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ListCarsByMake(CarDealerContext ctx)
        {
            var cars = ctx.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();
            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ListCustomers(CarDealerContext ctx)
        {
            var sales = new List<Sale>();
            var customers = ctx.Customers
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.BirthDate,
                    c.IsYoungDriver,
                    Sales = sales
                })
                .OrderBy(u => u.BirthDate)
                .ThenBy(c => c.IsYoungDriver);
            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
