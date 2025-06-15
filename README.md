# mcp-dev-tools
Ferramentas e utilitários para automação e integração de fluxos de trabalho com o protocolo MCP

## Ferramentas MCP Tool

O projeto inclui ferramentas para publicação de mensagens em sistemas de mensageria, integradas ao protocolo MCP, facilitando automação e testes em ambientes de desenvolvimento.

### KafkaPublisherTool

- **Descrição:** Publica mensagens em um tópico Kafka.
- **Uso:**
  - Parâmetros:
    - `broker`: endereço do broker Kafka (ex: `localhost:9092`)
    - `topic`: nome do tópico de destino
    - `message`: mensagem a ser publicada
  - Exemplo de chamada:
    ```
    KafkaPublisherTool.PublishMessage("localhost:9092", "meu-topico", "mensagem de teste")
    ```
- **Observações:** Exibe no console o offset da mensagem publicada ou o erro ocorrido.

### RabbitMqPublisherTool

- **Descrição:** Publica mensagens em uma fila RabbitMQ.
- **Uso:**
  - Parâmetros:
    - `host`: endereço do servidor RabbitMQ (ex: `localhost`)
    - `queue`: nome da fila de destino
    - `message`: mensagem a ser publicada
  - Exemplo de chamada:
    ```
    RabbitMqPublisherTool.PublishMessageAsync("localhost", "minha-fila", "mensagem de teste")
    ```
- **Observações:** Exibe no console confirmação de publicação ou o erro ocorrido.


## Containers de Desenvolvimento para Mensageria e Streaming de teste

O projeto inclui um ambiente Docker Compose para facilitar o uso de serviços de mensageria e streaming:

### Serviços Disponíveis

- **RabbitMQ**
  - Painel de administração: http://localhost:15672 (usuário: `admin`, senha: `admin`)
  - Porta de conexão: `5672`
- **Kafka**
  - Porta de conexão: `9092` (interno), `29092` (externo)
  - Depende do Zookeeper
- **Kafdrop**
  - Interface web para administração do Kafka: http://localhost:9000
- **Zookeeper**
  - Porta: `2181`

### Como usar

1. Acesse a pasta `containers`:
   ```sh
   cd containers
   ```
2. Suba os serviços:
   ```sh
   docker-compose up -d
   ```
3. Acesse as interfaces web conforme as portas acima.

Para parar e remover os containers:
```sh
docker-compose down
```

> Certifique-se de ter o Docker e o Docker Compose instalados em sua máquina.

