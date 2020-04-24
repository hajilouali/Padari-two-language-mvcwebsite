namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ourClientsText")]
    public partial class ourClientsText
    {
        [Key]
        public int id { get; set; }

        [StringLength(150)]
        public string title { get; set; }

        [StringLength(500)]
        public string text { get; set; }

        public int Lanid { get; set; }

        public virtual languageType languageType { get; set; }
    }
}
