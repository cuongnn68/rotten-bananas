using Microsoft.EntityFrameworkCore;
using MovieService.Models;

namespace MovieService.Configuration;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) {
    }

    public DbSet<Movie> Movies { get; set; }
}