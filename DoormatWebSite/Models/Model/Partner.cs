namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partner")]
    public partial class Partner
    {
        [Key]
        public int id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        [StringLength(550)]
        public string Address { get; set; }

        [StringLength(150)]
        public string PhoneNumer { get; set; }

        [StringLength(150)]
        public string PhoneNumer2 { get; set; }

        [StringLength(150)]
        public string Mobile { get; set; }

        public int Lanid { get; set; }

        public bool? BranchOffice { get; set; }

        public virtual languageType LanguageType { get; set; }
    }
}
