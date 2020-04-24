namespace DoormatWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProductColorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductColors",
                c => new
                    {
                        ProductColorID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ColorImage = c.String(),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductColorID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductColors", "ProductID", "dbo.Product");
            DropIndex("dbo.ProductColors", new[] { "ProductID" });
            DropTable("dbo.ProductColors");
        }
    }
}
