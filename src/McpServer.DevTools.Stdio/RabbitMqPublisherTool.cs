using ModelContextProtocol.Server;
using System.ComponentModel;
using RabbitMQ.Client;

namespace McpServer.DevTools.Stdio;

[McpServerToolType]
public class RabbitMqPublisherTool
{
  [McpServerTool, Description("Publishes a message to a RabbitMQ queue")]
  public static async Task PublishMessageAsync(string host, string queue, string message)
  {
    if (string.IsNullOrEmpty(host))
    {
      throw new ArgumentException("Host cannot be null or empty", nameof(host));
    }
    if (string.IsNullOrEmpty(queue))
    {
      throw new ArgumentException("Queue cannot be null or empty", nameof(queue));
    }
    if (string.IsNullOrEmpty(message))
    {
      throw new ArgumentException("Message cannot be null or empty", nameof(message));
    }

    var factory = new ConnectionFactory() { HostName = host };
    try
    {
      await using var connection = await factory.CreateConnectionAsync();
      var channel = await connection.CreateChannelAsync();
      await channel.QueueDeclareAsync(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
      var body = System.Text.Encoding.UTF8.GetBytes(message).AsMemory();
      var props = new BasicProperties();
      await channel.BasicPublishAsync("", queue, false, props, body);
      await channel.CloseAsync();
      await channel.DisposeAsync();
      Console.WriteLine($"Mensagem publicada com sucesso na fila '{queue}'");
    }
    catch (Exception ex)
    {
      Console.Error.WriteLine($"Erro ao publicar mensagem no RabbitMQ: {ex.Message}");
      throw;
    }
  }
}