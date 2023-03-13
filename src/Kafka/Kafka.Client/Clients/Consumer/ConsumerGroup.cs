using Kafka.Client.Messages;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class ConsumerGroup :
        IConsumerGroup
    {
        private readonly IConnectionPool _connectionPool;
        private readonly ConsumerConfig _config;
        private readonly ILogger _logger;

        private string _memberId = "";
        private int _generationId = 0;

        public ConsumerGroup(
            IConnectionPool connectionPool,
            ConsumerConfig config,
            ILogger logger
        )
        {
            _config = config;
            _logger = logger;
            _connectionPool = connectionPool;
        }

        async Task<IConsumerGroupInstance> IConsumerGroup.JoinGroup(
            IReadOnlySet<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var randomConnection = await _connectionPool.AquireSharedConnection(cancellationToken);
            var findCoordinatorResponse = await ConsumerProtocol.FindCoordinator(randomConnection, _config, _logger, cancellationToken);
            (var host, var port) = GetHost(findCoordinatorResponse);
            var coordinatorConnection = randomConnection;
            if (randomConnection.Host != host || randomConnection.Port != port)
            {
                coordinatorConnection = await _connectionPool.AquireSharedConnection(host, port, cancellationToken);
                await randomConnection.Close(cancellationToken);
            }
            var metadataResponse = await ConsumerProtocol.Metadata(
                coordinatorConnection,
                topics,
                cancellationToken
            );
            var allTopicPartitions = TopicPartitionHelper.GetTopicPartitions(
                metadataResponse
            );
            var joinGroupResponse = await ConsumerProtocol.JoinGroup(
                coordinatorConnection,
                _memberId,
                topics,
                _config,
                cancellationToken
            );
            _generationId = joinGroupResponse.GenerationIdField;
            _memberId = joinGroupResponse.MemberIdField;
            if (joinGroupResponse.ErrorCodeField == Errors.Known.MEMBER_ID_REQUIRED.Code)
            {
                joinGroupResponse = await ConsumerProtocol.JoinGroup(
                    coordinatorConnection,
                    _memberId,
                    topics,
                    _config,
                    cancellationToken
                );
                _generationId = joinGroupResponse.GenerationIdField;
                _memberId = joinGroupResponse.MemberIdField;
            }
            if (joinGroupResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(joinGroupResponse.ErrorCodeField);
                throw new ApiException(error);
            }

            var assignments = new Dictionary<string, List<TopicPartition>>();
            // I b leader?
            if (_memberId == joinGroupResponse.LeaderField)
            {
                assignments = joinGroupResponse.MembersField.ToDictionary(k => k.MemberIdField, v => new List<TopicPartition>());
                var keys = assignments.Keys.ToArray();
                var i = 0;
                foreach(var topicPartition in allTopicPartitions)
                {
                    assignments[keys[i]].Add(topicPartition);
                    i = (i + 1) % keys.Length;
                }
            }

            var syncGroupResponse = await ConsumerProtocol.SyncGroup(
                coordinatorConnection,
                _generationId,
                _memberId,
                joinGroupResponse.ProtocolNameField,
                assignments,
                _config,
                cancellationToken
            );

            if (syncGroupResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(syncGroupResponse.ErrorCodeField);
                throw new ApiException(error);
            }

            var topicPartitions = GetAssingments(syncGroupResponse);
            
            var cluster = await coordinatorConnection.GetClusterInfo(cancellationToken);
            var nodeAssignments = await TopicPartitionHelper.CreateNodeAssignments(
                cluster,
                _connectionPool,
                metadataResponse,
                topicPartitions,
                cancellationToken
            );

            var topicPartitionOffsets = topicPartitions.ToDictionary(k => k, v => Offset.Unset);

            var offsetFetchResponse = await ConsumerProtocol.OffsetFetch(
                coordinatorConnection,
                _config,
                topicPartitions,
                cancellationToken
            );
            TopicPartitionHelper.UpdateTopicPartitionOffsets(
                topicPartitionOffsets,
                offsetFetchResponse
            );
            var unsetTopicPartitions = topicPartitionOffsets
                .Where(r => r.Value < 0)
                .Select(r => r.Key)
                .ToImmutableSortedSet(TopicPartitionCompare.Instance)
            ;
            if (unsetTopicPartitions.Any())
            {
                var listOffsetsResponse = nodeAssignments
                    .Select(r =>
                        new
                        {
                            Assignment = r,
                            Set = r.TopicPartitions.Intersect(unsetTopicPartitions)
                        }
                    )
                    .Where(r => r.Set.Any())
                    .Select(r =>
                        ConsumerProtocol.ListOffsets(
                            r.Assignment.Connection,
                            r.Set,
                            _config.IsolationLevel,
                            DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                            cancellationToken
                        )
                    )
                ;
                await Task.WhenAll(listOffsetsResponse);
                var listOffsets = listOffsetsResponse.Select(r => r.Result).ToImmutableArray();
                TopicPartitionHelper.UpdateTopicPartitionOffsets(
                    topicPartitionOffsets,
                    listOffsets
                );
            }
            return new ConsumerGroupInstance(_memberId, _generationId, coordinatorConnection, nodeAssignments, topicPartitionOffsets, _config, _logger);
        }

        private static ImmutableSortedSet<TopicPartition> GetAssingments(SyncGroupResponse syncGroupResponse)
        {
            var set = ImmutableSortedSet.CreateBuilder(TopicPartitionCompare.Instance);
            var offset = 0;
            var data = syncGroupResponse.AssignmentField.ToArray();
            (offset, var size) = Decoder.ReadInt32(data, offset);
            (offset, var topicCount) = Decoder.ReadInt16(data, offset);
            for (int i = 0; i < topicCount; i++)
            {
                (offset, var topic) = Decoder.ReadString(data, offset);
                (offset, var partitionCount) = Decoder.ReadInt32(data, offset);
                for (int j = 0; j < partitionCount; j++)
                {
                    (offset, var partition) = Decoder.ReadInt32(data, offset);
                    set.Add(new TopicPartition(topic, partition));
                }
            }
            return set.ToImmutable();
        }

        private static (string Host, int Port) GetHost(FindCoordinatorResponse findCoordinatorResponse)
        {
            if (!string.IsNullOrEmpty(findCoordinatorResponse.HostField))
                return (findCoordinatorResponse.HostField, findCoordinatorResponse.PortField);
            var host = findCoordinatorResponse.CoordinatorsField.First();
            return (host.HostField, host.PortField);
        }
    }
}
