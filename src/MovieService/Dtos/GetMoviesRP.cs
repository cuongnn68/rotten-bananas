using MovieService.Models;

namespace MovieService.Dtos;

public class GetMoviesRP {
    public IEnumerable<GetMovieRP> Movies { get; set; }
}