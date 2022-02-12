using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.EntityFrameworkCore;
using RatingService.Configuration;
using RatingService.Models;
using RatingService.Service;
using RatingService.Util;

var builder = WebApplication.CreateBuilder(args);

// create topic admin client
CreateTopicKafka();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("InMemoryRating"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHostedService<KafkaSubcribeService>(
    (serviceProvider) => new KafkaSubcribeService(builder.Configuration, serviceProvider));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SeedData();
DoMigration();

app.Run();

void CreateTopicKafka() {
    Console.WriteLine(" ==> Creating topic ...");
    var adminClientConfig = new AdminClientConfig() {
        BootstrapServers = builder.Configuration["Kafka:BootstrapServer"],
    };
    using var adminClient = new AdminClientBuilder(adminClientConfig).Build();

    var task = adminClient.CreateTopicsAsync(new[] {
        new TopicSpecification() {
            Name = Const.NEW_USER_TOPIC, 
            NumPartitions = 10, 
            ReplicationFactor = 1
        },
        new TopicSpecification() {
            Name = Const.NEW_MOVIE_TOPIC,
            NumPartitions = 10, 
            ReplicationFactor = 1
        }
    });
    try{
        task.Wait();
    } catch (Exception e) {
        Console.WriteLine(e.StackTrace);
    }
    Console.WriteLine($"create topic status: {task.Status}");

    Console.WriteLine(" ==> Created topic");
}

void SeedData() {
    Console.WriteLine("==> Seeding ...");
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
    var movies = new [] {
        new Movie{Id = 1, Name = "Tranformer", },
        new Movie{Id = 2, Name = "Dune", },
        new Movie{Id = 3, Name = "Spider Man", },
    };
    var users = new [] {
        new User{Username = "testuser1"},
        new User{Username = "testuser2"},
        new User{Username = "testuser3"},
    };
    var ratings = new [] {
        new Rating{Id = 1, Username = "testuser1", IdMovie = 1, Time = DateTime.Now, Review = "boring", Score = 3},
        new Rating{Id = 2, Username = "testuser2", IdMovie = 2, Time = DateTime.Now, Review = "ok", Score = 5},
        new Rating{Id = 3, Username = "testuser3", IdMovie = 2, Time = DateTime.Now, Review = "good", Score = 8},
    };
    if(!dbContext.Movies.Any()) dbContext.Movies.AddRange(movies);
    if(!dbContext.Users.Any()) dbContext.Users.AddRange(users);
    if(!dbContext.Ratings.Any()) dbContext.Ratings.AddRange(ratings);
    dbContext.SaveChanges();
    Console.WriteLine("==> Seed");
}

void DoMigration() {

}