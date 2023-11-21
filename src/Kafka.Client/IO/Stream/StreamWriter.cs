using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Stream
{
    internal sealed class StreamWriter<TKey, TValue> :
        IStreamWriter<TKey, TValue>
    {
        private readonly IOutputStream _stream;
        private readonly TopicName _topic;
        private readonly ISerializer<TKey> _keySerializer;
        private readonly ISerializer<TValue> _valueSerializer;
        private readonly IPartitioner _partitioner;
        private readonly ILogger _logger;

        private ProducerTopicMetadata _topicMetadata = ProducerTopicMetadata.Empty;

        public StreamWriter(
            TopicName topic,
            IOutputStream stream,
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer,
            IPartitioner partitioner,
            ILogger logger
        )
        {
            _topic = topic;
            _stream = stream;
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
            _partitioner = partitioner;
            _logger = logger;
        }

        TopicName IStreamWriter<TKey, TValue>.Topic => _topic;

        async Task<ProduceResult> IStreamWriter<TKey, TValue>.Write(
            TKey? key,
            TValue? value,
            CancellationToken cancellationToken
        ) =>
            await Write(
                key,
                value,
                Timestamp.None,
                ImmutableArray<RecordHeader>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<ProduceResult> IStreamWriter<TKey, TValue>.Write(
            TKey? key,
            TValue? value,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        ) =>
            await Write(
                key,
                value,
                Timestamp.None,
                headers,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<ProduceResult> IStreamWriter<TKey, TValue>.Write(
            TKey? key,
            TValue? value,
            Timestamp timestamp,
            CancellationToken cancellationToken
        ) =>
            await Write(
                key,
                value,
                timestamp,
                ImmutableArray<RecordHeader>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<ProduceResult> IStreamWriter<TKey, TValue>.Write(
            TKey? key,
            TValue? value,
            Timestamp timestamp,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        ) =>
            await Write(
                key,
                value,
                timestamp,
                headers,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async Task<ProduceResult> Write(
            TKey? key,
            TValue? value,
            Timestamp timestamp,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        )
        {
            var record = await CreateRecord(
                key,
                value,
                timestamp,
                headers,
                cancellationToken
            ).ConfigureAwait(false);
            return await _stream.Write(
                record,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async Task<ProduceRecord> CreateRecord(
            TKey? key,
            TValue? value,
            Timestamp timestamp,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        )
        {
            var keyBytes = _keySerializer.Write(key);
            var valueBytes = _valueSerializer.Write(value);
            var topicMetadata = await GetTopicMetadata(
                cancellationToken
            ).ConfigureAwait(false);
            var partition = await _partitioner.SelectPartition(
                _topic,
                topicMetadata.PartitionMetadata.Length,
                keyBytes,
                cancellationToken
            ).ConfigureAwait(false);
            if (timestamp == Timestamp.None)
                timestamp = Timestamp.Now();
            return new(
                new(_topic, partition),
                timestamp,
                keyBytes,
                valueBytes,
                headers,
                Attributes.None
            );
        }

        async Task<ProducerTopicMetadata> GetTopicMetadata(
            CancellationToken cancellationToken
        )
        {
            if (_topicMetadata.ExpireTime > DateTimeOffset.UtcNow)
                return _topicMetadata;
            _topicMetadata = await _stream.MetadataForTopic(
                _topic, cancellationToken
            ).ConfigureAwait(false);
            return _topicMetadata;
        }

        void IDisposable.Dispose() { }
    }
}
