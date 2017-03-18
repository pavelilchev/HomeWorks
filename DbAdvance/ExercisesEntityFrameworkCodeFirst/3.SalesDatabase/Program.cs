namespace _3.SalesDatabase
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var ctx = new SalesContext();
            foreach (var c in ctx.Customers)
            {
                Console.WriteLine($"{c.Name}");
            }
        }
    }
}
