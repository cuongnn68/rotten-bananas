using Microsoft.EntityFrameworkCore;
using RatingService.Models;

namespace RatingService.Configuration;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}