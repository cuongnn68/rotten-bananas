using System.Text.Json;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using MovieService.Dtos;
using MovieService.Models;

namespace MovieService.Services;

public class KafkaPublisherService : IMessageBusService{
    private readonly IConfiguration config;
    private readonly string bootstrapServer;

    private const string NEW_MOVIE_TOPIC = "new-movie";

    public KafkaPublisherService(IConfiguration config) {
        this.config = config;
        this.bootstrapServer = config["Kafka:BootstrapServer"];

        // CreateTopic();
    }

    async public Task AddNewMovieAsync(NewMovieAS newMovie) {
        var producerConfig = new ProducerConfig() {
            BootstrapServers = bootstrapServer,
        };
        using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        await producer.ProduceAsync(
            NEW_MOVIE_TOPIC, 
            new Message<Null, string>() {Value = JsonSerializer.Serialize(newMovie),});
        Console.WriteLine("sending: " + JsonSerializer.Serialize(newMovie));
    }

    private void CreateTopic() {
        var adminClientConfig = new AdminClientConfig(){
            BootstrapServers = bootstrapServer,
        };
        using var adminClient = new AdminClientBuilder(adminClientConfig).Build();
        adminClient.CreateTopicsAsync(new TopicSpecification[] {
            new TopicSpecification() {Name = NEW_MOVIE_TOPIC, NumPartitions = 10, }
        });
    }
}