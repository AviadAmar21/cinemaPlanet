using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaPlanet.Models;

namespace CinemaPlanet.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies{ get; set; }

    
    }
}