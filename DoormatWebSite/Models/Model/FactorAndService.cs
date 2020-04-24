namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactorAndService")]
    public partial class FactorAndService
    {
        [Key]
        public int id { get; set; }

        public int ServiceID { get; set; }

        public int FactorID { get; set; }

        public virtual Factor Factor { get; set; }

        public virtual Service Service { get; set; }
    }
}
