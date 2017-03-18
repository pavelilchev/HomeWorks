namespace _5.SalesMigration.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SalesAddDateDefault : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("Sales","Date", s=> s.String(defaultValueSql:"getdate()"));
        }
        
        public override void Down()
        {
            this.AlterColumn("Sales", "Date", s => s.String(defaultValueSql: "NULL"));
        }
    }
}
