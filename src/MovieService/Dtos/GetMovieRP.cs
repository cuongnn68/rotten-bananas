namespace MovieService.Dtos;

public class GetMovieRP {

    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int DurationByMin { get; set; }

}