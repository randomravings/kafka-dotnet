using Kafka.Common.Model;
using Kafka.Common.Records;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record FetchRecords(
        TopicPartition TopicPartition,
        IRecords Records,
        short Error
    );
}
