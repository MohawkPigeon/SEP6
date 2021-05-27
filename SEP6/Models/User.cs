using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6.Models
{
    public class User
    {
        [Key]
        int userId { get; }
        string username { get; set; }
        string password { get; set; }
        List<Movie> FavoriteMovies { get; set; }
        List<Rating> ratings { get; set; }
    }
}
