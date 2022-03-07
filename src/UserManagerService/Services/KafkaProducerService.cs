using System.Text.Json;
using Confluent.Kafka;
using UserManagerService.Dtos;

namespace UserManagerService.Services;

public class KafkaProducerService {
    private readonly string kafkaBootstrapServers;
    private const string NEW_USER_TOPIC = "new-user";

    public KafkaProducerService(IConfiguration config)
    {
        this.kafkaBootstrapServers = config["Kafka:BootstrapServer"];
    }
    public async Task AddNewMovieAsync(NewUserAS newUser) {
        var producerConfig = new ProducerConfig() {
            BootstrapServers = kafkaBootstrapServers,
        };
        using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        var message = JsonSerializer.Serialize(newUser);
        await producer.ProduceAsync(
            NEW_USER_TOPIC,
            new Message<Null, string>(){
                Value = message,
            }
        );
        Console.WriteLine($"send: {message}");
    }
}