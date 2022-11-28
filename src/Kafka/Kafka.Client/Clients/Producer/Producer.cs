using Kafka.Client.Messages;
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
        public Producer(
            ProducerConfig config
        ) : base(config)
        {
            _keySerializer = GetKeySerializer(config);
            _valueSerializer = GetValueSerializer(config);
            _partitioner = GetPartitioner(config);
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
        }

        public Producer(
            ProducerConfig config,
            IPartitioner partitioner
        ) : base(config)
        {
            _keySerializer = GetKeySerializer(config);
            _valueSerializer = GetValueSerializer(config);
            _partitioner = partitioner;
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
        }

        public async ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            CancellationToken cancellationToken
        ) =>
            await Send(
                topic,
                key,
                value,
                Timestamp.Now(),
                ImmutableArray<RecordHeader>.Empty,
                cancellationToken
            )
        ;

        public async ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            CancellationToken cancellationToken
        ) =>
            await Send(
                topic,
                key,
                value,
                timestamp,
                ImmutableArray<RecordHeader>.Empty,
                cancellationToken
            )
        ;

        public async ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken
        ) =>
            await Send(
                topic,
                key,
                value,
                Timestamp.Now(),
                recordHeaders,
                cancellationToken
            )
        ;

        public async ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken
        )
        {
            var record = new ProducerRecord<TKey, TValue>(
                timestamp,
                recordHeaders,
                key,
                value
            );
            return await Send(topic, record, cancellationToken);
        }

        public async ValueTask<ProduceResult<TKey, TValue>> Send(
            string topic,
            ProducerRecord<TKey, TValue> producerRecord,
            CancellationToken cancellationToken
        )
        {
            var keyBytes = _keySerializer.Write(producerRecord.Key);
            var valueBytes = _valueSerializer.Write(producerRecord.Value);
            var partition = await _partitioner.Select(_cluster, topic, keyBytes);

            var record = new Record(
                0,
                0,
                0,
                1,
                Attributes.None,
                0,
                0,
                keyBytes,
                valueBytes,
                producerRecord.Headers
            );

            var batch = new RecordBatch(
                0,
                1,
                0,
                2,
                0,
                Attributes.None,
                0,
                0,
                0,
                0,
                0,
                0,
                new IRecord[] { record }.ToImmutableArray()
            );

            var request = new ProduceRequest(
                null,
                1,
                5000,
                new[]
                {
                    new ProduceRequest.TopicProduceData(
                        topic,
                        new[]
                        {
                            new ProduceRequest.TopicProduceData.PartitionProduceData(
                                0,
                                batch
                            )
                        }.ToImmutableArray()
                    )
                }.ToImmutableArray()
            );

            var respose = await HandleRequest(
                request,
                (s, v, r) => ProduceRequestSerde.Write(s, v, r),
                (ref ReadOnlyMemory<byte> s, short v) => ProduceResponseSerde.Read(ref s, v),
                null,
                cancellationToken
            );

            return new ProduceResult<TKey, TValue>(new(topic, new(partition, 0)), producerRecord);
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
    }
}
