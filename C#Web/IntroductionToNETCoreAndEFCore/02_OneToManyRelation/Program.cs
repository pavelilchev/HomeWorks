namespace _02_OneToManyRelation
{
    using _02_OneToManyRelation.Data;

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
