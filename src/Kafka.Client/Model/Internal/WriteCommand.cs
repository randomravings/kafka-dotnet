using Kafka.Common.Model;

namespace Kafka.Client.Model.Internal
{
    internal sealed record WriteCommand(
        WriteRecord Record,
        Attributes Attributes,
        TaskCompletionSource<WriteResult> Callback
    );
}
