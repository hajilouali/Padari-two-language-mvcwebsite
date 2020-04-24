namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OurWorkGalleryType")]
    public partial class OurWorkGalleryType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OurWorkGalleryType()
        {
            OurWorkGallery = new HashSet<OurWorkGallery>();
        }
        [Key]
        public int OurWorkGalleryTypeid { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public int Lanid { get; set; }

        public virtual languageType LanguageType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OurWorkGallery> OurWorkGallery { get; set; }
    }
}
