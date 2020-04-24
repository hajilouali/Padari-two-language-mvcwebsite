namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factor")]
    public partial class Factor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factor()
        {
            AttachmentFactor = new HashSet<AttachmentFactor>();
            FactorAndService = new HashSet<FactorAndService>();
            RowFactor = new HashSet<RowFactor>();
        }
        [Key]
        public int FactorID { get; set; }

        [StringLength(128)]
        public string AspNetUsersID { get; set; }

        public double TotalSalary { get; set; }

        public int? Discount { get; set; }

        public DateTime Date { get; set; }

        public int FactorStateID { get; set; }

        [StringLength(350)]
        public string FactorDiscription { get; set; }

        public double Salary { get; set; }

        public double? ArzeshAfzodeh { get; set; }

        [StringLength(150)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerPhone { get; set; }

        [StringLength(350)]
        public string CustomerAddress { get; set; }

        public virtual IdentitySample.Models.ApplicationUser AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttachmentFactor> AttachmentFactor { get; set; }

        public virtual FactorState FactorState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactorAndService> FactorAndService { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RowFactor> RowFactor { get; set; }
    }
}
