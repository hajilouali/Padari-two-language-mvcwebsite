namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RowFactor")]
    public partial class RowFactor
    {
        [Key]
        public int RowFactorID { get; set; }

        public int ProductID { get; set; }

        public int FactorID { get; set; }

        public double? Lenght { get; set; }

        public double? Width { get; set; }

        public int Count { get; set; }

        public double Amount { get; set; }

        public double RowSalary { get; set; }

        [StringLength(450)]
        public string RowDiscription { get; set; }

        public string RowConfig { get; set; }

        public virtual Factor Factor { get; set; }

        public virtual Product Product { get; set; }
    }
}
