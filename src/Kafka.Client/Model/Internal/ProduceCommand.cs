namespace Kafka.Client.Model.Internal
{
    internal sealed record ProduceCommand(
        OutputRecord Record,
        TaskCompletionSource<ProduceResult> Callback
    );
}
