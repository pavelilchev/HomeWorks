namespace Task_01.CodeFirstStudentSystem.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ContentType = c.Int(nullable: false),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);

            this.CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        Birthday = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ResourceType = c.Int(nullable: false),
                        URL = c.String(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);

            this.CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Resources", "Course_Id", "dbo.Courses");
            this.DropForeignKey("dbo.Homework", "Student_Id", "dbo.Students");
            this.DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            this.DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            this.DropForeignKey("dbo.Homework", "Course_Id", "dbo.Courses");
            this.DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            this.DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            this.DropIndex("dbo.Resources", new[] { "Course_Id" });
            this.DropIndex("dbo.Homework", new[] { "Student_Id" });
            this.DropIndex("dbo.Homework", new[] { "Course_Id" });
            this.DropTable("dbo.StudentCourses");
            this.DropTable("dbo.Resources");
            this.DropTable("dbo.Students");
            this.DropTable("dbo.Homework");
            this.DropTable("dbo.Courses");
        }
    }
}
