using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IManualReaderBuilder
    {
        IManualReaderBuilder WithTopicPartitions(params TopicPartition[] topicPartitions);
        IManualReaderBuilder WithLogger(ILogger logger);
        IManualReader Build();
        IManualReaderBuilder<TKey> WithKey<TKey>(
            IDeserializer<TKey> keyDeserializer
        );
    }

    public interface IManualReaderBuilder<TKey>
    {
        IManualReaderBuilder<TKey, TValue> WithValue<TValue>(
            IDeserializer<TValue> valueDeserializer
        );
    }

    public interface IManualReaderBuilder<TKey, TValue>
    {
        IManualReader<TKey, TValue> Build();
    }
}
