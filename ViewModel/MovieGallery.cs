using CinemaPlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaPlanet.ViewModel
{
    public class MovieGallery
    {
        public List<Movie> Movies { get; set; }
        public List <Hall> Halls{ get; set; }
        public List <Screen> Screens { get; set; }

    }
}