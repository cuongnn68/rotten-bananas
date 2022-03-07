using Microsoft.EntityFrameworkCore;
using UserManagerService.Models;

namespace UserManagerService.Configurations;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) {
    }

    public DbSet<User> Users { get; set; }
}