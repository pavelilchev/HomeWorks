namespace ShopHierarchy
{
    using ShopHierarchy.Data;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using (var ctx = new ShopContext())
            {
                ResetDb(ctx);
                FillSalesmen(ctx);
                FillItems(ctx);
                ProcesComands(ctx);
                //PrintSalesmenWithCustomersCount(ctx);
                //PrintCustomersOrdersAndReviews(ctx);
                //PrintCustomerOrderItems(ctx);
                //PrintCustomerOrdersReviewsSalesman(ctx);
                PrintCustomerOrdersWhitMoreThanOneItems(ctx);
            }
        }

        private static void PrintCustomerOrdersWhitMoreThanOneItems(ShopContext ctx)
        {

            var customerId = int.Parse(Console.ReadLine());
            var customer = ctx.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c.Orders.Where(o => o.Items.Count > 1).Count()
                })
                .FirstOrDefault();

            Console.WriteLine($"Orders: {customer.Orders}");
        }

        private static void PrintCustomerOrdersReviewsSalesman(ShopContext ctx)
        {
            var customerId = int.Parse(Console.ReadLine());
            var customer = ctx.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count,
                    Salesman = c.Salesman.Name
                })
                .FirstOrDefault();

            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine($"Orders Count: {customer.Orders}");
            Console.WriteLine($"Reviews Count: {customer.Reviews}");
            Console.WriteLine($"Selsman: {customer.Salesman}");
        }

        private static void PrintCustomerOrderItems(ShopContext ctx)
        {
            var customerId = int.Parse(Console.ReadLine());
            var customer = ctx.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c.Orders.Select(o => new
                    {
                        o.Id,
                        Items = o.Items.Count
                    }),
                    Reviews = c.Reviews.Count
                })
                .FirstOrDefault();

            foreach (var o in customer.Orders)
            {
                Console.WriteLine($"oder {o.Id}: {o.Items} items");
            }

            Console.WriteLine($"reviews: {customer.Reviews}");
        }

        private static void FillItems(ShopContext ctx)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if(line == "END")
                {
                    break;
                }

                var args = line.Split(';');
                var name = args[0];
                var price = decimal.Parse(args[1]);

                ctx.Items.Add(new Item()
                {
                    Name = name,
                    Price = price
                });
            }

            ctx.SaveChanges();
        }

        private static void PrintCustomersOrdersAndReviews(ShopContext ctx)
        {
            var result = ctx.Customers
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(c => c.Orders)
                .ThenBy(c => c.Reviews);

            foreach (var c in result)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine($"Orders: {c.Orders}");
                Console.WriteLine($"Reviews: {c.Reviews}");
            }
        }

        private static void PrintSalesmenWithCustomersCount(ShopContext ctx)
        {
            var result = ctx.Salesmans
                .Select(s => new
                {
                    s.Name,
                    CustomersCount = s.Customers.Count
                })
                .OrderByDescending(c => c.CustomersCount)
                .ThenBy(c => c.Name);

            foreach (var c in result)
            {
                Console.WriteLine($"{c.Name} - {c.CustomersCount} customers");
            }
        }

        private static void ProcesComands(ShopContext ctx)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var parts = line.Split('-');
                var command = parts[0];

                switch (command)
                {
                    case "register":
                        RegisterCustomers(ctx, parts[1]);
                        break;
                    case "order":
                        SaveOrders(ctx, parts[1]);
                        break;
                    case "review":
                        SaveReviews(ctx, parts[1]);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SaveReviews(ShopContext ctx, string argsLine)
        {
            var args = argsLine.Split(';');
            var customerId = int.Parse(args[0]);
            var itemId = int.Parse(args[1]);

            ctx.Reviews.Add(new Review()
            {
                CustomerId = customerId,
                ItemId = itemId
            });

            ctx.SaveChanges();
        }

        private static void SaveOrders(ShopContext ctx, string argsLine)
        {
            var args = argsLine.Split(';');
            var customerId = int.Parse(args[0]);
            var order = new Order()
            {
                CustomerId = customerId
            };

            for (int i = 1; i < args.Length; i++)
            {
                var itemId = int.Parse(args[i]);
                order.Items.Add(new OrderItem()
                {
                    ItemId = itemId
                });
            }

            ctx.Orders.Add(order);

            ctx.SaveChanges();
        }

        private static void RegisterCustomers(ShopContext ctx, string info)
        {
            var args = info.Split(';');
            var name = args[0];
            var salesmanId = int.Parse(args[1]);

            ctx.Customers.Add(new Customer()
            {
                Name = name,
                SalesmanId = salesmanId
            });

            ctx.SaveChanges();
        }

        private static void FillSalesmen(ShopContext ctx)
        {
            var line = Console.ReadLine();
            var salesmen = line.Split(';');
            foreach (var s in salesmen)
            {
                ctx.Salesmans.Add(new Salesman()
                {
                    Name = s
                });
            }

            ctx.SaveChanges();
        }

        private static void ResetDb(ShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            Console.WriteLine("Enter data:");
        }
    }
}
