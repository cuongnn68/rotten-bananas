using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagerService.Models;

public class User {
    [Key]
    public string Username { get; set; }

    [Required]
    public string HashedPassword { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public byte[] Salt { get; set; }

    public string Admin { get; set; }

}