namespace Kafka.Client.Clients.Producer.Model
{
    public sealed record ProduceRecordError(
        int Index,
        string ErrorMessage
    );
}
