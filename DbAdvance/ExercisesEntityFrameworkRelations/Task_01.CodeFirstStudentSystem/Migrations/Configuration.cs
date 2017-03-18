namespace Task_01.CodeFirstStudentSystem.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentsSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "Task_01.CodeFirstStudentSystem.StudentsSystemContext";
        }
    }
}
