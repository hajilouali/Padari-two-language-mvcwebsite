namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plan")]
    public partial class Plan
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(450)]
        public string Discription { get; set; }

        [StringLength(150)]
        public string Subtitle { get; set; }

        public int Lanid { get; set; }

        public virtual languageType languageType { get; set; }
    }
}
