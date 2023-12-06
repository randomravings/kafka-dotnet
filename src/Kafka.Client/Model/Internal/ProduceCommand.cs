namespace Kafka.Client.Model.Internal
{
    internal sealed record ProduceCommand(
        WriteRecord Record,
        TaskCompletionSource<ProduceResult> Callback
    );
}
