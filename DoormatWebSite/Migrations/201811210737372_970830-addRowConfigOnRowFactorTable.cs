namespace DoormatWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _970830addRowConfigOnRowFactorTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RowFactor", "FactorID", "dbo.Factor");
            DropForeignKey("dbo.RowFactor", "ProductID", "dbo.Product");
            DropIndex("dbo.RowFactor", new[] { "ProductID" });
            DropIndex("dbo.RowFactor", new[] { "FactorID" });
            AddColumn("dbo.RowFactor", "RowConfig", c => c.String());
            AlterColumn("dbo.RowFactor", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.RowFactor", "FactorID", c => c.Int(nullable: false));
            CreateIndex("dbo.RowFactor", "ProductID");
            CreateIndex("dbo.RowFactor", "FactorID");
            AddForeignKey("dbo.RowFactor", "FactorID", "dbo.Factor", "FactorID", cascadeDelete: true);
            AddForeignKey("dbo.RowFactor", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RowFactor", "ProductID", "dbo.Product");
            DropForeignKey("dbo.RowFactor", "FactorID", "dbo.Factor");
            DropIndex("dbo.RowFactor", new[] { "FactorID" });
            DropIndex("dbo.RowFactor", new[] { "ProductID" });
            AlterColumn("dbo.RowFactor", "FactorID", c => c.Int());
            AlterColumn("dbo.RowFactor", "ProductID", c => c.Int());
            DropColumn("dbo.RowFactor", "RowConfig");
            CreateIndex("dbo.RowFactor", "FactorID");
            CreateIndex("dbo.RowFactor", "ProductID");
            AddForeignKey("dbo.RowFactor", "ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.RowFactor", "FactorID", "dbo.Factor", "FactorID");
        }
    }
}
