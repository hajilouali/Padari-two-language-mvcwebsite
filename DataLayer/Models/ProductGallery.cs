//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductGallery
    {
        public int ProductGalleryID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public int ProductID { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
