using System.Text.Json;
using AutoMapper;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using RatingService.Configuration;
using RatingService.Dtos;
using RatingService.Models;

namespace RatingService.Service;

public class KafkaSubcribeService : BackgroundService {
    private readonly IConsumer<string, string> consumer;
    private readonly AppDbContext dbContext;
    private readonly IMapper mapper;
    private readonly IAdminClient adminClient;

    public KafkaSubcribeService(IConfiguration config, IServiceProvider serviceProvider) {
        Console.WriteLine("--- create background service ---");
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
        consumer.Subscribe("new-movie");
        if(consumer.Handle.IsInvalid) {};

        Console.WriteLine("--- created background service ---");
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken) {
        await Task.Yield(); // TODO: ???
        while(! stoppingToken.IsCancellationRequested) {
            var result = consumer.Consume(stoppingToken);
            var newMovie = JsonSerializer.Deserialize<NewMovieAS>(result.Message.Value);
            Console.WriteLine(result.Value);
            dbContext.Movies.Add(mapper.Map<Movie>(newMovie));
            dbContext.SaveChanges();
            
        }
    }

    public override void Dispose() {
        consumer.Dispose();
        base.Dispose();
    }
}