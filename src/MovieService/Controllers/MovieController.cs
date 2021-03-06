using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.Configuration;
using MovieService.Dtos;
using MovieService.Models;
using MovieService.Services;
using MovieService.Util;

namespace MovieService.Controllers.Movie;

[ApiController]
[Route("api/movie")]
public class MovieController : ControllerBase {
    private AppDbContext dbContext;
    private IMapper mapper;
    private IMessageBusService kafkaClient;

    public MovieController(AppDbContext dbContext, IMapper mapper, IMessageBusService kafkaClient) {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.kafkaClient = kafkaClient;
    }

    [HttpGet("test")]
    [Authorize]
    public IActionResult Test() {
        return Ok();
    }
    [HttpGet("username")]
    [Authorize("username")]
    public IActionResult Username() {
        return Ok();
    }
    [HttpGet("admin")]
    [Authorize("admin")]
    public IActionResult Admin() {
        return Ok();
    }

    [HttpGet]
    public ActionResult<GetMoviesRP> GetAll() {
        return new GetMoviesRP {
            Movies = dbContext.Movies
                            .Where(e => e.Active == true)
                            .Select(e => mapper.Map<GetMovieRP>(e))};
    }

    [HttpGet("{id}")]
    public ActionResult<GetMovieRP> GetById([FromRoute] int id) {
        var movie = dbContext.Movies.Where(e => e.Active == true && e.Id == id).FirstOrDefault();
        if(movie == null) return NotFound();
        return mapper.Map<GetMovieRP>(movie);
    }

    [HttpPost]
    async public Task<ActionResult> Add([FromBody] NewMovieRQ newMovie) {
        if(! Validator.IsDateValid(newMovie.ReleaseDate)) return BadRequest();
        var movie = dbContext.Movies.Add(mapper.Map<Models.Movie>(newMovie)).Entity;
        await kafkaClient.AddNewMovieAsync(mapper.Map<NewMovieAS>(movie));
        var result = CreatedAtAction(nameof(GetById), new {Id = movie.Id}, mapper.Map<GetMovieRP>(movie));
        dbContext.SaveChanges();
        return result;
        // return CreatedAtRoute(nameof(GetById), new {Id = movie.Id}, movie); // method need name in atribute [HttpMethod]
        // return CreatedAtAction(nameof(GetById), new {Id = movie.Id}, mapper.Map<GetMovieRP>(movie)); // name of function
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteById([FromRoute] int id) {
        var movie = dbContext.Movies.Find(id);
        if(movie == null) return BadRequest();
        movie.Active = false;
        dbContext.SaveChanges();
        return Ok();
    }


    // TODO:
    // [HttpPut("/{id}")]

}