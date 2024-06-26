﻿using Kafka.Client;
using Kafka.Client.Logging;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Write
{
    internal sealed class StreamWriter<TKey, TValue>(
        IWriteStream stream,
        ISerializer<TKey> keySerializer,
        ISerializer<TValue> valueSerializer,
        IPartitioner partitioner,
        ILogger logger
    ) :
        IStreamWriter<TKey, TValue>,
        IDisposable
    {
        private readonly IWriteStream _stream = stream;
        private readonly ISerializer<TKey> _keySerializer = keySerializer;
        private readonly ISerializer<TValue> _valueSerializer = valueSerializer;
        private readonly IPartitioner _partitioner = partitioner;
        private readonly ILogger _logger = logger;

        async Task<WriteResult> IStreamWriter<TKey, TValue>.Write(
            TopicName topic,
            TKey key,
            TValue value,
            CancellationToken cancellationToken
        ) =>
            await Write(
                topic,
                key,
                value,
                Timestamp.None,
                ImmutableArray<RecordHeader>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<WriteResult> IStreamWriter<TKey, TValue>.Write(
            TopicName topic,
            TKey key,
            TValue value,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        ) =>
            await Write(
                topic,
                key,
                value,
                Timestamp.None,
                headers,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<WriteResult> IStreamWriter<TKey, TValue>.Write(
            TopicName topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            CancellationToken cancellationToken
        ) =>
            await Write(
                topic,
                key,
                value,
                timestamp,
                ImmutableArray<RecordHeader>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<WriteResult> IStreamWriter<TKey, TValue>.Write(
            TopicName topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        ) =>
            await Write(
                topic,
                key,
                value,
                timestamp,
                headers,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async Task<WriteResult> Write(
            TopicName topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            IReadOnlyList<RecordHeader> headers,
            CancellationToken cancellationToken
        )
        {
            var keyBytes = _keySerializer.Write(key);
            var valueBytes = _valueSerializer.Write(value);

            var topicMetadata = await _stream.MetadataForTopic(
                topic, cancellationToken
            ).ConfigureAwait(false);

            var partition = _partitioner.SelectPartition(
                topicMetadata.PartitionMetadata.Length,
                keyBytes
            );
            _logger.PartitionSelection(partition);

            if (timestamp == Timestamp.None)
                timestamp = Timestamp.Now();

            var outputRecord = new WriteRecord(
                new(topic, partition),
                timestamp,
                keyBytes,
                valueBytes,
                headers
            );

            return await _stream.Write(
                outputRecord,
                cancellationToken
            ).ConfigureAwait(false);
        }

        void IDisposable.Dispose() { }
    }
}
