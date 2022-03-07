using System.ComponentModel.DataAnnotations;

namespace RatingService.Models;

public class User {
    [Key]
    // public int Id { get; set; }
    // [Required]
    public string Username { get; set; }

    public IEnumerable<Rating> Ratings { get; set; }
}