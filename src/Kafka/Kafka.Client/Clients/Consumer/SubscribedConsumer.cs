using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Exceptions;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Linq;

namespace Kafka.Client.Clients.Consumer
{
    public sealed class SubscribedConsumer<TKey, TValue> :
        Client<ConsumerConfig>,
        IConsumer<TKey, TValue>
    {
        private SubscriptionMetadata _subscriptionMetadata = SubscriptionMetadata.Empty;
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly SortedSet<TopicName> _subscribeTopics = new();
        private readonly SortedSet<TopicName> _unsubscribeTopics = new();
        private readonly Queue<ConsumeResult<TKey, TValue>> _results = new();
        private readonly Dictionary<TopicPartition, Offset> _topicPartitionOffsets = new();
        private readonly Dictionary<TopicPartition, ConsumeResult<TKey, TValue>> _lastConsumedResult = new();
        private readonly Task _autoCommitterTask;
        private readonly Task _hearbeatTask;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly ManualResetEventSlim _autoCommitWaitHandle = new(false);
        private readonly ILogger<SubscribedConsumer<TKey, TValue>> _logger;

        public SubscribedConsumer(
            ConsumerConfig config,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger<SubscribedConsumer<TKey, TValue>> logger
        ) : base(config)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _logger = logger;
            _subscriptionMetadata = SubscriptionMetadata.Empty with
            {
                GroupId = config.GroupId ?? "",
                InstanceId = config.GroupInstanceId
            };
            _autoCommitterTask = Task.Run(async () => await CommitLoop(_internalCts.Token), CancellationToken.None);
        }

        private async Task CommitLoop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _autoCommitWaitHandle.Wait(_config.AutoCommitIntervalMs, cancellationToken);
                await _semaphore.WaitAsync(cancellationToken);
                var request = default(OffsetCommitRequest);
                try
                {
                    if (_lastConsumedResult.Count == 0)
                        continue;
                    var offsetCommitRequestTopic = _lastConsumedResult
                        .GroupBy(g => g.Key.Topic.Value ?? "")
                        .Select(t =>
                            new OffsetCommitRequest.OffsetCommitRequestTopic(
                                t.Key,
                                t.Select(p =>
                                    new OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition(
                                        p.Value.TopicPartition.Partition,
                                        p.Value.Offset.Value + 1,
                                        -1,
                                        Timestamp.Now().TimestampMs,
                                        null
                                    )
                                ).ToImmutableArray()
                            )
                        )
                        .ToImmutableArray()
                    ;
                    request = new OffsetCommitRequest(
                        _subscriptionMetadata.GroupId,
                        _subscriptionMetadata.GenerationId,
                        _subscriptionMetadata.MemberId,
                        _subscriptionMetadata.InstanceId,
                        -1,
                        offsetCommitRequestTopic
                    );
                    _lastConsumedResult.Clear();
                }
                finally
                {
                    _semaphore.Release();
                }
                var response = await HandleRequest(
                    request,
                    OffsetCommitRequestSerde.Write,
                    OffsetCommitResponseSerde.Read,
                    cancellationToken
                );
            }
        }

        private int EnqueueResults(FetchResponse response)
        {
            var recordsAdded = 0;
            foreach (var topic in response.ResponsesField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    var topicPartition = new TopicPartition(topic.TopicField, partition.PartitionIndexField);
                    if (partition.ErrorCodeField != 0)
                        throw new ApiException(Errors.Translate(partition.ErrorCodeField));
                    if (partition.RecordsField == null)
                        continue;
                    var offset = 0L;
                    foreach (var record in partition.RecordsField)
                    {
                        offset = partition.RecordsField.Offset + record.OffsetDelta;
                        var timestamp = partition.RecordsField.BaseTimestamp + record.TimestampDelta;
                        var key = _keyDeserializer.Read(record.Key);
                        var value = _valueDeserializer.Read(record.Value);
                        var consumeResult = new ConsumeResult<TKey, TValue>(
                            TopicPartition: topicPartition,
                            Offset: partition.RecordsField.Offset + record.OffsetDelta,
                            LastStableOffset: partition.LastStableOffsetField,
                            LogStartOffset: partition.LogStartOffsetField,
                            HighWatermark: partition.HighWatermarkField,
                            Errors.Known.NONE,
                            Record: new(
                                Timestamp: new(Common.Records.TimestampType.CreateTime, partition.RecordsField.BaseTimestamp + record.TimestampDelta),
                                Headers: record.Headers,
                                Key: key,
                                Value: value
                            )
                        );
                        _results.Enqueue(consumeResult);
                        recordsAdded++;
                    }
                    _topicPartitionOffsets[topicPartition] = offset + 1;
                }
            }
            return recordsAdded;
        }

        async ValueTask<ConsumeResult<TKey, TValue>> IConsumer<TKey, TValue>.Poll(CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                await UpdateSubscriptions(cancellationToken);
                await UpdateQueue(cancellationToken);
                return DequeueResult();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private ConsumeResult<TKey, TValue> DequeueResult()
        {
            var consumeResult = _results.Dequeue();
            _lastConsumedResult[consumeResult.TopicPartition] = consumeResult;
            return consumeResult;
        }

        /// <summary>
        /// Updates queue
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        private async ValueTask UpdateQueue(CancellationToken cancellationToken)
        {
            while (_results.Count == 0)
            {
                var result = await PollFromBrokers(cancellationToken);
                EnqueueResults(result);
            }
        }

        private async ValueTask<FetchResponse> PollFromBrokers(CancellationToken cancellationToken)
        {
            var fetchTopics = _topicPartitionOffsets
                .GroupBy(g => g.Key.Topic.Value ?? "")
                .Select(t =>
                    new FetchRequest.FetchTopic(
                        t.Key,
                        Guid.Empty,
                        t.Select(p =>
                            new FetchRequest.FetchTopic.FetchPartition(
                                PartitionField: p.Key.Partition,
                                CurrentLeaderEpochField: -1,
                                FetchOffsetField: p.Value,
                                LastFetchedEpochField: -1,
                                LogStartOffsetField: -1,
                                PartitionMaxBytesField: 1048576
                            )
                        )
                        .ToImmutableArray()
                    )
                )
                .ToImmutableArray()
            ;

            var request = new FetchRequest(
                ClusterIdField: null,
                ReplicaIdField: -1,
                MaxWaitMsField: 500,
                MinBytesField: 1,
                MaxBytesField: 52428800,
                IsolationLevelField: 1,
                SessionIdField: -1,
                SessionEpochField: -1,
                TopicsField: fetchTopics,
                ForgottenTopicsDataField: ImmutableArray<FetchRequest.ForgottenTopic>.Empty,
                RackIdField: ""
            );
            var response = await HandleRequest(
                request with { MaxVersion = 11 },
                FetchRequestSerde.Write,
                FetchResponseSerde.Read,
                cancellationToken
            );

            return response;
        }

        async ValueTask IConsumer<TKey, TValue>.Subscribe(
            TopicName topic,
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                if (!_topicPartitionOffsets.Keys.Any(r => r.Topic == topic))
                    _subscribeTopics.Add(topic);
                _unsubscribeTopics.Remove(topic);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        async ValueTask IConsumer<TKey, TValue>.Unsubscribe(TopicName topic, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                if (_topicPartitionOffsets.Keys.Any(r => r.Topic == topic))
                    _unsubscribeTopics.Add(topic);
                _subscribeTopics.Remove(topic);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async ValueTask UpdateSubscriptions(CancellationToken cancellationToken)
        {
            // Ensure client is subscribed.
            if (string.IsNullOrEmpty(_subscriptionMetadata.MemberId))
                _subscriptionMetadata = await JoinGroup(
                    _subscriptionMetadata.MemberId,
                    cancellationToken
                );

            var newTopics = UpdateSubscribedTopics();
            if (newTopics.Any())
            {
                var metadataResponse = await TopicMetadata(
                    newTopics,
                    cancellationToken
                );
                var notFound = newTopics.Except(metadataResponse.TopicsField.Select(r => new TopicName(r.NameField)));
                if (notFound.Any())
                    foreach (var topic in notFound)
                        _logger.LogWarning("Unable to find topic: {TopicName}", topic.Value);
                var syncResponse = await SyncGroup(
                    cancellationToken
                );
                var offsetFetchResponse = await FetchOffsets(
                    metadataResponse,
                    cancellationToken
                );
                UpdateFromOffsetFetchResponse(
                    offsetFetchResponse,
                    out var unknownOffsets
                );
                if (unknownOffsets.Any())
                {
                    var offsetListResponse = await ListOffsets(
                        unknownOffsets,
                        Offset.Beginning,
                        cancellationToken
                    );
                    UpdateFromOffsetListResponse(
                        offsetListResponse
                    );
                }
            }
            if (_topicPartitionOffsets.Count == 0)
                throw new Exception("No active partitions");
        }

        private void UpdateFromOffsetListResponse(ListOffsetsResponse offsetListResponse)
        {
            foreach (var topic in offsetListResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    SetTopicPartitionOffset(topic.NameField, partition.PartitionIndexField, partition.OffsetField);
        }

        private ValueTask<ListOffsetsResponse> ListOffsets(
            IEnumerable<TopicPartition> unknownOffsets,
            Offset defaultOffset,
            CancellationToken cancellationToken
        )
        {
            var topics = unknownOffsets
                .GroupBy(g => g.Topic.Value ?? "")
                .Select(t =>
                    new ListOffsetsRequest.ListOffsetsTopic(
                        t.Key,
                        t.Select(r =>
                            new ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition(
                                r.Partition.Value,
                                -1,
                                defaultOffset.Value,
                                1
                            )
                        ).ToImmutableArray()
                    )
                )
                .ToImmutableArray()
            ;
            var request = new ListOffsetsRequest(
                -1,
                1,
                topics
            );
            return HandleRequest(
                request,
                ListOffsetsRequestSerde.Write,
                ListOffsetsResponseSerde.Read,
                cancellationToken
            );
        }

        private IEnumerable<TopicName> UpdateSubscribedTopics()
        {
            // Remove active topic subscriptions.
            var topicsToRemove =
                from tp in _topicPartitionOffsets.Keys
                join ut in _unsubscribeTopics
                on tp.Topic equals ut
                select tp
            ;
            foreach (var topic in topicsToRemove.ToArray())
                _topicPartitionOffsets.Remove(topic);
            _unsubscribeTopics.Clear();

            // Add active topic subscriptions.
            var newTopics = _subscribeTopics
                .Where(t => !_topicPartitionOffsets.Keys.Any(r => r.Topic == t))
                .ToArray()
            ;
            _subscribeTopics.Clear();

            return newTopics;
        }

        private void UpdateFromOffsetFetchResponse(OffsetFetchResponse offsetFetchResponse, out IEnumerable<TopicPartition> unknownOffsets)
        {
            var unkown = new List<TopicPartition>();

            // Check if stored by group. This assumes one and only one group.
            var group = offsetFetchResponse.GroupsField.FirstOrDefault();
            if (group != null)
            {
                foreach (var topic in group.TopicsField)
                {
                    foreach (var partition in topic.PartitionsField)
                    {
                        if (partition.CommittedOffsetField < 0)
                            unkown.Add(new(topic.NameField, partition.PartitionIndexField));
                        else
                            SetTopicPartitionOffset(topic.NameField, partition.PartitionIndexField, partition.CommittedOffsetField);
                    }
                }
            }

            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    if (partition.CommittedOffsetField < 0)
                        unkown.Add(new(topic.NameField, partition.PartitionIndexField));
                    else
                        SetTopicPartitionOffset(topic.NameField, partition.PartitionIndexField, partition.CommittedOffsetField);
                }
            }

            unknownOffsets = unkown;
        }

        private void SetTopicPartitionOffset(string topicName, int partition, long offset)
        {
            var topicPartition = new TopicPartition(topicName, partition);
            _topicPartitionOffsets[topicPartition] = offset;
        }

        ValueTask IConsumer<TKey, TValue>.Assign(TopicPartitionOffset topicPartitionOffset, CancellationToken cancellationToken)
        {
            return default;
        }
        ValueTask IConsumer<TKey, TValue>.Assign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken cancellationToken)
        {
            return default;
        }
        ValueTask IConsumer<TKey, TValue>.UnAssign(TopicPartitionOffset topicPartitionOffset, CancellationToken cancellationToken)
        {
            return default;
        }
        ValueTask IConsumer<TKey, TValue>.UnAssign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken cancellationToken)
        {
            return default;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private async ValueTask LeaveGroup(
            CancellationToken cancellationToken
        )
        {
            var request = CreateLeaveRequest();
            var response = await HandleRequest(
                request,
                LeaveGroupRequestSerde.Write,
                LeaveGroupResponseSerde.Read,
                cancellationToken
            );
            if (response.ErrorCodeField != 0)
            {
                var error = Errors.Translate(response.ErrorCodeField);
                throw new ApiException(error);
            }
        }

        private async ValueTask<SubscriptionMetadata> JoinGroup(
            string memberId,
            CancellationToken cancellationToken
        )
        {
            var request = CreateJoinRequest(memberId);
            var response = await HandleRequest(
                request,
                JoinGroupRequestSerde.Write,
                JoinGroupResponseSerde.Read,
                cancellationToken
            );
            if (response.ErrorCodeField == Errors.Known.MEMBER_ID_REQUIRED.Code)
            {
                request = CreateJoinRequest(response.MemberIdField);
                response = await HandleRequest(
                    request,
                    JoinGroupRequestSerde.Write,
                    JoinGroupResponseSerde.Read,
                    cancellationToken
                );
            }
            if (response.ErrorCodeField != 0)
            {
                var error = Errors.Translate(response.ErrorCodeField);
                throw new ApiException(error);
            }
            return _subscriptionMetadata with
            {
                GenerationId = response.GenerationIdField,
                ProtocolType = response.ProtocolTypeField,
                ProtocolName = response.ProtocolNameField,
                Leader = response.LeaderField,
                SkipAssignment = response.SkipAssignmentField,
                MemberId = response.MemberIdField,
                Members = response.MembersField.Select(r =>
                    new MemberMetadata(
                        r.MemberIdField,
                        r.GroupInstanceIdField,
                        r.MetadataField
                    )
                )
                .ToImmutableArray()
            };
        }

        private async ValueTask<MetadataResponse> TopicMetadata(
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var metadataRequestTopics = topics
                .Select(r => new MetadataRequest.MetadataRequestTopic(
                    Guid.Empty,
                    r.Value
                ))
                .ToImmutableArray()
            ;
            var request = new MetadataRequest(
                metadataRequestTopics,
                false,
                false,
                false
            );
            return await HandleRequest(
                request,
                MetadataRequestSerde.Write,
                MetadataResponseSerde.Read,
                cancellationToken
            );
        }

        private async ValueTask<OffsetFetchResponse> FetchOffsets(
            MetadataResponse metadataResponse,
            CancellationToken cancellationToken
        )
        {
            var topicsToFetch = metadataResponse.TopicsField
                .Select(r => new OffsetFetchRequest.OffsetFetchRequestTopic(
                    r.NameField ?? "",
                    r.PartitionsField
                        .Select(r =>
                            r.PartitionIndexField
                        )
                        .ToImmutableArray()
                ))
                .ToImmutableArray()
            ;
            var topicsInGroupToFetch = metadataResponse.TopicsField
                .Select(r => new OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                    r.NameField ?? "",
                    r.PartitionsField
                        .Select(r =>
                            r.PartitionIndexField
                        )
                        .ToImmutableArray()
                ))
                .ToImmutableArray()
            ;
            var groupsBuilder = ImmutableArray.CreateBuilder<OffsetFetchRequest.OffsetFetchRequestGroup>(1);
            groupsBuilder.Add(new OffsetFetchRequest.OffsetFetchRequestGroup(
                _config.ClientId,
                topicsInGroupToFetch
            ));
            var groupsToFetch = groupsBuilder.ToImmutable();

            var request = new OffsetFetchRequest(
                _config.ClientId,
                topicsToFetch,
                groupsToFetch,
                false
            );
            return await HandleRequest(
                request,
                OffsetFetchRequestSerde.Write,
                OffsetFetchResponseSerde.Read,
                cancellationToken
            );
        }

        private async ValueTask<SyncGroupResponse> SyncGroup(
            CancellationToken cancellationToken
        )
        {
            var assignments = _subscriptionMetadata.Members
                .Select(r => new SyncGroupRequest.SyncGroupRequestAssignment(
                    r.MemberId,
                    r.Metadata
                ))
                .ToImmutableArray()
            ;
            var request = new SyncGroupRequest(
                _subscriptionMetadata.GroupId,
                _subscriptionMetadata.GenerationId,
                _subscriptionMetadata.MemberId,
                _subscriptionMetadata.InstanceId,
                _subscriptionMetadata.ProtocolType,
                _subscriptionMetadata.ProtocolName,
                assignments
            );
            return await HandleRequest(
                request,
                SyncGroupRequestSerde.Write,
                SyncGroupResponseSerde.Read,
                cancellationToken
            );
        }

        private static IDeserializer<TKey> GetKeyDeserializer(
            ConsumerConfig producerConfig
        ) =>
            Resolve<IDeserializer<TKey>>(
                producerConfig.KeyDeserializer
            )
        ;

        private static IDeserializer<TValue> GetValueDeserializer(
            ConsumerConfig producerConfig
        ) =>
            Resolve<IDeserializer<TValue>>(
                producerConfig.ValueDeserializer
            )
        ;

        private static TType Resolve<TType>(
            string fullName
        )
        {
            var type = Type.GetType(fullName);
            if (type == null)
                throw new TypeLoadException(fullName);
            if (!typeof(TType).IsAssignableFrom(type))
                throw new TypeLoadException(fullName);
            var instance = Activator.CreateInstance(type);
            if (instance == null)
                throw new TypeLoadException(fullName);
            return (TType)instance;
        }

        private JoinGroupRequest CreateJoinRequest(
            string memberId
        )
        {
            return new JoinGroupRequest(
                _subscriptionMetadata.GroupId,
                45000,
                300000,
                memberId,
                _subscriptionMetadata.InstanceId,
                "consumer",
                new[]
                {
                    new JoinGroupRequest.JoinGroupRequestProtocol(
                        "range",
                        ReadOnlyMemory<byte>.Empty
                    )
                }.ToImmutableArray(),
                null
            );
        }

        private LeaveGroupRequest CreateLeaveRequest()
        {
            return new LeaveGroupRequest(
                _subscriptionMetadata.GroupId,
                _subscriptionMetadata.MemberId,
                ImmutableArray<LeaveGroupRequest.MemberIdentity>.Empty
            );
        }

        async ValueTask IConsumer<TKey, TValue>.Close(CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                _internalCts.Cancel();
                await _autoCommitterTask;
                if (!string.IsNullOrEmpty(_subscriptionMetadata.MemberId))
                    await LeaveGroup(cancellationToken);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private sealed record SubscriptionMetadata(
            string GroupId,
            string? InstanceId,
            int GenerationId,
            string? ProtocolType,
            string? ProtocolName,
            string Leader,
            bool SkipAssignment,
            string MemberId,
            ImmutableArray<MemberMetadata> Members
        )
        {
            public static SubscriptionMetadata Empty { get; } = new(
                "",
                null,
                -1,
                null,
                null,
                "",
                false,
                "",
                ImmutableArray<MemberMetadata>.Empty
            );
        }

        private sealed record MemberMetadata(
            string MemberId,
            string? GroupInstanceId,
            ReadOnlyMemory<byte> Metadata
        );

        private readonly record struct ConsumeCommitPair(
            ConsumeResult<TKey, TValue> ConsumeResult,
            CommitOffset CommitOffset
        );

        private sealed record CommitOffset(

        );
    }
}
