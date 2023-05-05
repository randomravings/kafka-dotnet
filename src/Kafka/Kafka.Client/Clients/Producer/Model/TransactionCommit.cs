using Kafka.Client.Commands;

namespace Kafka.Client.Clients.Producer.Model
{
    internal sealed record TransactionCommit() :
        Command<bool>(
            new TaskCompletionSource<bool>(
                TaskCreationOptions.RunContinuationsAsynchronously
            )
        )
    ;
}
