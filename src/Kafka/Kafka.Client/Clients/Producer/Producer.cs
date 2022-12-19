using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Encoding;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    public sealed class Producer<TKey, TValue> :
        Client<ProducerConfig>,
        IProducer<TKey, TValue>
    {
        private readonly ISerializer<TKey> _keySerializer;
        private readonly ISerializer<TValue> _valueSerializer;
        private readonly IPartitioner _partitioner;
        private readonly RecordAccumulator<TKey, TValue> _requestAccumulator;
        private readonly RecordsBuilder<TKey, TValue> _builder;
        public Producer(
            ProducerConfig config
        ) : base(config)
        {
            _keySerializer = GetKeySerializer(config);
            _valueSerializer = GetValueSerializer(config);
            _partitioner = GetPartitioner(config);
            _builder = new RecordsBuilder<TKey, TValue>(HandleRecordSend);
            _requestAccumulator = new RecordAccumulator<TKey, TValue>(
                config.MaxInFlightRequestsPerConnection,
                config.MaxRequestSize,
                config.LingerMs,
                RecordSize,
                HandleRecordBatch
            );
        }

        public Producer(
            ProducerConfig config,
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer
        ) : base(config)
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
            _partitioner = GetPartitioner(config);
            _builder = new RecordsBuilder<TKey, TValue>(HandleRecordSend);
            _requestAccumulator = new RecordAccumulator<TKey, TValue>(
                config.MaxInFlightRequestsPerConnection,
                config.MaxRequestSize,
                config.LingerMs,
                RecordSize,
                HandleRecordBatch
            );
        }

        public Producer(
            ProducerConfig config,
            IPartitioner partitioner
        ) : base(config)
        {
            _keySerializer = GetKeySerializer(config);
            _valueSerializer = GetValueSerializer(config);
            _partitioner = partitioner;
            _builder = new RecordsBuilder<TKey, TValue>(HandleRecordSend);
            _requestAccumulator = new RecordAccumulator<TKey, TValue>(
                config.MaxInFlightRequestsPerConnection,
                config.MaxRequestSize,
                config.LingerMs,
                RecordSize,
                HandleRecordBatch
            );
        }

        public Producer(
            ProducerConfig config,
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer,
            IPartitioner partitioner
        ) : base(config)
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
            _partitioner = partitioner;
            _builder = new RecordsBuilder<TKey, TValue>(HandleRecordSend);
            _requestAccumulator = new RecordAccumulator<TKey, TValue>(
                config.MaxInFlightRequestsPerConnection,
                config.MaxRequestSize,
                config.LingerMs,
                RecordSize,
                HandleRecordBatch
            );
        }

        public async ValueTask<ProduceResult<TKey, TValue>> Send(
            ProduceRecord<TKey, TValue> produceRecord,
            CancellationToken cancellationToken
        )
        {
            var keyBytes = _keySerializer.Write(produceRecord.Key);
            var valueBytes = _valueSerializer.Write(produceRecord.Value);

            var partition = produceRecord.Partition;
            if (partition == Partition.Unassigned)
                partition = await _partitioner.Select(_cluster, produceRecord.Topic, keyBytes);

            var timestamp = produceRecord.Timestamp;
            if (timestamp == Timestamp.None)
                timestamp = Timestamp.Now();

            var result = await _requestAccumulator.Add(
                produceRecord,
                timestamp,
                partition,
                keyBytes,
                valueBytes,
                cancellationToken
            );

            return result;
        }

        private static IPartitioner GetPartitioner(
            ProducerConfig producerConfig
        ) =>
            producerConfig.PartitionerClass switch
            {
                "" or null => DefaultPartitioner.Instance,
                var s => Resolve<IPartitioner>(s)
            }
        ;

        private static ISerializer<TKey> GetKeySerializer(
            ProducerConfig producerConfig
        ) =>
            Resolve<ISerializer<TKey>>(
                producerConfig.KeySerializer
            )
        ;

        private static ISerializer<TValue> GetValueSerializer(
            ProducerConfig producerConfig
        ) =>
            Resolve<ISerializer<TValue>>(
                producerConfig.ValueSerializer
            )
        ;

        private static TType Resolve<TType>(
            string fullName
        )
        {
            var type = Type.GetType(fullName);
            if (type == null)
                throw new TypeLoadException(fullName);
            if (!typeof(TType).IsAssignableFrom(type))
                throw new TypeLoadException(fullName);
            var instance = Activator.CreateInstance(type);
            if (instance == null)
                throw new TypeLoadException(fullName);
            return (TType)instance;
        }

        private static int HeaderSize(
            ImmutableArray<RecordHeader> headers
        )
        {
            var bytesRequired = 4;
            foreach (var header in headers)
                bytesRequired +=
                    Encoder.SizeOfInt32(header.Key.Length) +
                    header.Key.Length +
                    Encoder.SizeOfInt32(header.Value.Length) +
                    header.Value.Length
                ;
            return bytesRequired;
        }

        private static int RecordSize(ProduceCallback<TKey, TValue> produceCallback) =>
            Encoder.SizeOfInt32(produceCallback.KeyBytes?.Length ?? 0) +
            produceCallback.KeyBytes?.Length ?? 0 +
            Encoder.SizeOfInt32(produceCallback.ValueBytes?.Length ?? 0) +
            produceCallback.KeyBytes?.Length ?? 0 +
            HeaderSize(produceCallback.Record.Headers) +
            40 // Add some overhead to accout for overhead varint stuff.
        ;

        private void HandleRecordBatch(
            BatchAccumulatedReason reason,
            ImmutableArray<ProduceCallback<TKey, TValue>> batch
        )
        {
            var batchPerPartition = batch
                .GroupBy(
                    g => new TopicPartition(g.Record.Topic, g.Partition)
                )
                .ToImmutableDictionary(
                    k => k.Key,
                    v => v.ToImmutableArray()
                )
            ;
            _builder.Add(batchPerPartition, CancellationToken.None);
        }

        private async Task HandleRecordSend(
            TopicPartition topicPartition,
            IRecords records,
            ImmutableArray<ProduceCallback<TKey, TValue>> produceCallbacks,
            CancellationToken cancellationToken
        )
        {
            var request = new ProduceRequest(
                null,
                -1,
                30000,
                new[]
                {
                    new ProduceRequest.TopicProduceData(
                        topicPartition.Topic.Value ?? "",
                        new[]
                        {
                            new ProduceRequest.TopicProduceData.PartitionProduceData(
                                topicPartition.Partition,
                                records
                            )
                        }.ToImmutableArray()
                    )
                }.ToImmutableArray()
            );

            var respose = await HandleRequest(
                request,
                (b, i, r, v) => ProduceRequestSerde.Write(b, i, r, v),
                (byte[] b, ref int i, short v) => ProduceResponseSerde.Read(b, ref i, v),
                9,
                ProduceRequest.FlexibleVersion,
                cancellationToken
            );

            for (int i = 0; i < respose.ResponsesField.Length; i++)
            {
                var topicResponse = respose.ResponsesField[i];
                var topicName = new TopicName(topicResponse.NameField);
                for (int j = 0; j < topicResponse.PartitionResponsesField.Length; j++)
                {
                    var partitionResponse = topicResponse.PartitionResponsesField[j];
                    var partition = new Partition(partitionResponse.IndexField);
                    var offset = new Offset(partitionResponse.BaseOffsetField);
                    var topicPartitionOffset = new TopicPartitionOffset(topicName, new(partition, offset));
                    var timestamp = Timestamp.LogAppend(partitionResponse.LogAppendTimeMsField);
                    var error = Errors.Translate(partitionResponse.ErrorCodeField);
                    var recordErrors = $"{partitionResponse.ErrorMessageField}:{string.Join(',',partitionResponse.RecordErrorsField.Select(r => $"[{r.BatchIndexField}]{r.BatchIndexErrorMessageField}"))}";

                    var produceCallback = produceCallbacks[j];
                    produceCallback.TaskCompletionSource.SetResult(
                        new ProduceResult<TKey, TValue>(
                            topicPartitionOffset,
                            timestamp,
                            produceCallback.Record.Headers,
                            produceCallback.Record.Key,
                            produceCallback.Record.Value,
                            error,
                            recordErrors
                        )
                    );
                }
            }
        }
    }
}
