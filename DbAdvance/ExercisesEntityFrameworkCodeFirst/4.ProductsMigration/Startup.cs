namespace _4.ProductsMigration
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var ctx = new SalesContext();
            ctx.Database.Initialize(true);
            foreach (var p in ctx.Products)
            {
                Console.WriteLine($"{p.Name,-15} {p.Description}");
            }
        }
    }
}
