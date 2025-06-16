using Confluent.Kafka;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace McpServer.DevTools.Stdio;

[McpServerToolType]
public class KafkaPublisherTool
{
    [McpServerTool, Description("Publishes a message to a Kafka topic")]
    public static void PublishMessageToTopic(string broker, string topic, string message)
    {
        if (string.IsNullOrEmpty(broker))
        {
            throw new ArgumentException("Broker cannot be null or empty", nameof(broker));
        }
        if (string.IsNullOrEmpty(topic))
        {
            throw new ArgumentException("Topic cannot be null or empty", nameof(topic));
        }
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException("Message cannot be null or empty", nameof(message));
        }
        // Implement Kafka message publishing logic here
        var config = new ProducerConfig { BootstrapServers = broker };
        using var producer = new ProducerBuilder<Null, string>(config).Build();
        try
        {
            var result = producer.ProduceAsync(topic, new Message<Null, string> { Value = message }).GetAwaiter().GetResult();
            Console.WriteLine($"Mensagem publicada com sucesso no tópico '{topic}' (offset: {result.Offset})");
        }
        catch (ProduceException<Null, string> ex)
        {
            Console.Error.WriteLine($"Erro ao publicar mensagem no Kafka: {ex.Error.Reason}");
            throw;
        }
    }
}