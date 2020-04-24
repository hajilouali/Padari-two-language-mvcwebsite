using System.Web.Mvc;

namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        [Key]
        public int SliderID { get; set; }

        [Required]
        [StringLength(350)]
        public string Image { get; set; }

        [StringLength(150)]
        [AllowHtml]
        public string Title { get; set; }

        [StringLength(250)]
        [AllowHtml]
        public string SubTitle { get; set; }

        [StringLength(250)]
        [AllowHtml]
        public string Subtitle1 { get; set; }

        [StringLength(250)]
        [AllowHtml]
        public string Subtitle2 { get; set; }

        public int Lanid { get; set; }

        public virtual languageType languageType { get; set; }
    }
}
