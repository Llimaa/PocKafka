using Confluent.Kafka;
using Serilog;

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Testando envio de mensagem com Kafka");

if (args.Length < 3)
{
    logger.Error(
        "Informe ao menos 3 parâmetros: " +
        "no primeiro o IP/porta para testes com o Kafka, " +
        "no segundo o Topic que receberá a mensagem, " +
        "já no terceito em diante as mensagens a serem " +
        "enviadas a um Topic no Kafka..."
    );

    return;
}

string bootstrapServers = args[0];
string nomeTopic = args[1];

logger.Information($"BootstrapServers = {bootstrapServers}");
logger.Information($"NomeTopic = {nomeTopic}");

try
{
    var config = new ProducerConfig
    {
        BootstrapServers = bootstrapServers,
        
    };

    using var producer = new ProducerBuilder<Null, string>(config).Build();
    var topicPart = new TopicPartition("topic", new Partition(3));
    for (var i = 2; i < args.Length; i++)
    {
        var result = await producer.ProduceAsync(
            nomeTopic, new Message<Null, string> { Value = args[i] }
        );

        logger.Information(
            $"Mensagem: {args[i]} |" +
            $"Status: {result.ToString()}"
        );
    }

    logger.Information("Mensagem enviada com sucesso!");
}
catch (Exception ex)
{
    logger.Error($"Exceção: {ex.GetType().FullName} |  Messagem: {ex.Message}");
}