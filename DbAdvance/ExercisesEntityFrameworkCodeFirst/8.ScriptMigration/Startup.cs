namespace _8.ScriptMigration
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
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }
    }
}
