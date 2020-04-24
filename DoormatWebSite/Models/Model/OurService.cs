namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OurService")]
    public partial class OurService
    {
        [Key]
        public int id { get; set; }

        [StringLength(150)]
        public string image { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(350)]
        public string Subtitle { get; set; }

        [StringLength(450)]
        public string Url { get; set; }

        public int Lanid { get; set; }

        public virtual languageType languageType { get; set; }
    }
}
