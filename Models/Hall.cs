using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaPlanet.Models
{
    public class Hall
    {
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "ID must be between 1 to 50 letters")]
        public string ID{ get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Hall name must be between 2 to 50 letters")]
        public string HallName { get; set; }

        [Required]
        [Range(1, 32, ErrorMessage = "Please enter valid seats number in hall , seats range 1 to 32")]
        public int SeatsNumber { get; set; }

    }
}