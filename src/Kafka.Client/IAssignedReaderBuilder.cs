﻿using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client
{
    public interface IAssignedReaderBuilder
    {
        IAssignedReaderBuilder WithTopicPartitionOffsets(IEnumerable<TopicPartitionOffset> topicPartitionOffsets);
        IAssignedReaderBuilder WithLogger(ILogger logger);
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
        IAssignedReader<TKey, TValue> Build();
    }
}
