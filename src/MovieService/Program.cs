using Microsoft.EntityFrameworkCore;
using MovieService.Configuration;
using AutoMapper;
using MovieService.Models;
using MovieService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("InMemoryMovie"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMessageBusService, KafkaPublisherService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment()) SeedData();
if (app.Environment.IsProduction()) DoMigration();

app.Run();


void SeedData() {
    Console.WriteLine("--- Seeding ---");
    using var serviceScope = app.Services.CreateScope();
    var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    if (dbContext.Movies.Any()) return;
    dbContext.Movies.AddRange(new[] {
        new Movie{Name = "Tranformer", Active = true, DurationByMin = 69, ReleaseDate = DateTime.ParseExact("22/11/2021", "dd/MM/yyyy", null)},
        new Movie{Name = "Dune", Active = true, DurationByMin = 96, ReleaseDate = DateTime.ParseExact("30/01/2021", "dd/MM/yyyy", null)},
        new Movie{Name = "Spider Man", Active = true, DurationByMin = 240, ReleaseDate = DateTime.ParseExact("22/02/2202", "dd/MM/yyyy", null)},
    });
    dbContext.SaveChanges();
    Console.WriteLine("--- Seed Data ---");
}

void DoMigration() {

}