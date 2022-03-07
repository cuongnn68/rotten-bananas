using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatingService.Dtos {
    public class NewRatingRQ {
        [Required]
        public int Score { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Review { get; set; }

        [Required]
        public int IdMovie { get; set; }

        [Required]
        public string Username { get; set; }

    }
}