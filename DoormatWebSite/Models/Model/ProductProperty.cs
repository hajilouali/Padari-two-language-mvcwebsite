namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductProperty")]
    public partial class ProductProperty
    {
        [Key]
        public int ProductPropertyID { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(450)]
        public string Discription { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
