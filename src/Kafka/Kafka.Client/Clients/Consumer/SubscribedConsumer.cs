using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Exceptions;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Clients.Consumer
{
    public sealed class SubscribedConsumer<TKey, TValue> :
        Client<ConsumerConfig>,
        IConsumer<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private bool _disposed = false;

        public SubscribedConsumer(
            ConsumerConfig config,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger<IConsumer<TKey, TValue>> logger
        ) : base(config, logger)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        private async Task HeartBeatLoop(SubscriptionMetadata subscriptionMetadata, CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.WaitHandle.WaitOne(5000);
                    if (string.IsNullOrEmpty(subscriptionMetadata.MemberId))
                        continue;
                    var request = new HeartbeatRequest(
                        subscriptionMetadata.GroupId,
                        subscriptionMetadata.GenerationId,
                        subscriptionMetadata.MemberId,
                        subscriptionMetadata.GroupInstanceId
                    );
                    var response = await HandleRequest(
                        request,
                        HeartbeatRequestSerde.Write,
                        HeartbeatResponseSerde.Read,
                        cancellationToken
                    );

                    if (response.ErrorCodeField != 0)
                    {
                        var error = Errors.Translate(response.ErrorCodeField);
                        _logger.LogWarning($"{error}");
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        private async Task CommitLoop(ConcurrentQueue<ConsumeResult<TKey, TValue>> commitQueue, SubscriptionMetadata subscriptionMetadata, CancellationToken cancellationToken)
        {
            try
            {
                var commitState = new Dictionary<TopicPartition, Offset>();
                while (!cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.WaitHandle.WaitOne(_config.AutoCommitIntervalMs);
                    var count = commitQueue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (commitQueue.TryDequeue(out var result))
                            commitState[result.TopicPartition] = result.Offset.Value + 1;
                        else
                            break;
                    }
                    if (commitState.Count == 0)
                        continue;

                    var offsetCommitRequestTopic = commitState
                        .GroupBy(g => g.Key.Topic)
                        .Select(t =>
                            new OffsetCommitRequest.OffsetCommitRequestTopic(
                                t.Key.Value ?? "",
                                t.Select(p =>
                                    new OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition(
                                        p.Key.Partition,
                                        p.Value,
                                        -1,
                                        Timestamp.Now().TimestampMs,
                                        null
                                    )
                                ).ToImmutableArray()
                            )
                        )
                        .ToImmutableArray()
                    ;
                    var request = new OffsetCommitRequest(
                        subscriptionMetadata.GroupId,
                        subscriptionMetadata.GenerationId,
                        subscriptionMetadata.MemberId,
                        subscriptionMetadata.GroupInstanceId,
                        -1,
                        offsetCommitRequestTopic
                    );
                    commitState.Clear();
                    var response = await HandleRequest(
                        request,
                        OffsetCommitRequestSerde.Write,
                        OffsetCommitResponseSerde.Read,
                        cancellationToken
                    );
                    commitState.Clear();
                }
            }
            catch (OperationCanceledException) { }
        }

        private async ValueTask<FetchResponse> Fetch(SortedList<TopicPartition, Offset> topicPartitionOffsets, CancellationToken cancellationToken)
        {
            var fetchTopics = topicPartitionOffsets
                .GroupBy(g => g.Key.Topic)
                .Select(t =>
                    new FetchRequest.FetchTopic(
                        t.Key.Value ?? "",
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

        private static SortedList<TopicPartition, Offset> CreateTopicPartitionOffsets(MetadataResponse metadataResponse)
        {
            var topicPartitionOffsets = new SortedList<TopicPartition, Offset>(TopicPartitionCompare.Instance);
            foreach (var topic in metadataResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = Offset.Unset;
            return topicPartitionOffsets;
        }

        private static void UpdateFromOffsetListResponse(SortedList<TopicPartition, Offset> topicPartitionOffsets, ListOffsetsResponse offsetListResponse)
        {
            foreach (var topic in offsetListResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.OffsetField;
        }

        private static void UpdateFromOffsetFetchResponse(SortedList<TopicPartition, Offset> topicPartitionOffsets, OffsetFetchResponse offsetFetchResponse)
        {
            // Check if stored by group. This assumes one and only one group.
            var group = offsetFetchResponse.GroupsField.FirstOrDefault();
            if (group != null)
            {
                foreach (var topic in group.TopicsField)
                {
                    foreach (var partition in topic.PartitionsField)
                    {
                        var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                        if (partition.CommittedOffsetField >= 0)
                            topicPartitionOffsets[topicPartition] = partition.CommittedOffsetField;
                    }
                }
            }

            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                    if (partition.CommittedOffsetField >= 0)
                        topicPartitionOffsets[topicPartition] = partition.CommittedOffsetField;
                }
            }
        }

        private ValueTask<ListOffsetsResponse> ListOffsets(
            IEnumerable<TopicPartition> topicPartitions,
            Offset defaultOffset,
            CancellationToken cancellationToken
        )
        {
            var topics = topicPartitions
                .GroupBy(g => g.Topic)
                .Select(t =>
                    new ListOffsetsRequest.ListOffsetsTopic(
                        t.Key.Value ?? "",
                        t.Select(r =>
                            new ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition(
                                r.Partition,
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

        private async ValueTask LeaveGroup(
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            var request = CreateLeaveRequest(subscriptionMetadata);
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
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            var metadata = subscriptionMetadata;
            var request = CreateJoinRequest(metadata);
            var response = await HandleRequest(
                request,
                JoinGroupRequestSerde.Write,
                JoinGroupResponseSerde.Read,
                cancellationToken
            );
            if (response.ErrorCodeField == Errors.Known.MEMBER_ID_REQUIRED.Code)
            {
                metadata = metadata with { MemberId = response.MemberIdField };
                request = CreateJoinRequest(metadata);
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
            return subscriptionMetadata with
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
            ImmutableArray<TopicName> topics,
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
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        )
        {
            var topicsToFetch = topicPartitions
                .GroupBy(g => g.Topic)
                .Select(r => new OffsetFetchRequest.OffsetFetchRequestTopic(
                    r.Key.Value ?? "",
                    r.Select(r =>
                        r.Partition.Value
                    )
                    .ToImmutableArray()
                ))
                .ToImmutableArray()
            ;

            var topicsInGroupToFetch = topicPartitions
                .GroupBy(g => g.Topic)
                .Select(r => new OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                    r.Key.Value ?? "",
                    r.Select(r =>
                        r.Partition.Value
                    )
                    .ToImmutableArray()
                ))
                .ToImmutableArray()
            ;
            var groupsBuilder = ImmutableArray.CreateBuilder<OffsetFetchRequest.OffsetFetchRequestGroup>(1);
            groupsBuilder.Add(new OffsetFetchRequest.OffsetFetchRequestGroup(
                _config.GroupId ?? "",
                topicsInGroupToFetch
            ));
            var groupsToFetch = groupsBuilder.ToImmutable();

            var request = new OffsetFetchRequest(
                _config.GroupId ?? "",
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
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            var assignments = subscriptionMetadata.Members
                .Select(r => new SyncGroupRequest.SyncGroupRequestAssignment(
                    r.MemberId,
                    r.Metadata
                ))
                .ToImmutableArray()
            ;
            var request = new SyncGroupRequest(
                subscriptionMetadata.GroupId,
                subscriptionMetadata.GenerationId,
                subscriptionMetadata.MemberId,
                subscriptionMetadata.GroupInstanceId,
                subscriptionMetadata.ProtocolType,
                subscriptionMetadata.ProtocolName,
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
            SubscriptionMetadata subscriptionMetadata
        )
        {
            return new JoinGroupRequest(
                subscriptionMetadata.GroupId,
                45000,
                300000,
                subscriptionMetadata.MemberId,
                subscriptionMetadata.GroupInstanceId,
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

        private LeaveGroupRequest CreateLeaveRequest( SubscriptionMetadata subscriptionMetadata)
        {
            return new LeaveGroupRequest(
                subscriptionMetadata.GroupId,
                subscriptionMetadata.MemberId,
                ImmutableArray<LeaveGroupRequest.MemberIdentity>.Empty
            );
        }

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionWatermark>>> IConsumer<TKey, TValue>.QueryWatermarks(TopicList topics, CancellationToken cancellationToken)
        {
            var newTopics = topics
                .Names
                .Where(r => !string.IsNullOrEmpty(r.Value))
                .ToImmutableArray()
            ;
            var metadataResponse = await TopicMetadata(newTopics, cancellationToken);
            var topicPartitions = CreateTopicPartitionOffsets(metadataResponse);

            var lowListOffsetsResponse = await ListOffsets(
                topicPartitions.Keys,
                Offset.Beginning,
                cancellationToken
            );
            var lowWatermarks = GetTopicPartitionOffsets(lowListOffsetsResponse);

            var highListOffsetsResponse = await ListOffsets(
                topicPartitions.Keys,
                Offset.End,
                cancellationToken
            );
            var highWatermarks = GetTopicPartitionOffsets(highListOffsetsResponse);

            var fetchOffsetsResponse = await FetchOffsets(
                topicPartitions.Keys,
                cancellationToken
            );
            var storedOffsets = GetTopicPartitionOffsets(fetchOffsetsResponse);

            var topicWatermarksBuilder = ImmutableSortedDictionary.CreateBuilder<TopicName, ImmutableArray<PartitionWatermark>>(TopicNameCompare.Instance);
            foreach (var topic in topicPartitions.Keys.GroupBy(g => g.Topic))
            {
                var partitionWatermarksBuilder = ImmutableArray.CreateBuilder<PartitionWatermark>(topic.Count());
                foreach (var partition in topic)
                {
                    var low = highWatermarks[topic.Key][partition.Partition];
                    var high = lowWatermarks[topic.Key][partition.Partition];
                    var stored = storedOffsets[topic.Key][partition.Partition];
                    partitionWatermarksBuilder.Add(
                        new(
                            partition.Partition,
                            low,
                            high,
                            stored
                        )
                    );
                }
                topicWatermarksBuilder.Add(topic.Key, partitionWatermarksBuilder.ToImmutable());
            }
            return topicWatermarksBuilder.ToImmutable();
        }

        private sealed record SubscriptionMetadata(
            string GroupId,
            string? GroupInstanceId,
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

        private static ImmutableSortedDictionary<TopicName, ImmutableSortedDictionary<Partition, Offset>> GetTopicPartitionOffsets(ListOffsetsResponse listOffsetsResponse) =>
            listOffsetsResponse
                .TopicsField
                .ToImmutableSortedDictionary(
                    k => new TopicName(k.NameField),
                    v => v.PartitionsField.ToImmutableSortedDictionary(
                        k => new Partition(k.PartitionIndexField),
                        v => new Offset(v.OffsetField),
                        PartitionCompare.Instance
                    ),
                    TopicNameCompare.Instance
                )
            ;

        private static ImmutableSortedDictionary<TopicName, ImmutableSortedDictionary<Partition, Offset>> GetTopicPartitionOffsets(OffsetFetchResponse offsetFetchResponse)
        {
            var storedOffsetsBuilder = ImmutableSortedDictionary.CreateBuilder<TopicName, ImmutableSortedDictionary<Partition, Offset>>(TopicNameCompare.Instance);
            // Check if stored by group. This assumes one and only one group.
            var group = offsetFetchResponse.GroupsField.FirstOrDefault();
            if (group != null)
            {
                foreach (var topic in group.TopicsField)
                {
                    var partitionOffsetsBuilder = ImmutableSortedDictionary.CreateBuilder<Partition, Offset>(PartitionCompare.Instance);
                    foreach (var partition in topic.PartitionsField)
                        partitionOffsetsBuilder.Add(new Partition(partition.PartitionIndexField), new Offset(partition.CommittedOffsetField));
                    storedOffsetsBuilder.Add(new TopicName(topic.NameField), partitionOffsetsBuilder.ToImmutable());
                }
            }
            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
            {
                var partitionOffsetsBuilder = ImmutableSortedDictionary.CreateBuilder<Partition, Offset>(PartitionCompare.Instance);
                foreach (var partition in topic.PartitionsField)
                    partitionOffsetsBuilder.Add(new Partition(partition.PartitionIndexField), new Offset(partition.CommittedOffsetField));
                storedOffsetsBuilder.Add(new TopicName(topic.NameField), partitionOffsetsBuilder.ToImmutable());
            }
            return storedOffsetsBuilder.ToImmutable();
        }

        private async ValueTask<ImmutableArray<FetchResponse.FetchableTopicResponse>> FetchUntilCancelled(SortedList<TopicPartition, Offset> topicPartitionOffsets, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var response = await Fetch(topicPartitionOffsets, cancellationToken)
                        .ConfigureAwait(false)
                    ;
                    // Todo Error handling.
                    if(response.ResponsesField.Length > 0)
                        return response.ResponsesField;
                }
                catch (OperationCanceledException) { }
            }
            return ImmutableArray<FetchResponse.FetchableTopicResponse>.Empty;
        }

        async IAsyncEnumerable<ConsumeResult<TKey, TValue>> IConsumer<TKey, TValue>.Read(TopicList topics, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var newTopics = topics
                .Names
                .Where(r => !string.IsNullOrEmpty(r.Value))
                .ToImmutableArray()
            ;
            var subscriptionMetadata = SubscriptionMetadata.Empty with
            {
                GroupId = _config.GroupId ?? "",
                GroupInstanceId = _config.GroupInstanceId,
            };
            var autoCommitterTask = Task.CompletedTask;
            var hearbeatTask = Task.CompletedTask;
            if (!newTopics.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topics));
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                subscriptionMetadata = await JoinGroup(subscriptionMetadata, cancellationToken);
                var metadataResponse = await TopicMetadata(
                    newTopics,
                    cancellationToken
                );
                var notFoundTopics = newTopics.Except(metadataResponse.TopicsField.Select(r => new TopicName(r.NameField)));
                if (notFoundTopics.Any())
                    foreach (var notFoundTopic in notFoundTopics)
                        _logger.LogWarning("Unable to find topic: {TopicName}", notFoundTopic);
                if (metadataResponse.TopicsField.IsEmpty)
                    throw new Exception("No topics to subscribe to");
                var syncResponse = await SyncGroup(
                    subscriptionMetadata,
                    cancellationToken
                );
                var topicPartitionOffsets = CreateTopicPartitionOffsets(metadataResponse);
                var offsetFetchResponse = await FetchOffsets(
                    topicPartitionOffsets.Keys,
                    cancellationToken
                );
                UpdateFromOffsetFetchResponse(
                    topicPartitionOffsets,
                    offsetFetchResponse
                );
                var unsetTopicPartitions = topicPartitionOffsets
                    .Where(r => r.Value == Offset.Unset)
                    .Select(r => r.Key)
                ;
                if (unsetTopicPartitions.Any())
                {
                    var offsetListResponse = await ListOffsets(
                        unsetTopicPartitions,
                        Offset.Beginning,
                        cancellationToken
                    );
                    UpdateFromOffsetListResponse(
                        topicPartitionOffsets,
                        offsetListResponse
                    );
                }
                var commitQueue = new ConcurrentQueue<ConsumeResult<TKey, TValue>>();
                autoCommitterTask = Task.Run(async () => await CommitLoop(commitQueue, subscriptionMetadata, cancellationToken), CancellationToken.None);
                hearbeatTask = Task.Run(async () => await HeartBeatLoop(subscriptionMetadata, cancellationToken), CancellationToken.None);

                while (!cancellationToken.IsCancellationRequested)
                {
                    var fetchableTopicResponses = await FetchUntilCancelled(topicPartitionOffsets, cancellationToken);
                    foreach (var topic in fetchableTopicResponses)
                    {
                        foreach (var partition in topic.PartitionsField)
                        {
                            var topicPartition = new TopicPartition(topic.TopicField, partition.PartitionIndexField);
                            if (partition.ErrorCodeField != 0)
                                throw new ApiException(Errors.Translate(partition.ErrorCodeField));
                            if (partition.RecordsField == null)
                                continue;
                            foreach (var records in partition.RecordsField)
                            {
                                foreach (var record in records)
                                {
                                    var offset = records.Offset + record.OffsetDelta;
                                    var timestamp = records.BaseTimestamp + record.TimestampDelta;
                                    var key = _keyDeserializer.Read(record.Key);
                                    var value = _valueDeserializer.Read(record.Value);
                                    var consumeResult = new ConsumeResult<TKey, TValue>(
                                        TopicPartition: topicPartition,
                                        Offset: offset,
                                        LastStableOffset: partition.LastStableOffsetField,
                                        LogStartOffset: partition.LogStartOffsetField,
                                        HighWatermark: partition.HighWatermarkField,
                                        Errors.Known.NONE,
                                        Record: new(
                                            Timestamp: new(Common.Records.TimestampType.CreateTime, timestamp),
                                            Headers: record.Headers,
                                            Key: key,
                                            Value: value
                                        )
                                    );
                                    yield return consumeResult;
                                    topicPartitionOffsets[topicPartition] = offset + 1;
                                    commitQueue.Enqueue(consumeResult);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                try
                {
                    await LeaveGroup(subscriptionMetadata, _internalCts.Token);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception duing leave: {ex}", ex);
                }
                _semaphore.Release();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _internalCts.Dispose();
                    _semaphore.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        protected override async ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            await ValueTask.CompletedTask;
        }
    }
}
