using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Stream
{
    internal class ManualInputStream :
        InputStream,
        IManualInputStream
    {
        public ManualInputStream(
            ICluster<INodeLink> connectionManager,
            InputStreamConfig config,
            ILogger logger
        ) : base(connectionManager, config, logger)
        {
        }

        ValueTask IManualInputStream.Assign(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Assign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Assign(TopicPartitionOffset topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Assign(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Seek(TopicPartitionOffset topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Seek(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Seek(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Seek(IReadOnlyList<TopicPartition> topicPartitions, Timestamp timestamp)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.SeekBeginning()
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.SeekBeginning(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.SeekBeginning(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.SeekEnd()
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.SeekEnd(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.SeekEnd(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Unassign(TopicPartition topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualInputStream.Unassign(IReadOnlyList<TopicPartition> topicPartitions)
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
