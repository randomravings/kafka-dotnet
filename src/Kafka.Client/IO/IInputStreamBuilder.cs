using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IInputStreamBuilder
    {
        IApplicationInputStreamBuilder AsApplication(
            TopicName topics
        );
        IApplicationInputStreamBuilder AsApplication(
            IReadOnlySet<TopicName> topics
        );
        IManualInputStreamBuilder AsManual();
    }
}
