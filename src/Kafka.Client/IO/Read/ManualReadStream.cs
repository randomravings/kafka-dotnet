using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal class ManualReadStream(
        ICluster<INodeLink> connectionManager,
        ReadStreamConfig config,
        ILogger logger
    ) :
        ReadStream(connectionManager, config, logger),
        IManualReadStream
    {
        IManualReaderBuilder IManualReadStream.CreateReader()
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReadStream.Assign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReadStream.Unassign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReadStream.Seek(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        protected override ValueTask Closing(
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        protected override ValueTask<TopicPartitionMap<LeaderAndOffset>> GetTopicPartitionOffsets(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
