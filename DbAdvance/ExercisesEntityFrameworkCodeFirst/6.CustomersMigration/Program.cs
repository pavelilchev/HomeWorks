namespace _6.CustomersMigration
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new SalesContext();
            ctx.Database.Initialize(true);

            foreach (var c in ctx.Customers)
            {
                //Console.WriteLine($"{c.Name}");
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }
    }
}
