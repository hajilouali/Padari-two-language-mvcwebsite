using System.Web.Mvc;

namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductGallery = new HashSet<ProductGallery>();
            ProductProperty = new HashSet<ProductProperty>();
            RowFactor = new HashSet<RowFactor>();
        }
        [Key]
        public int ProductID { get; set; }

        public int? ProductTypeID { get; set; }

        [StringLength(128)]
        public string AspNetUsersID { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [AllowHtml]
        [StringLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDiscription { get; set; }

        public string Text { get; set; }

        [StringLength(350)]
        public string PicThumbnail { get; set; }

        [StringLength(500)]
        public string KeyWord { get; set; }

        public DateTime Date { get; set; }

        public double? UnitSalary { get; set; }

        public int UnitID { get; set; }

        public virtual IdentitySample.Models.ApplicationUser AspNetUsers { get; set; }

        public virtual ProductType ProductType { get; set; }

        public virtual UnitType UnitType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductGallery> ProductGallery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductProperty> ProductProperty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RowFactor> RowFactor { get; set; }

        public virtual ICollection<ProductColors> ProductColorses { get; set; }
    }
}
