using AutoMapper;
using EmailValidation;
using Microsoft.AspNetCore.Mvc;
using UserManagerService.Configurations;
using UserManagerService.Dtos;
using UserManagerService.Models;
using UserManagerService.Services;

namespace UserManagerService.Controllers;

[ApiController]
[Route("user")]
public class UserInfoController : ControllerBase {
    private readonly AppDbContext dbContext;
    private readonly IMapper mapper;
    private readonly KafkaProducerService kafkaProducer;

    public UserInfoController(AppDbContext dbContext, IMapper mapper, KafkaProducerService kafkaProducer) {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.kafkaProducer = kafkaProducer;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserRP>> GetUsers() {
        var users = dbContext.Users.Select(e => mapper.Map<UserRP>(e)).ToList();
        return users;
    }

    [HttpGet("{username}")]
    public ActionResult<UserRP> GetUser([FromRoute] string username) {
        var user = dbContext.Users.Find(username);
        if(user is null) return NotFound();
        return mapper.Map<UserRP>(user);
    }
    
    // register
    [HttpPost]
    public async Task<ActionResult> CreateUserAsync([FromBody] NewUserRQ newUser) {
        // validator
        if(string.IsNullOrEmpty(newUser.Username)) return BadRequest(new ErrorRP() {ErrorMessage = "Username cant be empty or null"});
        if(string.IsNullOrEmpty(newUser.Password)) return BadRequest(new ErrorRP() {ErrorMessage = "Password cant be empty or null"});
        if(string.IsNullOrEmpty(newUser.Email)) return BadRequest(new ErrorRP() {ErrorMessage = "Email cant be empty or null"});
        
        if(dbContext.Users.Find(newUser.Username) is not null) return BadRequest(new ErrorRP(){ErrorMessage = "Username already exist"});
        if(! EmailValidator.Validate(newUser.Email)) return BadRequest(new ErrorRP(){ErrorMessage = "Email is wrong format"});
        // validate pass?

        var user = mapper.Map<User>(newUser);
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        await kafkaProducer.AddNewMovieAsync(new NewUserAS{Username = user.Username});
        var result = CreatedAtAction(nameof(GetUser), new {Username = user.Username}, mapper.Map<UserRP>(user));
        return result;

    }

    // login
    // logout

    
}