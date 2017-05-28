namespace CarDealer.Client
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var ctx = new CarDealerContext();

            //1. Car Dealer Import Data
            //ImportData(ctx, rnd);

            //Query 1 – Cars
            //Cars(ctx);

            //Query 2 – Cars from make Ferrari
            //FerrariCars(ctx);

            //Query 3 – Local Suppliers
            //LocalSuppliers(ctx);

            //Query 4 – Cars with Their List of Parts
            //CarsAndParts(ctx);

            //Query 5 – Total Sales by Customer
            //TotalSales(ctx);

            //Query 6 – Sales with Applied Discount
            var sales = ctx.Sales.Include(s => s.Customer).Include(s => s.Car).ToList();

            var xml = new XDocument(
                new XElement("sales",
                sales.Select(s=>
                new XElement("sale",
                new XElement("car",
                new XAttribute("make",s.Car.Make),
                new XAttribute("model",s.Car.Model),
                new XAttribute("travelled-distance", s.Car.TravelledDistance),
                new XElement("customer-name", s.Customer.Name),
                new XElement("discount",s.Discount),
                new XElement("price",s.Car.Parts.Sum(p=>p.Price)),
                new XElement("price-with-discount", s.Car.Parts.Sum(p => p.Price) - s.Car.Parts.Sum(p => p.Price) * s.Discount / 100))))));

            Console.WriteLine(xml);
        }

        private static void TotalSales(CarDealerContext ctx)
        {
            var customers = ctx.Customers
                .Where(c => c.Sales.Count > 1)
                .Select(c => new
                {
                    c.Name,
                    carsCount = c.Sales.Count,
                    totalSum = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                })
                .OrderByDescending(c => c.totalSum)
                .ThenByDescending(c => c.carsCount)
                .ToList();

            var xml = new XDocument(
                new XElement("customers",
                    customers.Select(c =>
                        new XElement("customer",
                            new XAttribute("full-name", c.Name),
                            new XAttribute("bought-cars", c.carsCount),
                            new XAttribute("spent-money", c.totalSum)))));

            xml.Save("customers-total-sales");
            Console.WriteLine(xml);
        }

        private static void CarsAndParts(CarDealerContext ctx)
        {
            var cars = ctx.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    Parts = c.Parts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                }).ToList();

            var xml = new XDocument(
                new XElement("cars",
                    cars.Select(c =>
                        new XElement("car",
                            new XAttribute("make", c.Make),
                            new XAttribute("model", c.Model),
                            new XAttribute("travelled-distance", c.TravelledDistance),
                            new XElement("parts",
                                c.Parts.Select(p =>
                                    new XElement("part",
                                        new XAttribute("name", p.Name),
                                        new XAttribute("price", p.Price))))))));

            xml.Save("cars-and-parts.xml");
            Console.WriteLine(xml);
        }

        private static void LocalSuppliers(CarDealerContext ctx)
        {
            var suppliers = ctx.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Parts.Count
                }).ToList();

            var xml = new XDocument(
                new XElement("suppliers",
                    suppliers.Select(s =>
                        new XElement("supplier",
                            new XAttribute("id", s.Id),
                            new XAttribute("name", s.Name),
                            new XAttribute("parts-count", s.Count)))));

            xml.Save("local-suppliers");
            Console.WriteLine(xml);
        }

        private static void FerrariCars(CarDealerContext ctx)
        {
            var cars = ctx.Cars
                .Where(c => c.Make == "Ferrari")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var xml = new XDocument(
                new XElement("cars",
                    cars.Select(c =>
                        new XElement("car",
                            new XAttribute("id", c.Id),
                            new XAttribute("model", c.Model),
                            new XAttribute("travelled-distance", c.TravelledDistance)))));

            xml.Save("ferrari-cars.xml");
            Console.WriteLine(xml);
        }

        private static void Cars(CarDealerContext ctx)
        {
            var cars = ctx.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToList();

            var xml = new XDocument(
                new XElement("cars",
                    cars.Select(c =>
                        new XElement("car",
                            new XElement("make", c.Make),
                            new XElement("model", c.Model),
                            new XElement("travelled-distance", c.TravelledDistance)))));

            xml.Save("cars.xml");
            Console.WriteLine(xml);
        }

        private static void ImportData(CarDealerContext ctx)
        {
            var rnd = new Random();
            ImportSuppliers(ctx);
            ImportParts(ctx, rnd);
            ImportCars(ctx, rnd);
            ImportCustomers(ctx);
            ImportSales(ctx, rnd);
        }

        private static void ImportSales(CarDealerContext ctx, Random rnd)
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

        private static void ImportCustomers(CarDealerContext ctx)
        {
            var customers = XDocument.Load("../../DataImports/customers.xml")
                .Root
                .Elements()
                .Select(c => new Customer()
                {
                    Name = c.Attribute("name").Value,
                    BirthDate = DateTime.Parse(c.Element("birth-date").Value),
                    IsYoungDriver = bool.Parse(c.Element("is-young-driver").Value)
                }).ToList();

            ctx.Customers.AddRange(customers);
            ctx.SaveChanges();
        }

        private static void ImportCars(CarDealerContext ctx, Random rnd)
        {
            var cars = XDocument.Load("../../DataImports/cars.xml")
                .Root
                .Elements()
                .Select(c => new Car()
                {
                    Make = c.Element("make").Value,
                    Model = c.Element("model").Value,
                    TravelledDistance = long.Parse(c.Element("travelled-distance").Value)
                }).ToList();
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

        private static void ImportParts(CarDealerContext ctx, Random rnd)
        {
            var parts = XDocument.Load("../../DataImports/parts.xml")
                .Root
                .Elements()
                .Select(p => new Part()
                {
                    Name = p.Attribute("name").Value,
                    Price = decimal.Parse(p.Attribute("price").Value),
                    Quantity = int.Parse(p.Attribute("quantity").Value)
                }).ToList();

            var supliers = ctx.Suppliers.ToList();

            foreach (Part t in parts)
            {
                t.Supplier = supliers[rnd.Next(supliers.Count)];
            }

            ctx.Parts.AddRange(parts);
            ctx.SaveChanges();
        }

        private static void ImportSuppliers(CarDealerContext ctx)
        {
            var supliers = XDocument.Load("../../DataImports/suppliers.xml")
                .Root
                .Elements()
                .Select(s => new Supplier()
                {
                    Name = s.Attribute("name").Value,
                    IsImporter = bool.Parse(s.Attribute("is-importer").Value)
                })
                .ToList();

            ctx.Suppliers.AddRange(supliers);
            ctx.SaveChanges();
        }
    }
}
