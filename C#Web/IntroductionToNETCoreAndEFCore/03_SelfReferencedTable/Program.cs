namespace _03_SelfReferencedTable
{
    using _03_SelfReferencedTable.Data;
    using System;

    public class Program
    {
        public static void Main()
        {
            var ctx = new CompanyContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            System.Console.WriteLine("Done.");
        }
    }
}
