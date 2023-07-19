using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Records;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal abstract class ProducerChannel :
        IProducerProtocol
    {
        protected readonly long _producerId;
        protected readonly short _producerEpoch;
        protected readonly short _acks;
        protected readonly string? _transactionalId;
        protected readonly int _requestTimeoutMs;
        protected readonly ILogger _logger;
        protected readonly IProducerConnection _protocol;
        protected readonly ProducerConfig _config;
        protected readonly SortedList<TopicPartition, int> _topicPartitionStates = new(TopicPartitionCompare.Instance);

        public ProducerChannel(
            long producerId,
            short producerEpoch,
            short acks,
            string transactionalId,
            int requestTimeoutMs,
            IProducerConnection protocol,
            ProducerConfig config,
            ILogger logger
        )
        {
            _producerId = producerId;
            _producerEpoch = producerEpoch;
            _acks = acks;
            _transactionalId = transactionalId;
            _requestTimeoutMs = requestTimeoutMs;
            _protocol = protocol;
            _config = config;
            _logger = logger;
        }

        async ValueTask IProducerProtocol.Send(SendCommand sendCommand, CancellationToken cancellationToken) =>
            await Sending(sendCommand, cancellationToken).ConfigureAwait(false)
        ;

        protected static void FinalizeSend(
            SendCommand sendCommand,
            Offset offset,
            Error error,
            string recordError
        )
        {
            sendCommand.TaskCompletionSource.SetResult(
                new ProduceResult(
                    new TopicPartitionOffset(
                        sendCommand.TopicPartition,
                        offset
                    ),
                    sendCommand.Timestamp,
                    error,
                    recordError
                )
            );
        }

        protected IRecords BuildRecords(
            int baseSequence,
            Attributes attributes,
            IEnumerable<SendCommand> sendCommands
        )
        {
            var minTimestamp = long.MaxValue;
            var maxTimestamp = long.MinValue;
            foreach (var x in sendCommands)
            {
                minTimestamp = Math.Min(minTimestamp, x.Timestamp.TimestampMs);
                maxTimestamp = Math.Max(maxTimestamp, x.Timestamp.TimestampMs);
            }
            (var batchSize, var recordList) = BuildRecordArray(minTimestamp, sendCommands);
            return new RecordBatch(
                BaseOffset: 0,
                BatchLength: batchSize,
                PartitionLeaderEpoch: 0,
                Magic: 2,
                Crc: 0, // Crc computation deferred to encoder.
                attributes,
                LastOffsetDelta: recordList.Length - 1,
                BaseTimestamp: minTimestamp,
                MaxTimestamp: maxTimestamp,
                ProducerId: _producerId,
                ProducerEpoch: _producerEpoch,
                BaseSequence: baseSequence,
                recordList
            );
        }

        protected IRecords BuildRecords(
            int baseSequence,
            Attributes attributes,
            SendCommand sendCommand
        )
        {
            (var batchSize, var recordList) = BuildRecordArray(sendCommand);
            return new RecordBatch(
                BaseOffset: 0,
                BatchLength: batchSize,
                PartitionLeaderEpoch: 0,
                Magic: 2,
                Crc: 0, // Crc computation deferred to encoder.
                attributes,
                LastOffsetDelta: recordList.Length - 1,
                BaseTimestamp: sendCommand.Timestamp.TimestampMs,
                MaxTimestamp: sendCommand.Timestamp.TimestampMs,
                ProducerId: _producerId,
                ProducerEpoch: _producerEpoch,
                BaseSequence: baseSequence,
                recordList
            );
        }

        private static (int BatchSize, ImmutableArray<IRecord> Records) BuildRecordArray(
            long minTimestampMs,
            IEnumerable<SendCommand> produceCommands
        )
        {
            var offsetDelta = 0;
            var batchSize = 0;
            var recordArrayBuilder = ImmutableArray.CreateBuilder<IRecord>();
            foreach (var produceCommand in produceCommands)
            {
                var timestampDelta = produceCommand.Timestamp.TimestampMs - minTimestampMs;
                var record = CreateRecord(
                    timestampDelta,
                    offsetDelta,
                    produceCommand.Key,
                    produceCommand.Value,
                    produceCommand.Headers
                );
                recordArrayBuilder.Add(record);
                offsetDelta++;
                batchSize += record.Length;
                batchSize += BinaryEncoder.SizeOfVarInt32(record.Length);
            }
            return (batchSize, recordArrayBuilder.ToImmutable());
        }

        private static (int BatchSize, ImmutableArray<IRecord> Records) BuildRecordArray(
            SendCommand sendCommand
        )
        {
            var record = CreateRecord(
                0,
                0,
                sendCommand.Key,
                sendCommand.Value,
                sendCommand.Headers
            );
            var batchSize = record.Length;
            batchSize += BinaryEncoder.SizeOfVarInt32(batchSize);
            return (batchSize, ImmutableArray.Create(record));
        }

        protected static IRecord CreateRecord(
            long timestampDelta,
            int offsetDelta,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value,
            ImmutableArray<RecordHeader> headers
        )
        {
            var recordSize = ComputeRecordSize(
                timestampDelta,
                offsetDelta,
                key,
                value,
                headers
            );
            return new Record(
                Length: recordSize,
                Attributes: Attributes.None,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers
            );
        }

        /// <summary>
        /// Used to estimate record size.
        /// This is a conservative estimate and the actual size is likely to be lower due to the zigzag encoded integer values.
        /// Timestamp delta and offset delta are not known at this time.
        /// </summary>
        /// <param name="produceCallback"></param>
        /// <returns></returns>
        protected static int EstimateRecordSize(SendCommand sendCommand) =>
            (sendCommand.Key?.Length ?? 0) +
            (sendCommand.Key?.Length ?? 0) +
            ComputeHeadersSize(sendCommand.Headers) +
            40 // Add some overhead to accout for overhead varint stuff.
        ;

        /// <summary>
        /// Used to compute the precise record size in bytes.
        /// </summary>
        /// <param name="timestampDelta"></param>
        /// <param name="offsetDelta"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        protected static int ComputeRecordSize(
            long timestampDelta,
            int offsetDelta,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value,
            ImmutableArray<RecordHeader> headers
        ) =>
            BinaryEncoder.SizeOfVarInt64(timestampDelta) +
            BinaryEncoder.SizeOfVarInt32(offsetDelta) +
            1 + // Attributes
            BinaryEncoder.SizeOfVarInt32(key?.Length ?? 0) +
            (key?.Length ?? 0) +
            BinaryEncoder.SizeOfVarInt32(value?.Length ?? 0) +
            (value?.Length ?? 0) +
            ComputeHeadersSize(headers)
        ;

        /// <summary>
        /// Used to compute the precise Record header size in bytes.
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        protected static int ComputeHeadersSize(
            ImmutableArray<RecordHeader> headers
        ) =>
            BinaryEncoder.SizeOfVarInt32(headers.Length) +
            headers.Sum(
                r =>
                    BinaryEncoder.SizeOfVarInt32(r.Key.Length) +
                    r.Key.Length +
                    BinaryEncoder.SizeOfVarInt32(r.Value.Length) +
                    r.Value.Length
            )
        ;

        async ValueTask IProducerProtocol.Close(CancellationToken cancellationToken)
        {
            await _protocol.Close(cancellationToken).ConfigureAwait(false);
            await Closing(cancellationToken).ConfigureAwait(false);
        }

        async ValueTask IProducerProtocol.Flush(CancellationToken cancellationToken) =>
            await Flushing(cancellationToken).ConfigureAwait(false)
        ;

        protected abstract ValueTask Sending(SendCommand sendCommand, CancellationToken cancellationToken);
        protected abstract ValueTask Closing(CancellationToken cancellationToken);
        protected abstract ValueTask Flushing(CancellationToken cancellationToken);
        protected virtual void Dispose(bool disposing) { }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
