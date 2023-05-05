using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Records;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal abstract class BrokerChannel :
        IBrokerChannel
    {
        protected readonly long _producerId;
        protected readonly short _producerEpoch;
        protected readonly short _acks;
        protected readonly string? _transactionalId;
        protected readonly int _requestTimeoutMs;
        protected readonly ILogger _logger;
        protected readonly IConnection _connection;
        protected readonly ProducerConfig _config;
        protected readonly SortedList<TopicPartition, int> _topicPartitionStates = new(TopicPartitionCompare.Instance);

        public BrokerChannel(
            long producerId,
            short producerEpoch,
            short acks,
            string transactionalId,
            int requestTimeoutMs,
            ProducerConfig config,
            IConnection connection,
            ILogger logger
        )
        {
            _config = config;
            _producerId = producerId;
            _producerEpoch = producerEpoch;
            _acks = acks;
            _transactionalId = transactionalId;
            _requestTimeoutMs = requestTimeoutMs;
            _connection = connection;
            _logger = logger;
        }

        public abstract Task Send(SendCommand sendCommand, CancellationToken cancellationToken);

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
                batchSize += Encoder.SizeOfInt32(record.Length);
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
            batchSize += Encoder.SizeOfInt32(batchSize);
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
            Encoder.SizeOfInt64(timestampDelta) +
            Encoder.SizeOfInt32(offsetDelta) +
            1 + // Attributes
            Encoder.SizeOfInt32(key?.Length ?? 0) +
            (key?.Length ?? 0) +
            Encoder.SizeOfInt32(value?.Length ?? 0) +
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
            Encoder.SizeOfInt32(headers.Length) +
            headers.Sum(
                r =>
                    Encoder.SizeOfInt32(r.Key.Length) +
                    r.Key.Length +
                    Encoder.SizeOfInt32(r.Value.Length) +
                    r.Value.Length
            )
        ;

        async Task IBrokerChannel.Close(CancellationToken cancellationToken)
        {
            await _connection.Close(cancellationToken);
            await Closing(cancellationToken);
        }

        async Task IBrokerChannel.Flush(CancellationToken cancellationToken) =>
            await Flushing(cancellationToken)
        ;

        protected abstract Task Closing(CancellationToken cancellationToken);
        protected abstract Task Flushing(CancellationToken cancellationToken);
    }
}
