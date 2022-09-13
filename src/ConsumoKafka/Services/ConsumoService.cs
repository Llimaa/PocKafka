using Confluent.Kafka;

namespace ConsumoKafka.Services;

public class ConsumoService : IConsumoService
{
    private readonly ILogger<ConsumoService> logger;
    public ConsumoService(ILogger<ConsumoService> logger)
    {
        this.logger = logger;
    }
    public Task ConsumerBuilder(string bootstrapService, string nomeTopic)
    {
        logger.LogInformation("Testando o consumo da mensagem com kafka");

        logger.LogInformation($"BootstrapServers: {bootstrapService}");
        logger.LogInformation($"nomeTopic: {nomeTopic}");

        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapService,
            GroupId = $"{nomeTopic}-group-0",
            AutoOffsetReset = AutoOffsetReset.Earliest,
        };


        var cancellationTokenSource = new CancellationTokenSource();

        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true;
            cancellationTokenSource.Cancel();
        };

        try
        {
            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe(nomeTopic);

            try
            {
                while (true)
                {
                    var cr = consumer.Consume(cancellationTokenSource.Token);
                    logger.LogInformation($"Mensagem lida: ", cr.Message.Value);
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
                logger.LogWarning("Cancelada a execução do Consummer...");
            }

        }
        catch (Exception ex)
        {
            logger.LogError($"Exceção: {ex.GetType().FullName} | Mensagem: {ex.Message}");
        }
        return Task.CompletedTask;
    }
}