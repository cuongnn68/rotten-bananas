using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UserManagerService.Models;

namespace UserManagerService.Services;

public class JwtService {
    public static readonly SecurityKey SECRET_KEY = new SymmetricSecurityKey(
        Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"))
    );
    static JwtService() {
        Console.WriteLine(" ===> get key from enviroment");
        Console.WriteLine($"key: {SECRET_KEY}");
    }
    public string CreateToken(User user) {
        var descriptor = new SecurityTokenDescriptor {
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(10),
            TokenType = "JWT",
            SigningCredentials = new SigningCredentials(SECRET_KEY, SecurityAlgorithms.HmacSha256),
            Claims = new Dictionary<string,object> {
                {"username", user.Username},
                {"email", user.Email},
            }
        };
        if(user.Admin != null) descriptor.Claims.Add("admin", user.Admin);
        var handle = new JwtSecurityTokenHandler();
        var token = handle.CreateJwtSecurityToken(descriptor);
        return handle.WriteToken(token);
    }
}