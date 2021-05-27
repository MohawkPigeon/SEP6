using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6.Models
{
    public class Cast
    {
        //[Key]
        int castId { get; }
        string name { get; set; }
        List<Movie> starringIn { get; set; }
        List<Movie> Directs { get; set; }
    }
}
