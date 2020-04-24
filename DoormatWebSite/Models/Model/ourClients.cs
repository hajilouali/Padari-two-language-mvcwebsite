namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ourClients
    {
        [Key]
        public int id { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
    }
}
