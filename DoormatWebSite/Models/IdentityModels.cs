using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using DoormatWebSite.Models.Model;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        //khodam
        //public Models()
        //    : base("name=DoormatEntities")
        //{
        //}

        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; 
        public virtual DbSet<ProductColors> ProductColorses { get; set; }
        public virtual DbSet<AttachmentFactor> AttachmentFactor { get; set; }
        public virtual DbSet<Factor> Factor { get; set; }
        public virtual DbSet<FactorAndService> FactorAndService { get; set; }
        public virtual DbSet<FactorState> FactorState { get; set; }
        public virtual DbSet<languageType> languageType { get; set; }
        public virtual DbSet<ourClients> ourClients { get; set; }
        public virtual DbSet<ourClientsText> ourClientsText { get; set; }
        public virtual DbSet<OurService> OurService { get; set; }
        public virtual DbSet<OurWorkGallery> OurWorkGallery { get; set; }
        public virtual DbSet<OurWorkGalleryType> OurWorkGalleryType { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostType> PostType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGallery> ProductGallery { get; set; }
        public virtual DbSet<ProductProperty> ProductProperty { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<RowFactor> RowFactor { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            

        //    modelBuilder.Entity<AspNetUsers>()
        //        .HasMany(e => e.Factor)
        //        .WithRequired(e => e.AspNetUsers)
        //        .HasForeignKey(e => e.AspNetUserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<AspNetUsers>()
        //        .HasMany(e => e.Product)
        //        .WithRequired(e => e.AspNetUsers)
        //        .HasForeignKey(e => e.AspNetUserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Factor>()
        //        .HasMany(e => e.FactorAndService)
        //        .WithRequired(e => e.Factor)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<FactorState>()
        //        .HasMany(e => e.Factor)
        //        .WithRequired(e => e.FactorState)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ImageSize>()
        //        .HasMany(e => e.OurWorkGallery)
        //        .WithRequired(e => e.ImageSize)
        //        .HasForeignKey(e => e.idSize)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.ourClientsText)
        //        .WithRequired(e => e.languageType)
        //        .HasForeignKey(e => e.languageCode)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.OurService)
        //        .WithRequired(e => e.languageType)
        //        .HasForeignKey(e => e.LanguageCode)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.OurWorkGalleryType)
        //        .WithRequired(e => e.languageType1)
        //        .HasForeignKey(e => e.languageType)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.Partner)
        //        .WithRequired(e => e.languageType1)
        //        .HasForeignKey(e => e.languageType)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.Plan)
        //        .WithRequired(e => e.languageType)
        //        .HasForeignKey(e => e.LanCode)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.PostType)
        //        .WithRequired(e => e.languageType1)
        //        .HasForeignKey(e => e.languageType)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.ProductType)
        //        .WithRequired(e => e.languageType1)
        //        .HasForeignKey(e => e.languageType)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<languageType>()
        //        .HasMany(e => e.Slider)
        //        .WithRequired(e => e.languageType1)
        //        .HasForeignKey(e => e.languageType)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<OurWorkGalleryType>()
        //        .HasMany(e => e.OurWorkGallery)
        //        .WithRequired(e => e.OurWorkGalleryType)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Product>()
        //        .HasMany(e => e.ProductGallery)
        //        .WithRequired(e => e.Product)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Product>()
        //        .HasMany(e => e.ProductProperty)
        //        .WithRequired(e => e.Product)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Service>()
        //        .HasMany(e => e.FactorAndService)
        //        .WithRequired(e => e.Service)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<UnitType>()
        //        .HasMany(e => e.Product)
        //        .WithRequired(e => e.UnitType)
        //        .WillCascadeOnDelete(false);
        //}

    }
}