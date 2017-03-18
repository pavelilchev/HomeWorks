namespace _5.SalesMigration
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var ctx = new SalesContext();
            ctx.Database.Initialize(true);
            foreach (var sale in ctx.Sales)
            {
                Console.WriteLine($"{sale.Id,-5} {sale.Date}");
            }
        }
    }
}
