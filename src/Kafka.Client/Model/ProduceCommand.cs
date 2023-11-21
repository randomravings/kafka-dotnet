namespace Kafka.Client.Model
{
    internal sealed record ProduceCommand(
        ProduceRecord Record,
        TaskCompletionSource<ProduceResult> Callback
    );
}
