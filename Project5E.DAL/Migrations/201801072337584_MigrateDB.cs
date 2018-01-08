namespace Project5E.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        ManagerID = c.Int(nullable: false),
                        ManagerName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ManagerID);
            
            CreateTable(
                "dbo.SaleInfo",
                c => new
                    {
                        SaleInfoID = c.Int(nullable: false),
                        ManagerID = c.Int(nullable: false),
                        ClientName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Product = c.String(nullable: false, maxLength: 50, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleInfoID)
                .ForeignKey("dbo.Manager", t => t.ManagerID)
                .Index(t => t.ManagerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleInfo", "ManagerID", "dbo.Manager");
            DropIndex("dbo.SaleInfo", new[] { "ManagerID" });
            DropTable("dbo.SaleInfo");
            DropTable("dbo.Manager");
        }
    }
}
