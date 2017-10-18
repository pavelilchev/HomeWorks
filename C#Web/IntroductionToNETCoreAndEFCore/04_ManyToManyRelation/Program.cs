using System;

namespace _04_ManyToManyRelation
{
    public class Program
    {
        public static void Main()
        {
            var ctx = new SchoolContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            System.Console.WriteLine("Done.");
        }
    }
}
