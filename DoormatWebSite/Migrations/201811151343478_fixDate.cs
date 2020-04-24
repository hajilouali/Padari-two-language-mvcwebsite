namespace DoormatWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OurWorkGallery", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OurWorkGallery", "date", c => c.DateTime());
        }
    }
}
