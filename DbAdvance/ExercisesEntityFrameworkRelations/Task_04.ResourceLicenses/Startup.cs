namespace Task_04.ResourceLicenses
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
