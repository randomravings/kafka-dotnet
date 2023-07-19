using Kafka.Common.Serialization;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.Clients.Consumer
{
    public interface INewConsumerBuilder
    {
        IConfiguredConsumerBuilder WithConfig(ConsumerConfig consumerConfig);
    }

    public interface IConfiguredConsumerBuilder
    {
        IKeyedConsumerBuilder<Null> WithoutKey();
        IKeyedConsumerBuilder<TKey> WithKey<TKey>(IDeserializer<TKey> keyDedeserializer);
    }

    public interface IKeyedConsumerBuilder<TKey>
    {
        IConsumerBuilder<TKey, TValue> WithValue<TValue>(IDeserializer<TValue> valueDedeserializer);
    }

    public interface IConsumerBuilder<TKey, TValue>
    {
        IConsumerBuilder<TKey, TValue> WithLogger(ILogger<IConsumer<TKey, TValue>> logger);
        IConsumer<TKey, TValue> Build();
    }

    public sealed class ConsumerBuilder :
        INewConsumerBuilder,
        IConfiguredConsumerBuilder
    {
        private ConsumerConfig _consumerConfig= new();
        private ConsumerBuilder() { }
        public static INewConsumerBuilder New() =>
            new ConsumerBuilder()
        ;
        IConfiguredConsumerBuilder INewConsumerBuilder.WithConfig(ConsumerConfig consumerConfig)
        {
            _consumerConfig = consumerConfig;
            return this;
        }

        IKeyedConsumerBuilder<TKey> IConfiguredConsumerBuilder.WithKey<TKey>(IDeserializer<TKey> keyDedeserializer) =>
            new KeyedConsumerBuilder<TKey>(keyDedeserializer, _consumerConfig)
        ;

        IKeyedConsumerBuilder<Null> IConfiguredConsumerBuilder.WithoutKey() =>
            new KeyedConsumerBuilder<Null>(Deserializers.Null, _consumerConfig)
        ;

        private sealed class KeyedConsumerBuilder<TKey> :
            IKeyedConsumerBuilder<TKey>
        {

            private readonly IDeserializer<TKey> _keyDedeserializer;
            private readonly ConsumerConfig _consumerConfig;
            public KeyedConsumerBuilder(
                IDeserializer<TKey> keyDedeserializer,
                ConsumerConfig consumerConfig
            )
            {
                _keyDedeserializer = keyDedeserializer;
                _consumerConfig = consumerConfig;
            }

            IConsumerBuilder<TKey, TValue> IKeyedConsumerBuilder<TKey>.WithValue<TValue>(IDeserializer<TValue> valueDedeserializer) =>
                new TypedConsumerBuilder<TKey, TValue>(_keyDedeserializer, valueDedeserializer, _consumerConfig)
            ;
        }

        private sealed class TypedConsumerBuilder<TKey, TValue> :
            IConsumerBuilder<TKey, TValue>
        {
            private readonly IDeserializer<TKey> _keyDedeserializer;
            private readonly IDeserializer<TValue> _valueDedeserializer;
            private readonly ConsumerConfig _consumerConfig;
            private ILogger<IConsumer<TKey, TValue>> _logger = NullLogger<IConsumer<TKey, TValue>>.Instance;
            public TypedConsumerBuilder(
                IDeserializer<TKey> keyDedeserializer,
                IDeserializer<TValue> valueDedeserializer,
                ConsumerConfig consumerConfig
            )
            {
                _keyDedeserializer = keyDedeserializer;
                _valueDedeserializer = valueDedeserializer;
                _consumerConfig = consumerConfig;
            }

            IConsumerBuilder<TKey, TValue> IConsumerBuilder<TKey, TValue>.WithLogger(ILogger<IConsumer<TKey, TValue>> logger)
            {
                _logger = logger;
                return this;
            }

            IConsumer<TKey, TValue> IConsumerBuilder<TKey, TValue>.Build()
            {
                return new KafkaConsumerClient<TKey, TValue>(_keyDedeserializer, _valueDedeserializer, _consumerConfig, _logger);
            }
        }
    }
}
