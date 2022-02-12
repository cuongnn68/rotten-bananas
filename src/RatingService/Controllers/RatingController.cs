using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingService.Util;
using RatingService.Configuration;
using RatingService.Dtos;
using RatingService.Models;

namespace RatingService.Controllers;

[ApiController]
[Route("api/rating")]
public class RatingController : ControllerBase {
    private AppDbContext dbContext;
    private IMapper mapper;

    public RatingController(AppDbContext dbContext, IMapper mapper) {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<RatingsRP> GetAll() {
        var ratings = dbContext.Ratings.Include(rt => rt.Movie)
                                       .Include(rt => rt.User)
                                       .Select(e => mapper.Map<RatingRP>(e));
        return new RatingsRP {Ratings = ratings};
    }

    [HttpGet("{id}")]
    public ActionResult<RatingRP> GetById([FromRoute] int id) {
        var rating = dbContext.Ratings.Include(rt => rt.Movie)
                                      .Include(rt => rt.User)
                                      .FirstOrDefault(rt => rt.Id == id);
        if(rating == null) return NotFound();
        return mapper.Map<RatingRP>(rating);
    }

    [HttpPost]
    public ActionResult CreateRating([FromBody] NewRatingRQ newRating) {
        if(!Validator.IsDateTimeValid(newRating.Time)) return BadRequest(new ErrorRP {ErrorMessage = "Wrong time format"});
        if(dbContext.Users.Find(newRating.Username) is null) return BadRequest(new ErrorRP {ErrorMessage = "User not exist"});
        if(dbContext.Movies.Find(newRating.IdMovie) is null) return BadRequest(new ErrorRP {ErrorMessage = "Movie not exist"});
        if(dbContext.Ratings.Where(r => r.IdMovie == newRating.IdMovie && r.Username == newRating.Username).Any()) {
            return BadRequest(new ErrorRP {ErrorMessage = "User already rate movie"});
        }
        var rating = dbContext.Ratings.Add(mapper.Map<Rating>(newRating)).Entity;
        dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {Id = rating.Id}, mapper.Map<RatingRP>(rating));
    }
    // [HttpPut]
    // [HttpDelete]

    
}