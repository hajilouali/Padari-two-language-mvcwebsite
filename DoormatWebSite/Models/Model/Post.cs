using System.Web.Mvc;

namespace DoormatWebSite.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        [StringLength(150)]

        public string PostTitle { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string PostText { get; set; }

        public int? PostTypeID { get; set; }
        [AllowHtml]
        [StringLength(350)]
        [DataType(DataType.MultilineText)]
        public string PostShortDiscription { get; set; }
        
        public DateTime PostDate { get; set; }

        [StringLength(300)]
        public string KeyWord { get; set; }

        [StringLength(128)]
        public string AspNetUsersID { get; set; }

        [StringLength(150)]
        public string PostImage { get; set; }

        public virtual IdentitySample.Models.ApplicationUser AspNetUsers { get; set; }

        public virtual PostType PostType { get; set; }
    }
}
