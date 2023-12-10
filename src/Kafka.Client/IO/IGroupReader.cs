using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IGroupReader<TKey, TValue> :
        IReader<TKey, TValue>
    {
        ValueTask<bool> AddTopics(IEnumerable<TopicName> topics);
        ValueTask<bool> RemoveTopics(IEnumerable<TopicName> topics);
        ValueTask<bool> SetTopics(IEnumerable<TopicName> topics);
    }
}
