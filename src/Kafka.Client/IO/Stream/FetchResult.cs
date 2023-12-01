using Kafka.Client.Model;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Stream
{
    public sealed record FetchResult(
        IReadOnlyList<InputRecord> Records,
        TaskCompletionSource Callback
    )
    {
        public static FetchResult Empty { get; } = new(
            ImmutableList<InputRecord>.Empty,
            EmptyTaskCompletionSource()
        );
        private static TaskCompletionSource EmptyTaskCompletionSource()
        {
            var task = new TaskCompletionSource();
            task.SetCanceled();
            return task;
        }
    }
}
