using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace RatingService.Models;

public class Movie {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public IEnumerable<Rating> Ratings { get; set; }
}