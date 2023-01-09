using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.Clients.Producer
{
    public interface INewProducerBuilder
    {
        IConfiguredProducerBuilder WithConfig(ProducerConfig producerConfig);
    }

    public interface IConfiguredProducerBuilder
    {
        IKeyedProducerBuilder<Null> WithoutKey();
        IKeyedProducerBuilder<TKey> WithKey<TKey>(ISerializer<TKey> keySerializer);
    }

    public interface IKeyedProducerBuilder<TKey>
    {
        IProducerBuilder<TKey, TValue> WithValue<TValue>(ISerializer<TValue> valueSerializer);
    }

    public interface IProducerBuilder<TKey, TValue>
    {
        IProducerBuilder<TKey, TValue> WithPartitioner(IPartitioner partitioner);
        IProducerBuilder<TKey, TValue> WithLogger(ILogger<IProducer<TKey, TValue>> logger);
        IProducer<TKey, TValue> Build();
    }

    public class ProducerBuilder :
        INewProducerBuilder,
        IConfiguredProducerBuilder
    {
        private ProducerConfig _producerConfig = new();
        private ProducerBuilder() { }
        public static INewProducerBuilder New() =>
            new ProducerBuilder()
        ;
        IConfiguredProducerBuilder INewProducerBuilder.WithConfig(ProducerConfig producerConfig)
        {
            _producerConfig = producerConfig;
            return this;
        }

        IKeyedProducerBuilder<TKey> IConfiguredProducerBuilder.WithKey<TKey>(ISerializer<TKey> keySerializer) =>
            new KeyedProducerBuilder<TKey>(keySerializer, _producerConfig)
        ;

        IKeyedProducerBuilder<Null> IConfiguredProducerBuilder.WithoutKey() =>
            new KeyedProducerBuilder<Null>(Serializers.Null, _producerConfig)
        ;

        private sealed class KeyedProducerBuilder<TKey> :
            IKeyedProducerBuilder<TKey>
        {

            private readonly ISerializer<TKey> _keySerializer;
            private readonly ProducerConfig _producerConfig;
            public KeyedProducerBuilder(
                ISerializer<TKey> keySerializer,
                ProducerConfig producerConfig
            )
            {
                _keySerializer = keySerializer;
                _producerConfig = producerConfig;
            }

            IProducerBuilder<TKey, TValue> IKeyedProducerBuilder<TKey>.WithValue<TValue>(ISerializer<TValue> valueSerializer) =>
                new TypedProducerBuilder<TKey, TValue>(_keySerializer, valueSerializer, _producerConfig)
            ;
        }

        private sealed class TypedProducerBuilder<TKey, TValue> :
            IProducerBuilder<TKey, TValue>
        {
            private readonly ISerializer<TKey> _keySerializer;
            private readonly ISerializer<TValue> _valueSerializer;
            private readonly ProducerConfig _producerConfig;
            private IPartitioner _partitioner = DefaultPartitioner.Instance;
            private ILogger<IProducer<TKey, TValue>> _logger = NullLogger<IProducer<TKey, TValue>>.Instance;
            public TypedProducerBuilder(
                ISerializer<TKey> keySerializer,
                ISerializer<TValue> valueSerializer,
                ProducerConfig producerConfig
            )
            {
                _keySerializer = keySerializer;
                _valueSerializer = valueSerializer;
                _producerConfig = producerConfig;
            }

            IProducerBuilder<TKey, TValue> IProducerBuilder<TKey, TValue>.WithPartitioner(IPartitioner partitioner)
            {
                _partitioner = partitioner;
                return this;
            }
            IProducerBuilder<TKey, TValue> IProducerBuilder<TKey, TValue>.WithLogger(ILogger<IProducer<TKey, TValue>> logger)
            {
                _logger = logger;
                return this;
            }

            IProducer<TKey, TValue> IProducerBuilder<TKey, TValue>.Build()
            {
                return new ProducerClient<TKey, TValue>(_keySerializer, _valueSerializer, _partitioner, _producerConfig, _logger);
            }
        }
    }
}
