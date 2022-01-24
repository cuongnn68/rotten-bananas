using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserManagerService.Dtos;

public class NewUserRQ {
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }

    [JsonIgnore]
    public byte[] Salt { get; set; }
}