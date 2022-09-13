namespace ConsumoKafka.Services;

public interface IConsumoService
{
    public Task ConsumerBuilder(string bootstrapService, string nomeTopic);
}