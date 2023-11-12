namespace Kafka.Client.Model
{
    internal readonly record struct ProduceCommand(
        ProduceRecord Record,
        TaskCompletionSource<ProduceResult> Callback
    );
}
