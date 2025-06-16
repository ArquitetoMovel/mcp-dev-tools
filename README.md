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
  - Exemplo de invocação da ferramenta no github copilotchat:
    ```
        envie a mensagem ```json { “message”: “publicando mensagens no kafka” } ``` para o broker `localhost:9092` no tópico `Teste`
    ```
- **Observações:** Exibe no console o offset da mensagem publicada ou o erro ocorrido.

### RabbitMqPublisherTool

- **Descrição:** Publica mensagens em uma fila RabbitMQ.
- **Uso:**
  - Parâmetros:
    - `host`: endereço do servidor RabbitMQ (ex: `localhost:5672`)
    - `queue`: nome da fila de destino
    - `message`: mensagem a ser publicada
  - Exemplo de invocação da ferramenta no github copilotchat:
    ```
        envie a mensagem ```json {"message": "mensagem de teste"}``` para a fila `minha-fila` no RabbitMQ em `localhost:5672` com o usuário `admin` e senha `admin`    
    ```
- **Observações:** Exibe no console confirmação de publicação ou o erro ocorrido.


## Adicionando Ferramentas ao VS Code
Para adicionar as ferramentas de publicação de mensagens ao Visual Studio Code, siga os passos abaixo:
1. Abra o Visual Studio Code.
2. Acesse a aba de extensões (ícone de quadrado no menu lateral).
3. Pesquise por "MCP Tool" ou "Ferramentas MCP".
4. Instale a extensão correspondente.
    ```json
       "servers": {
        "Developer Tools": {
            "type": "stdio",
            "command": "dotnet",
            "args": ["src/McpServer.DevTools.Stdio/bin/Debug/net9.0/McpServer.DevTools.Stdio.dll"]
        }
    }
    ```
5. Após a instalação, as ferramentas estarão disponíveis para uso diretamente no editor.


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

