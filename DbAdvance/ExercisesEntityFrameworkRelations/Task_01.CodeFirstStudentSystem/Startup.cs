namespace Task_01.CodeFirstStudentSystem
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
