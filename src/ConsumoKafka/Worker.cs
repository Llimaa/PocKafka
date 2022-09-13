using ConsumoKafka.Services;

namespace ConsumoKafka;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly IConsumoService consumoService;

    public Worker(ILogger<Worker> logger, IConsumoService consumoService)
    {
        this.logger = logger;
        this.consumoService = consumoService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await consumoService.ConsumerBuilder("localhost:9092", "topic-test");
        }
    }
}
