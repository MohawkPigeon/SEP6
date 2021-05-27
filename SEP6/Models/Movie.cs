using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6.Models
{
    public class Movie
    {
        [Key]
        int movieId { get; }
        string title { get; set; }
        List<Cast> movieCast { get; set; }
        List<Cast> movieDirectors { get; set; }
    }
}
