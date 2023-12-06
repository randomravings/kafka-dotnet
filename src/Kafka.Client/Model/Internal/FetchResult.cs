using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model.Internal
{
    public sealed record FetchResult(
        IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>> Records,
        TaskCompletionSource Callback
    )
    {
        public static FetchResult Empty { get; } = new(
            ImmutableList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>.Empty,
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
