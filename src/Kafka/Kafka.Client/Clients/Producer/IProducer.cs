using Kafka.Common.Records;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal interface IProducer<TKey, TValue> :
        IClient
    {
        ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            CancellationToken cancellationToken = default
        );

        ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            CancellationToken cancellationToken = default
        );

        ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken = default
        );

        ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken = default
        );

        ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            ProducerRecord<TKey, TValue> record,
            CancellationToken cancellationToken = default
        );
    }
}
