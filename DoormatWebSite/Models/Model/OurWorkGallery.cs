namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OurWorkGallery")]
    public partial class OurWorkGallery
    {
        [Key]
        public int id { get; set; }

        public int OurWorkGalleryTypeid { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(350)]
        public string Image { get; set; }

        public DateTime date { get; set; }


        public virtual OurWorkGalleryType OurWorkGalleryType { get; set; }
    }
}
