using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoormatWebSite.Models.Model
{
    public class ProductColors
    {
        [Key]
        public int ProductColorID { get; set; }

        public string Title { get; set; }
        public string ColorImage { get; set; }
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}