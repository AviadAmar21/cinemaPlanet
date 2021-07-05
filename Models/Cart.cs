using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaPlanet.Models
{
    public class Cart
    {

        [Key]
        [Required]
        public string ID { get; set; }

        [Required]
        public string SeatNo { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime pDate { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string MovieId{ get; set; }

    }
}