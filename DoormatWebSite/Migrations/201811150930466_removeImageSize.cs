namespace DoormatWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeImageSize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OurWorkGallery", "ImageSize_id", "dbo.ImageSize");
            DropIndex("dbo.OurWorkGallery", new[] { "ImageSize_id" });
            DropColumn("dbo.OurWorkGallery", "idSize");
            DropColumn("dbo.OurWorkGallery", "ImageSize_id");
            DropTable("dbo.ImageSize");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageSize",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.OurWorkGallery", "ImageSize_id", c => c.Int());
            AddColumn("dbo.OurWorkGallery", "idSize", c => c.Int(nullable: false));
            CreateIndex("dbo.OurWorkGallery", "ImageSize_id");
            AddForeignKey("dbo.OurWorkGallery", "ImageSize_id", "dbo.ImageSize", "id");
        }
    }
}
