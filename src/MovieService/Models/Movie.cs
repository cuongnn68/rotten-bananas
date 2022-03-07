using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Models;

public class Movie {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public int DurationByMin { get; set; }
    [Required]
    public bool Active { get; set; }
}