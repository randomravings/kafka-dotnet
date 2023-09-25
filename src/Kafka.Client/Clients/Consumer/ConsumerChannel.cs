using Kafka.Client.Clients.Consumer.Logging;
using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using static Kafka.Client.Messages.FetchRequestData;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class ConsumerChannel :
        IConsumerChannel
    {
        private readonly ClusterNodeId _nodeId;
        private readonly IConsumerProtocol _protocol;
        private readonly ConcurrentQueue<FetchResultEnumerator> _fetchCallbacks;
        private readonly SortedList<TopicPartition, Offset> _topicPartitionOffsets;
        private readonly int _fetchMaxWaitMs;
        private readonly int _fetchMinBytes;
        private readonly int _fetchMaxBytes;
        private readonly sbyte _isolationLevel;
        private readonly string _clientRack;
        private readonly int _maxPartitionFetchBytes;
        private readonly AutoOffsetReset _autoOffsetReset;
        private Task _task = Task.CompletedTask;
        private readonly ILogger _logger;
        private readonly ManualResetEventSlim _resetEvent;
        private CancellationTokenSource _cancellationTokenSource;

        public ConsumerChannel(
            ClusterNodeId nodeId,
            IConsumerProtocol protocol,
            ConcurrentQueue<FetchResultEnumerator> fetchCallbacks,
            ManualResetEventSlim resetEvent,
            ConsumerConfig config,
            ILogger logger
        )
        {
            _nodeId = nodeId;
            _protocol = protocol;
            _resetEvent = resetEvent;
            _fetchCallbacks = fetchCallbacks;
            _fetchMaxWaitMs = config.FetchMaxWaitMs;
            _fetchMinBytes = config.FetchMinBytes;
            _fetchMaxBytes = config.FetchMaxBytes;
            _isolationLevel = (sbyte)config.IsolationLevel;
            _clientRack = config.ClientRack;
            _maxPartitionFetchBytes = config.MaxPartitionFetchBytes;
            _autoOffsetReset = config.AutoOffsetReset;
            _logger = logger;
            _topicPartitionOffsets = new(TopicPartitionCompare.Instance);
            _cancellationTokenSource= new();
        }

        ClusterNodeId IConsumerChannel.NodeId => _protocol.NodeId;

        IReadOnlyList<TopicPartition> IConsumerChannel.Assignments => _topicPartitionOffsets.Keys.ToImmutableList();

        async Task IConsumerChannel.Start(
            IReadOnlyDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            await EnsureOffsets(
                topicPartitionOffsets,
                cancellationToken
            ).ConfigureAwait(false);
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken
            );
            _task = Task.Run(
                async () => await FetchLoop(cancellationToken).ConfigureAwait(false),
                CancellationToken.None
            );
            _logger.ConsumerChannelStart(
                _nodeId,
                _topicPartitionOffsets.Keys.Select(r => $"{r.Topic.TopicName.Value}:{r.Partition.Value}")
            );
        }

        async Task IConsumerChannel.Stop(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _cancellationTokenSource.Cancel();
            await _task.ConfigureAwait(false);
        }

        private async Task EnsureOffsets(
            IReadOnlyDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            _topicPartitionOffsets.Clear();
            foreach (var topicPartitionOffset in topicPartitionOffsets)
                _topicPartitionOffsets.Add(topicPartitionOffset.Key, topicPartitionOffset.Value);
            var timestampField = _autoOffsetReset == AutoOffsetReset.Earliest ?
                Offset.Beginning.Value :
                Offset.End.Value
            ;
            var missingOffsets = _topicPartitionOffsets
                .Where(r => r.Value < 0)
                .Select(r => r.Key)
                .ToImmutableSortedDictionary(
                    k => k,
                    v => timestampField,
                    TopicPartitionCompare.Instance
                )
            ;
            if (missingOffsets.Count == 0)
                return;
            var listOffsetsRequest = CreateListOffsetsRequest(
                missingOffsets
            );
            var listOffsetsResponse = await _protocol.ListOffsets(
                listOffsetsRequest,
                cancellationToken
            ).ConfigureAwait(false);
            UpdateTopicPartitionOffsets(
                _topicPartitionOffsets,
                listOffsetsResponse
            );
        }

        private async Task FetchLoop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var fetchRequest = CreateFetchRequest();
                    var fetchResponse = await _protocol.Fetch(
                        fetchRequest,
                        cancellationToken
                    ).ConfigureAwait(false);

                    var fetchRecords = Flatten(fetchResponse);
                    if (fetchRecords.Length == 0)
                        continue;

                    var taskCompletionSource = new TaskCompletionSource();
                    _fetchCallbacks.Enqueue(new(fetchRecords, SetReadOffset, taskCompletionSource));
                    _resetEvent.Set();
                    await taskCompletionSource
                        .Task
                        .WaitAsync(cancellationToken)
                        .ConfigureAwait(false)
                    ;
                }
                catch (TaskCanceledException) { }
                catch (OperationCanceledException) { }
            }
            _logger.FetchLoopStop();
        }

        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
        }

        private void SetReadOffset(RawConsumerRecord rawConsumerRecord) =>
            _topicPartitionOffsets[rawConsumerRecord.TopicPartition] = rawConsumerRecord.Offset + 1
        ;

        private ImmutableArray<RawConsumerRecord> Flatten(FetchResponseData fetchResponse)
        {
            var flattenBuilder = ImmutableArray.CreateBuilder<RawConsumerRecord>();
            foreach (var response in fetchResponse.ResponsesField)
            {
                var topic = new Topic(response.TopicIdField, response.TopicField);
                foreach (var partition in response.PartitionsField)
                {
                    var partitionRecords = partition.RecordsField;
                    if (partitionRecords == null || partitionRecords.Value.Length == 0)
                        continue;
                    foreach (var records in partitionRecords)
                    {
                        var topicPartition = new TopicPartition(topic, partition.PartitionIndexField);
                        if (records.Attributes.HasFlag(Attributes.IsControlBatch))
                        {
                            _topicPartitionOffsets[topicPartition] = records.BaseSequence + 1;
                            continue;
                        }
                        if (partition.ErrorCodeField > 0)
                        {
                            var errorRecord = new RawConsumerRecord(
                                topicPartition,
                                _topicPartitionOffsets[topicPartition],
                                Timestamp.None,
                                null,
                                null,
                                ImmutableArray<RecordHeader>.Empty,
                                Errors.Translate(partition.ErrorCodeField)
                            );
                            flattenBuilder.Add(errorRecord);
                        }
                        for (int i = 0; i < records.Count; i++)
                        {
                            var record = records[i];
                            var offset = records.BaseOffset + i;
                            var timestamp = records.BaseTimestamp + record.TimestampDelta;
                            var rawConsumerRecord = new RawConsumerRecord(
                                TopicPartition: topicPartition,
                                Offset: offset,
                                Timestamp: records.Attributes.HasFlag(Attributes.LogAppendTime) ? Timestamp.LogAppend(timestamp) : Timestamp.Created(timestamp),
                                Key: record.Key,
                                Value: record.Value,
                                Headers: record.Headers,
                                Error: Errors.Known.NONE
                            );
                            flattenBuilder.Add(rawConsumerRecord);
                        }
                    }
                }
            }
            return flattenBuilder.ToImmutable();
        }

        private FetchRequestData CreateFetchRequest()
        {
            var fetchTopics = _topicPartitionOffsets
                .GroupBy(g => g.Key.Topic)
                .Select(t =>
                    new FetchTopic(
                        t.Key.TopicName,
                        t.Key.TopicId,
                        t.Select(tp =>
                            new FetchTopic.FetchPartition(
                                PartitionField: tp.Key.Partition,
                                CurrentLeaderEpochField: -1,
                                FetchOffsetField: tp.Value,
                                LastFetchedEpochField: -1,
                                LogStartOffsetField: -1,
                                PartitionMaxBytesField: _maxPartitionFetchBytes,
                                ImmutableArray<TaggedField>.Empty
                            )
                        )
                        .ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )
                )
                .ToImmutableArray()
            ;
            return new(
                ClusterIdField: null,
                ReplicaIdField: -1,
                ReplicaStateField: ReplicaState.Empty,
                MaxWaitMsField: _fetchMaxWaitMs,
                MinBytesField: _fetchMinBytes,
                MaxBytesField: _fetchMaxBytes,
                IsolationLevelField: _isolationLevel,
                SessionIdField: 0,
                SessionEpochField: -1,
                TopicsField: fetchTopics,
                ForgottenTopicsDataField: ImmutableArray<ForgottenTopic>.Empty,
                RackIdField: _clientRack,
                ImmutableArray<TaggedField>.Empty
            );
        }

        private ListOffsetsRequestData CreateListOffsetsRequest(
            IReadOnlyDictionary<TopicPartition, long> topicPartitionOffsets
        ) =>
            new(
                _nodeId.Value,
                _isolationLevel,
                topicPartitionOffsets
                    .GroupBy(r => r.Key.Topic)
                    .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                        t.Key.TopicName,
                        t.Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                            p.Key.Partition.Value,
                            -1,
                            p.Value,
                            1,
                            ImmutableArray<TaggedField>.Empty
                        )).ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )).ToImmutableArray(),
                ImmutableArray<TaggedField>.Empty
            )
        ;

        private static void UpdateTopicPartitionOffsets(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            ListOffsetsResponseData offsetListResponse
        )
        {
            foreach (var topic in offsetListResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.OffsetField;
        }
    }
}
