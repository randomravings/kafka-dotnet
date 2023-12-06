using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IApplicationReaderBuilder
    {
        /// <summary>
        /// Sets the assigned topic.
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        IApplicationReaderBuilder WithTopic(TopicName topic);

        /// <summary>
        /// Sets the assigned topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <returns></returns>
        IApplicationReaderBuilder WithTopics(params TopicName[] topics);
        /// <summary>
        /// Sets the assigned topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <returns></returns>
        IApplicationReaderBuilder WithTopics(IEnumerable<TopicName> topics);
        IApplicationReaderBuilder WithLogger(ILogger logger);
        IApplicationReaderBuilder<TKey> WithKey<TKey>(
            IDeserializer<TKey> keyDeserializer
        );
    }

    public interface IApplicationReaderBuilder<TKey>
    {
        IApplicationReaderBuilder<TKey, TValue> WithValue<TValue>(
            IDeserializer<TValue> valueDeserializer
        );
    }

    public interface IApplicationReaderBuilder<TKey, TValue>
    {
        IApplicationReader<TKey, TValue> Build();
    }
}
