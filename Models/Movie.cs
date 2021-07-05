using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaPlanet.Models
{
    public class Movie
    {
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "ID must be between 1 to 50 letters")]
        public string ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Movie name must be between 2 to 50 letters")]
        public string mName { get; set; }


        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format")]
        public DateTime mDate { get; set; }

        [Required]
        [Range(5, 60, ErrorMessage = "Please enter valid price , Price movie range 5$ to 60$")]
        public int Price { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Hall name must be between 1 to 50 letters")]
        public string HallName { get; set; }

        [Required]
        [Range(3, 18, ErrorMessage = "Please enter valid minimum age , Age range 3 to 18")]
        public int Age { get; set; }

        [Required]
        
        public string Category { get; set; }

    }

    public enum Categories
    {
        ACTION,
        ANIMATION,
        COMEDY,
        CRIME,
        DRAMA,
        FANTASY,
        HORROR,
        ROMANCE,
        OTHER
    }
}