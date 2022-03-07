using System.Collections.Generic;

namespace RatingService.Dtos;

public class MovieRatingsRP {
    public int Id { get; set; }
    public IEnumerable<MovieRatingRP> Ratings { get; set; }
}