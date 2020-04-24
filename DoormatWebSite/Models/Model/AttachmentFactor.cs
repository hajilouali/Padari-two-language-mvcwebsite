namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttachmentFactor")]
    public partial class AttachmentFactor
    {
        [Key]
        public int AttachmentFactorID { get; set; }

        [StringLength(350)]
        public string AttachmentDiscription { get; set; }

        [Required]
        [StringLength(350)]
        public string FileAttach { get; set; }

        public int FactorID { get; set; }

        public virtual Factor Factor { get; set; }
    }
}
