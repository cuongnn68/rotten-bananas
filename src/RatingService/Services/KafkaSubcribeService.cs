using System.Text.Json;
using AutoMapper;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using RatingService.Configuration;
using RatingService.Dtos;
using RatingService.Models;
using RatingService.Util;

namespace RatingService.Service;

public class KafkaSubcribeService : BackgroundService {
    private readonly IConsumer<string, string> consumer;
    private readonly AppDbContext dbContext;
    private readonly IMapper mapper;
    // private readonly IAdminClient adminClient;

    public KafkaSubcribeService(IConfiguration config, IServiceProvider serviceProvider) {
        Console.WriteLine(" ==> creating kafka subcriber service ...");
        var scopeServiceProvider = serviceProvider.CreateScope().ServiceProvider;
        this.dbContext = scopeServiceProvider.GetService<AppDbContext>();
        this.mapper = scopeServiceProvider.GetService<IMapper>();

        // var adminClientConfig = new AdminClientConfig() {
        //     BootstrapServers = config["Kafka:BootstrapServer"],
        // };
        var consumerConfig = new ConsumerConfig() {
            BootstrapServers = config["Kafka:BootstrapServer"],
            GroupId = config["Kafka:GroupId"],
            AllowAutoCreateTopics = true,
            
        };
        // using var adminClient = new AdminClientBuilder(adminClientConfig).Build();
        // adminClient.CreateTopicsAsync(new[] {
        //     new TopicSpecification() {Name = "movie-new", NumPartitions = 10, ReplicationFactor = 1},
        // });
        this.consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        consumer.Subscribe(new[] {Const.NEW_MOVIE_TOPIC, Const.NEW_USER_TOPIC});
        if(consumer.Handle.IsInvalid) {}; // TODO: ?

        Console.WriteLine(" ==> created kafka subcriber service");
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken) {
        await Task.Yield(); // TODO: ???
        while(! stoppingToken.IsCancellationRequested) {
            var result = consumer.Consume(stoppingToken);
            Console.WriteLine(result.Value);
            if(result.Topic == Const.NEW_MOVIE_TOPIC) {
                var newMovie = JsonSerializer.Deserialize<NewMovieAS>(result.Message.Value);
                dbContext.Movies.Add(mapper.Map<Movie>(newMovie));
                dbContext.SaveChanges();
                Console.WriteLine($" ==> new movie: {result.Message.Value}");
            }
            if(result.Topic == Const.NEW_USER_TOPIC) {
                var newUser = JsonSerializer.Deserialize<User>(result.Message.Value);
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();    
                Console.WriteLine($" ==> new uesr: {result.Message.Value}");
            }
            
        }
    }

    public override void Dispose() {
        consumer.Dispose();
        base.Dispose();
    }
}