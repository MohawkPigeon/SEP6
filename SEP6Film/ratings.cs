//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEP6Film
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ratings
    {
        [Key]
        public int movie_id { get; set; }
        public double rating { get; set; }
        public int votes { get; set; }
        [Required]
        public virtual movies movies { get; set; }
    }
}