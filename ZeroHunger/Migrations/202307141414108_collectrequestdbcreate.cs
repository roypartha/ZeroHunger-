namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collectrequestdbcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        AssigneDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restuarant1", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectRequests", "RestaurantId", "dbo.Restuarant1");
            DropIndex("dbo.CollectRequests", new[] { "RestaurantId" });
            DropTable("dbo.CollectRequests");
        }
    }
}
