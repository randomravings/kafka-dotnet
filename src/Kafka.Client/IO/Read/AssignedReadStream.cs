using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal class AssignedReadStream(
        ICluster<INodeLink> connectionManager,
        ReadStreamConfig config,
        ILogger logger
    ) :
        ReadStream(connectionManager, config, logger),
        IAssignedReadStream
    {
        IAssignedReaderBuilder IAssignedReadStream.CreateReader()
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReadStream.Assign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReadStream.Unassign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReadStream.Seek(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        protected override ValueTask Closing(
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        protected override ValueTask<IDictionary<TopicPartition, LeaderAndOffset>> GetTopicPartitionOffsets(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
