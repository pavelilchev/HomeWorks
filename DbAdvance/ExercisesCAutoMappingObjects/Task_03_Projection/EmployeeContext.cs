namespace Task_03_Projection
{
    using System.Data.Entity;
    using Migrations;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeContext, Configuration>());
        }

         public virtual DbSet<Employee> Employees { get; set; }
    }
}