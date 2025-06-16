using ModelContextProtocol.Server;
using System.ComponentModel;
using RabbitMQ.Client;

namespace McpServer.DevTools.Stdio;

[McpServerToolType]
public class RabbitMqPublisherTool
{
  [McpServerTool, Description("Publishes a message to a RabbitMQ queue")]
  public static async Task<string> PublishMessageToQueue(string host, string queue, string message, string? userName = null, string? password = null)
  {
    try
    {
      ArgumentException.ThrowIfNullOrEmpty(host, nameof(host));
      ArgumentException.ThrowIfNullOrEmpty(queue, nameof(queue));
      ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));

      var factory = new ConnectionFactory() { HostName = host };
      if (!string.IsNullOrEmpty(userName))
        factory.UserName = userName;

      if (!string.IsNullOrEmpty(password))
        factory.Password = password;

      await using var connection = await factory.CreateConnectionAsync();
      var channel = await connection.CreateChannelAsync();
      await channel.QueueDeclareAsync(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
      var body = System.Text.Encoding.UTF8.GetBytes(message).AsMemory();
      var props = new BasicProperties();
      await channel.BasicPublishAsync("", queue, false, props, body);
      await channel.CloseAsync();
      await channel.DisposeAsync();
      Console.WriteLine($"Mensagem publicada com sucesso na fila '{queue}'");
      return $"Mensagem publicada com sucesso na fila '{queue}'";
    }
    catch (Exception ex)
    {
      Console.Error.WriteLine($"Erro ao publicar mensagem no RabbitMQ: {ex.Message}");
      return $"Erro ao publicar mensagem no RabbitMQ: {ex.Message} \n\t {ex.StackTrace}";
    }
  }
}