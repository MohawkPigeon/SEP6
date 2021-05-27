using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6.Models
{
    public class Rating
    {
        [Key]
        int ratingId { get; }
        Movie movie { get; set; }
        int rated { get; set; }
    }
}
