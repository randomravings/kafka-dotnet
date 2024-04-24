using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client
{
    public interface IGroupReaderBuilder
    {
        /// <summary>
        /// Sets the assigned topic.
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        IGroupReaderBuilder WithTopic(TopicName topic);

        /// <summary>
        /// Sets the assigned topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <returns></returns>
        IGroupReaderBuilder WithTopics(params TopicName[] topics);
        /// <summary>
        /// Sets the assigned topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <returns></returns>
        IGroupReaderBuilder WithTopics(IEnumerable<TopicName> topics);
        IGroupReaderBuilder WithLogger(ILogger logger);
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
        IGroupReader<TKey, TValue> Build();
    }
}
