using Kafka.Common.Serialization;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class Producer<TKey, TValue> :
        Client<ProducerConfig>,
        IProducer<TKey, TValue>
    {
        private readonly ISerializer<TKey> _keySerializer;
        private readonly ISerializer<TValue> _valueSerializer;
        private readonly IPartitioner _partitioner;
        internal Producer(
            ProducerConfig config
        ) : base(config)
        {
            _keySerializer = GetKeySerializer(config);
            _valueSerializer = GetValueSerializer(config);
            _partitioner = GetPartitioner(config);
        }

        internal Producer(
            ProducerConfig config,
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer
        ) : base(config)
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
            _partitioner = GetPartitioner(config);
        }

        internal Producer(
            ProducerConfig config,
            IPartitioner partitioner
        ) : base(config)
        {
            _keySerializer = GetKeySerializer(config);
            _valueSerializer = GetValueSerializer(config);
            _partitioner = partitioner;
        }

        internal Producer(
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
            ProducerRecord<TKey, TValue> record
        )
        {
            var keyBytes = _keySerializer.Write(record.Key);
            var valueBytes = _valueSerializer.Write(record.Value);
            var partition = await _partitioner.Select(_cluster, topic, keyBytes);            

            return new ProduceResult<TKey, TValue>(new(topic, new(partition,0)), record);
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
            if(type == null)
                throw new TypeLoadException(fullName);
            if(!typeof(TType).IsAssignableFrom(type))
                throw new TypeLoadException(fullName);
            var instance = Activator.CreateInstance(type);
            if(instance == null)
                throw new TypeLoadException(fullName);
            return (TType)instance;
        }
    }
}
