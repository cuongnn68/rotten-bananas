using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos;

public class UpdateMovieRQ {
    [Required]
    public string Name { get; set; }
    [Required]
    public string ReleaseDate { get; set; }
    [Required]
    public int DurationByMin { get; set; }
    [Required]
    public bool Active { get; set; }
}