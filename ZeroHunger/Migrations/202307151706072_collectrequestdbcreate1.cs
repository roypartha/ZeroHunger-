namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collectrequestdbcreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectRequests", "EmployeeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectRequests", "EmployeeId");
        }
    }
}
