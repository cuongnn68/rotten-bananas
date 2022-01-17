using Microsoft.EntityFrameworkCore;
using RatingService.Configuration;
using RatingService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("InMemoryRating"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if(app.Environment.IsDevelopment()) SeedData();
if(app.Environment.IsProduction()) DoMigration();

app.Run();

void SeedData() {
    Console.WriteLine("--> Seeding");
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
    var movies = new [] {
        new Movie{Id = 1, Name = "Tranformer", },
        new Movie{Id = 2, Name = "Dune", },
        // new Movie{Id = 3, Name = "Spider Man", },
    };
    var users = new [] {
        new User{Id = 1, Username = "testuser1"},
        new User{Id = 2, Username = "user2"},
    };
    var ratings = new [] {
        new Rating{Id = 1, UserId = 1, IdMovie = 1, Time = DateTime.Now, Review = "boring", Score = 3},
        new Rating{Id = 2, UserId = 1, IdMovie = 2, Time = DateTime.Now, Review = "ok", Score = 5},
        new Rating{Id = 3, UserId = 2, IdMovie = 2, Time = DateTime.Now, Review = "good", Score = 8},
    };
    if(!dbContext.Movies.Any()) dbContext.Movies.AddRange(movies);
    if(!dbContext.Users.Any()) dbContext.Users.AddRange(users);
    if(!dbContext.Ratings.Any()) dbContext.Ratings.AddRange(ratings);
    dbContext.SaveChanges();
    Console.WriteLine("--> Seed");
}

void DoMigration() {

}