using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaPlanet.Models
{
    public class Screen
    {

        [Key]
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "ID must be between 1 to 50 letters")]
        public string ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Hall name must be between 2 to 50 letters")]
        public string sHallName { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format")]
        public DateTime ScreenDate { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        public string SeatStatus{ get; set; }

        

        public Screen()
        {
            SeatStatus = "0";
            for (int i = 0; i < 31; i++)
                SeatStatus += "0";


            
        }


    }
}