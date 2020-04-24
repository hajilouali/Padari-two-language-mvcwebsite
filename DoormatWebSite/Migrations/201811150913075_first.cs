namespace DoormatWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttachmentFactor",
                c => new
                    {
                        AttachmentFactorID = c.Int(nullable: false, identity: true),
                        AttachmentDiscription = c.String(maxLength: 350),
                        FileAttach = c.String(nullable: false, maxLength: 350),
                        FactorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttachmentFactorID)
                .ForeignKey("dbo.Factor", t => t.FactorID, cascadeDelete: true)
                .Index(t => t.FactorID);
            
            CreateTable(
                "dbo.Factor",
                c => new
                    {
                        FactorID = c.Int(nullable: false, identity: true),
                        AspNetUsersID = c.String(maxLength: 128),
                        TotalSalary = c.Double(nullable: false),
                        Discount = c.Int(),
                        Date = c.DateTime(nullable: false),
                        FactorStateID = c.Int(nullable: false),
                        FactorDiscription = c.String(maxLength: 350),
                        Salary = c.Double(nullable: false),
                        ArzeshAfzodeh = c.Double(),
                        CustomerName = c.String(maxLength: 150),
                        CustomerPhone = c.String(maxLength: 50),
                        CustomerAddress = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.FactorID)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsersID)
                .ForeignKey("dbo.FactorState", t => t.FactorStateID, cascadeDelete: true)
                .Index(t => t.AspNetUsersID)
                .Index(t => t.FactorStateID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FactorAndService",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        FactorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Factor", t => t.FactorID, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID)
                .Index(t => t.FactorID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            CreateTable(
                "dbo.FactorState",
                c => new
                    {
                        FactorStateID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.FactorStateID);
            
            CreateTable(
                "dbo.RowFactor",
                c => new
                    {
                        RowFactorID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        FactorID = c.Int(),
                        Lenght = c.Double(),
                        Width = c.Double(),
                        Count = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        RowSalary = c.Double(nullable: false),
                        RowDiscription = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.RowFactorID)
                .ForeignKey("dbo.Factor", t => t.FactorID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.FactorID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductTypeID = c.Int(),
                        AspNetUsersID = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 150),
                        ShortDiscription = c.String(maxLength: 350),
                        Text = c.String(),
                        PicThumbnail = c.String(maxLength: 350),
                        KeyWord = c.String(maxLength: 500),
                        Date = c.DateTime(nullable: false),
                        UnitSalary = c.Double(),
                        UnitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsersID)
                .ForeignKey("dbo.ProductType", t => t.ProductTypeID)
                .ForeignKey("dbo.UnitType", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.ProductTypeID)
                .Index(t => t.AspNetUsersID)
                .Index(t => t.UnitID);
            
            CreateTable(
                "dbo.ProductGallery",
                c => new
                    {
                        ProductGalleryID = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false, maxLength: 350),
                        Title = c.String(maxLength: 150),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductGalleryID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductProperty",
                c => new
                    {
                        ProductPropertyID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Discription = c.String(maxLength: 450),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPropertyID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Lanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTypeId)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.languageType",
                c => new
                    {
                        Lanid = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Lanid);
            
            CreateTable(
                "dbo.ourClientsText",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 150),
                        text = c.String(maxLength: 500),
                        Lanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.OurService",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 150),
                        Title = c.String(maxLength: 250),
                        Subtitle = c.String(maxLength: 350),
                        Url = c.String(maxLength: 450),
                        Lanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.OurWorkGalleryType",
                c => new
                    {
                        OurWorkGalleryTypeid = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Lanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OurWorkGalleryTypeid)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.OurWorkGallery",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OurWorkGalleryTypeid = c.Int(nullable: false),
                        Name = c.String(maxLength: 250),
                        Image = c.String(maxLength: 350),
                        idSize = c.Int(nullable: false),
                        date = c.DateTime(),
                        ImageSize_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ImageSize", t => t.ImageSize_id)
                .ForeignKey("dbo.OurWorkGalleryType", t => t.OurWorkGalleryTypeid, cascadeDelete: true)
                .Index(t => t.OurWorkGalleryTypeid)
                .Index(t => t.ImageSize_id);
            
            CreateTable(
                "dbo.ImageSize",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Partner",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        City = c.String(maxLength: 150),
                        Address = c.String(maxLength: 550),
                        PhoneNumer = c.String(maxLength: 150),
                        PhoneNumer2 = c.String(maxLength: 150),
                        Mobile = c.String(maxLength: 150),
                        Lanid = c.Int(nullable: false),
                        BranchOffice = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Icon = c.String(maxLength: 50),
                        Title = c.String(maxLength: 150),
                        Discription = c.String(maxLength: 450),
                        Subtitle = c.String(maxLength: 150),
                        Lanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.PostType",
                c => new
                    {
                        PostTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Lanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostTypeID)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(nullable: false, maxLength: 150),
                        PostText = c.String(),
                        PostTypeID = c.Int(),
                        PostShortDiscription = c.String(maxLength: 350),
                        PostDate = c.DateTime(nullable: false),
                        KeyWord = c.String(maxLength: 300),
                        AspNetUsersID = c.String(maxLength: 128),
                        PostImage = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsersID)
                .ForeignKey("dbo.PostType", t => t.PostTypeID)
                .Index(t => t.PostTypeID)
                .Index(t => t.AspNetUsersID);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false, maxLength: 350),
                        Title = c.String(maxLength: 150),
                        SubTitle = c.String(maxLength: 250),
                        Subtitle1 = c.String(maxLength: 250),
                        Subtitle2 = c.String(maxLength: 250),
                        Lanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SliderID)
                .ForeignKey("dbo.languageType", t => t.Lanid, cascadeDelete: true)
                .Index(t => t.Lanid);
            
            CreateTable(
                "dbo.UnitType",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.UnitID);
            
            CreateTable(
                "dbo.ourClients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Product", "UnitID", "dbo.UnitType");
            DropForeignKey("dbo.RowFactor", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductTypeID", "dbo.ProductType");
            DropForeignKey("dbo.Slider", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.ProductType", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.Post", "PostTypeID", "dbo.PostType");
            DropForeignKey("dbo.Post", "AspNetUsersID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostType", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.Plan", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.Partner", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.OurWorkGallery", "OurWorkGalleryTypeid", "dbo.OurWorkGalleryType");
            DropForeignKey("dbo.OurWorkGallery", "ImageSize_id", "dbo.ImageSize");
            DropForeignKey("dbo.OurWorkGalleryType", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.OurService", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.ourClientsText", "Lanid", "dbo.languageType");
            DropForeignKey("dbo.ProductProperty", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductGallery", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "AspNetUsersID", "dbo.AspNetUsers");
            DropForeignKey("dbo.RowFactor", "FactorID", "dbo.Factor");
            DropForeignKey("dbo.Factor", "FactorStateID", "dbo.FactorState");
            DropForeignKey("dbo.FactorAndService", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.FactorAndService", "FactorID", "dbo.Factor");
            DropForeignKey("dbo.AttachmentFactor", "FactorID", "dbo.Factor");
            DropForeignKey("dbo.Factor", "AspNetUsersID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Slider", new[] { "Lanid" });
            DropIndex("dbo.Post", new[] { "AspNetUsersID" });
            DropIndex("dbo.Post", new[] { "PostTypeID" });
            DropIndex("dbo.PostType", new[] { "Lanid" });
            DropIndex("dbo.Plan", new[] { "Lanid" });
            DropIndex("dbo.Partner", new[] { "Lanid" });
            DropIndex("dbo.OurWorkGallery", new[] { "ImageSize_id" });
            DropIndex("dbo.OurWorkGallery", new[] { "OurWorkGalleryTypeid" });
            DropIndex("dbo.OurWorkGalleryType", new[] { "Lanid" });
            DropIndex("dbo.OurService", new[] { "Lanid" });
            DropIndex("dbo.ourClientsText", new[] { "Lanid" });
            DropIndex("dbo.ProductType", new[] { "Lanid" });
            DropIndex("dbo.ProductProperty", new[] { "ProductID" });
            DropIndex("dbo.ProductGallery", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "UnitID" });
            DropIndex("dbo.Product", new[] { "AspNetUsersID" });
            DropIndex("dbo.Product", new[] { "ProductTypeID" });
            DropIndex("dbo.RowFactor", new[] { "FactorID" });
            DropIndex("dbo.RowFactor", new[] { "ProductID" });
            DropIndex("dbo.FactorAndService", new[] { "FactorID" });
            DropIndex("dbo.FactorAndService", new[] { "ServiceID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Factor", new[] { "FactorStateID" });
            DropIndex("dbo.Factor", new[] { "AspNetUsersID" });
            DropIndex("dbo.AttachmentFactor", new[] { "FactorID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ourClients");
            DropTable("dbo.UnitType");
            DropTable("dbo.Slider");
            DropTable("dbo.Post");
            DropTable("dbo.PostType");
            DropTable("dbo.Plan");
            DropTable("dbo.Partner");
            DropTable("dbo.ImageSize");
            DropTable("dbo.OurWorkGallery");
            DropTable("dbo.OurWorkGalleryType");
            DropTable("dbo.OurService");
            DropTable("dbo.ourClientsText");
            DropTable("dbo.languageType");
            DropTable("dbo.ProductType");
            DropTable("dbo.ProductProperty");
            DropTable("dbo.ProductGallery");
            DropTable("dbo.Product");
            DropTable("dbo.RowFactor");
            DropTable("dbo.FactorState");
            DropTable("dbo.Service");
            DropTable("dbo.FactorAndService");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Factor");
            DropTable("dbo.AttachmentFactor");
        }
    }
}
