namespace Task_03_Projection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EmployeeContext context)
        {
            var manager = new Employee()
            {
                Id = 1,
                FirstName = "Big",
                LastName = "Boss",
                Salary = 9999999m,
                Address = "Hasiendata",
                Birthday = new DateTime(1970, 01, 01)
            };

            context.Employees.AddOrUpdate(m => m.Id, manager);
            context.SaveChanges();

            var emp1 = new Employee()
            {
                Id = 2,
                FirstName = "Kirilyc",
                LastName = "Lefi",
                Salary = 4400m,
                Address = "Geto",
                Birthday = new DateTime(1991, 01, 01),
                ManagerId = 1
            };

            var emp2 = new Employee()
            {
                Id = 3,
                FirstName = "Stephen",
                LastName = "Bjorn",
                Salary = 4300m,
                Address = "Vila",
                Birthday = new DateTime(1980, 01, 01),
                ManagerId = 1
            };

            context.Employees.AddOrUpdate(m => m.Id, emp1, emp2);
            context.SaveChanges();
        }
    }
}
