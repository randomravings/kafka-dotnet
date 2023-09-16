using Kafka.Client.Clients.Consumer.Logging;
using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
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
        private readonly BlockingCollection<FetchResultEnumerator> _fetchCallbacks;
        private readonly SortedList<TopicPartition, Offset> _topicPartitionOffsets;
        private readonly int _fetchMaxWaitMs;
        private readonly int _fetchMinBytes;
        private readonly int _fetchMaxBytes;
        private readonly sbyte _isolationLevel;
        private readonly string _clientRack;
        private readonly int _maxPartitionFetchBytes;
        private readonly AutoOffsetReset _autoOffsetReset;
        private Task _task = Task.CompletedTask;
        private bool _running;
        private readonly ILogger _logger;

        public ConsumerChannel(
            ClusterNodeId nodeId,
            IConsumerProtocol protocol,
            ImmutableSortedDictionary<TopicPartition, Offset> topicPartitionOffsets,
            BlockingCollection<FetchResultEnumerator> fetchCallbacks,
            ConsumerConfig config,
            ILogger logger
        )
        {
            _nodeId = nodeId;
            _protocol = protocol;
            _fetchCallbacks = fetchCallbacks;
            _fetchMaxWaitMs = config.FetchMaxWaitMs;
            _fetchMinBytes = config.FetchMinBytes;
            _fetchMaxBytes = config.FetchMaxBytes;
            _isolationLevel = (sbyte)config.IsolationLevel;
            _clientRack = config.ClientRack;
            _maxPartitionFetchBytes = config.MaxPartitionFetchBytes;
            _autoOffsetReset = config.AutoOffsetReset;
            _logger = logger;
            _topicPartitionOffsets = new SortedList<TopicPartition, Offset>(
                topicPartitionOffsets,
                TopicPartitionCompare.Instance
            );
        }

        async Task IConsumerChannel.Start(
            CancellationToken cancellationToken
        )
        {
            _running = true;
            await CheckState(cancellationToken).ConfigureAwait(false);
            _task = Task.Run(async () => await FetchLoop(cancellationToken).ConfigureAwait(false), CancellationToken.None);
        }

        async Task IConsumerChannel.Stop(CancellationToken cancellationToken)
        {
            _running = false;
            cancellationToken.ThrowIfCancellationRequested();
            await _task.ConfigureAwait(false);
        }

        Task IConsumerChannel.Seek(TopicPartition topicPartition, DateTimeOffset timestamp)
        {
            throw new NotImplementedException();
        }

        Task IConsumerChannel.Seek(TopicPartition topicPartition, Offset offset)
        {
            throw new NotImplementedException();
        }

        private async Task CheckState(CancellationToken cancellationToken)
        {
            var missingOffsets = _topicPartitionOffsets
                .Where(r => r.Value < 0)
                .ToImmutableArray()
            ;

            if (missingOffsets.Length > 0)
            {
                var listOffsetsRequest = new ListOffsetsRequestData(
                    _nodeId.Value,
                    _isolationLevel,
                    missingOffsets
                        .GroupBy(r => r.Key.Topic)
                        .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                            t.Key.TopicName,
                            t.Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                                p.Key.Partition.Value,
                                -1,
                                _autoOffsetReset == AutoOffsetReset.Latest ? Offset.Beginning.Value : Offset.End.Value,
                                1,
                                ImmutableArray<TaggedField>.Empty
                            )).ToImmutableArray(),
                            ImmutableArray<TaggedField>.Empty
                        )).ToImmutableArray(),
                    ImmutableArray<TaggedField>.Empty
                );
                var listOffsetsResponse = await _protocol.ListOffsets(
                    listOffsetsRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                foreach (var topic in listOffsetsResponse.TopicsField)
                {
                    foreach (var partition in topic.PartitionsField)
                    {
                        var key = _topicPartitionOffsets.Keys.First(r => r.Topic.TopicName == topic.NameField && r.Partition == partition.PartitionIndexField);
                        _topicPartitionOffsets[key] = partition.OffsetField;
                    }
                }
            }
        }

        private async Task FetchLoop(CancellationToken cancellationToken)
        {
            while (_running && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var fetchTopics = _topicPartitionOffsets
                        .GroupBy(g => g.Key.Topic)
                        .Select(t =>
                            new FetchRequestData.FetchTopic(
                                t.Key.TopicName,
                                t.Key.TopicId,
                                t.Select(tp =>
                                    new FetchRequestData.FetchTopic.FetchPartition(
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
                    var fetchRequest = new FetchRequestData(
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
                        ForgottenTopicsDataField: ImmutableArray<FetchRequestData.ForgottenTopic>.Empty,
                        RackIdField: _clientRack,
                        ImmutableArray<TaggedField>.Empty
                    );
                    var fetchResponse = await _protocol.Fetch(
                        fetchRequest,
                        cancellationToken
                    ).ConfigureAwait(false);

                    var fetchRecords = CheckResult(fetchResponse);
                    if (fetchRecords.Length == 0)
                        continue;

                    var taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                    _fetchCallbacks.Add(new(fetchRecords, SetReadOffset, taskCompletionSource), cancellationToken);
                    await taskCompletionSource.Task.ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    _logger.FetchLoopStop();
                }
            }
        }

        private void SetReadOffset(TopicPartition topicPartition, Offset offset) =>
            _topicPartitionOffsets[topicPartition] = offset + 1
        ;

        private ImmutableArray<FetchRecords> CheckResult(FetchResponseData fetchResponse)
        {
            var flattenBuilder = ImmutableArray.CreateBuilder<FetchRecords>();
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
                            _topicPartitionOffsets[topicPartition] = records.BaseSequence + 1;
                        else
                            flattenBuilder.Add(new(topicPartition, records, partition.ErrorCodeField));
                    }
                }
            }
            return flattenBuilder.ToImmutable();
        }
    }
}
