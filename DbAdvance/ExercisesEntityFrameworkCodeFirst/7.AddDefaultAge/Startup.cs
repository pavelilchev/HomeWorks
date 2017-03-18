namespace _7.AddDefaultAge
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var ctx = new SalesContext();
            ctx.Database.Initialize(true);

            foreach (var c in ctx.Customers)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName} {c.Age}");
            }
        }
    }
}
