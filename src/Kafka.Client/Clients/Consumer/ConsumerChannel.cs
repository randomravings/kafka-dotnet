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
        private bool _running;
        private readonly ILogger _logger;
        private readonly ManualResetEventSlim _resetEvent;

        public ConsumerChannel(
            ClusterNodeId nodeId,
            IConsumerProtocol protocol,
            ImmutableSortedDictionary<TopicPartition, Offset> topicPartitionOffsets,
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
            _topicPartitionOffsets = new SortedList<TopicPartition, Offset>(
                topicPartitionOffsets,
                TopicPartitionCompare.Instance
            );
        }

        async Task IConsumerChannel.Start(
            CancellationToken cancellationToken
        )
        {
            _logger.ConsumerChannelStart(_nodeId, _topicPartitionOffsets.Keys.Select(r => $"{r.Topic.TopicName.Value}:{r.Partition.Value}"));
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
                        ForgottenTopicsDataField: ImmutableArray<ForgottenTopic>.Empty,
                        RackIdField: _clientRack,
                        ImmutableArray<TaggedField>.Empty
                    );
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
    }
}
