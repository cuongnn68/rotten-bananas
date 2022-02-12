using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingService.Configuration;
using RatingService.Dtos;

namespace RatingService.Controllers;

[ApiController]
[Route("api/movie")]
public class MovieController : ControllerBase {
    private readonly AppDbContext dbContext;
    private readonly IMapper mapper;

    public MovieController(AppDbContext dbContext, IMapper mapper) {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    [HttpGet("{id}/rating")]
    public ActionResult<MovieRatingsRP> GetRatings([FromRoute] int id) {
        if(dbContext.Movies.Find(id) == null) return BadRequest(new {Error = "movie not exist"});

        // var movie = dbContext.Ratings.Include(r => r.Movie)
        //                              .Include(r => r.User)
        //                              .Where(r => r.Movie.Id == id)
        //                              .Select(e => mapper.Map<MovieRatingRP>(e));

        var movie = dbContext.Movies.Include(m => m.Ratings).ThenInclude(r => r.User).FirstOrDefault(m => m.Id == id);
        if(movie == null) return BadRequest();
        return new MovieRatingsRP {
            Id = movie.Id, 
            Ratings = movie.Ratings.Select(mapper.Map<MovieRatingRP>) };
    }
}