using Kafka.Client.Model;
using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IStreamWriter<TKey, TValue> :
        IDisposable
    {
        Task<ProduceResult> Write(
            TopicName Topic,
            TKey? key,
            TValue? value,
            CancellationToken cancellationToken
        );
        Task<ProduceResult> Write(
            TopicName Topic,
            TKey? key,
            TValue? value,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        );
        Task<ProduceResult> Write(
            TopicName Topic,
            TKey? key,
            TValue? value,
            Timestamp timestamp,
            CancellationToken cancellationToken
        );
        Task<ProduceResult> Write(
            TopicName Topic,
            TKey? key,
            TValue? value,
            Timestamp timestamp,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        );
    }
}
