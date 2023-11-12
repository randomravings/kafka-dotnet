using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IApplicationInputStreamAssignBuilder
    {
        IApplicationInputStreamBuilder WithTopic(TopicName topic);
        IApplicationInputStreamBuilder WithTopics(IReadOnlySet<TopicName> topics);
    }

    public interface IApplicationInputStreamBuilder
    {
        IApplicationInputStreamBuilder WithLogger(ILogger<IApplicationInputStream> logger);
        IApplicationInputStream Build();
    }
}
