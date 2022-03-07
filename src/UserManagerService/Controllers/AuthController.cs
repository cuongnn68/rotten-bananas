using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagerService.Configurations;
using UserManagerService.Dtos;
using UserManagerService.Services;

namespace UserManagerService.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly AppDbContext dbContext;
    private readonly JwtService jwtService;
    private readonly IMapper mapper;

    public AuthController(AppDbContext dbContext, JwtService jwtService, IMapper mapper) {
        this.dbContext = dbContext;
        this.jwtService = jwtService;
        this.mapper = mapper;
    }


    [Authorize]
    [HttpGet]
    public ActionResult TestAuth() {
        // var claims = User.Claims.Select(claim => new Claim(claim.Type, claim.Value));
        return Ok(new AuthRP {Claims = User.Claims.Select(claim => mapper.Map<ClaimRP>(claim))});
    }
    [Authorize("user")]
    [HttpGet("user")]
    public ActionResult TestAuthUser() {
        return Ok();
    }
    [Authorize("admin")]
    [HttpGet("admin")]
    public ActionResult TestAuthAdmin() {
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login() {
        return Ok(new {token = jwtService.CreateToken(dbContext.Users.FirstOrDefault())});
        throw new NotImplementedException();
    }

    [HttpPost("register")] // should be on user manager controller
    public ActionResult Register() {
        throw new NotImplementedException();
    }

    [HttpPost("logout")]
    public ActionResult Logout() {
        throw new NotImplementedException();

    }
}