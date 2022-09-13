using ConsumoKafka;
using ConsumoKafka.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IConsumoService, ConsumoService>();
    })
    .Build();

host.Run();
