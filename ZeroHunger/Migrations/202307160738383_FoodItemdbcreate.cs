namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodItemdbcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        CollectRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectRequests", t => t.CollectRequestId, cascadeDelete: true)
                .Index(t => t.CollectRequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItems", "CollectRequestId", "dbo.CollectRequests");
            DropIndex("dbo.FoodItems", new[] { "CollectRequestId" });
            DropTable("dbo.FoodItems");
        }
    }
}
