namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductGallery")]
    public partial class ProductGallery
    {
        [Key]
        public int ProductGalleryID { get; set; }

        [Required]
        [StringLength(350)]
        public string Image { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
