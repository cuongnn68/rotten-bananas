using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MovieService.Auth;

public class AuthResponse {
    [Required]
    public IEnumerable<ResponseClaim> Claims { get; set; }
}

public class ResponseClaim {
    [Required]
    public string Type { get; set; }
    [Required]
    public string Value { get; set; }
}