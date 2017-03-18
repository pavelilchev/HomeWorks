namespace Task_02.SeedSomeDataInTheDatabase
{
    public class Startup
    {
        public static void Main()
        {
            var ctx = new StudentsSystemContext();
            ctx.Database.Initialize(true);
        }
    }
}
