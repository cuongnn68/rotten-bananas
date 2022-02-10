using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatingService.Models;

public class Rating {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int Score { get; set; }
    [Required]
    public DateTime Time { get; set; }
    [Required]
    public string Review { get; set; }


    [ForeignKey("Movie")]
    public int IdMovie { get; set; }
    public Movie Movie { get; set; }

    [ForeignKey("User")]
    public string Username { get; set; }
    public User User { get; set; }
}