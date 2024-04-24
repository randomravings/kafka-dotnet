using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Read
{
    internal sealed class ReadChannel(
        NodeId nodeId,
        ReadStreamConfig config,
        ILogger logger
    )
    {
        private readonly NodeId _nodeId = nodeId;
        private readonly int _fetchMaxWaitMs = config.FetchMaxWaitMs;
        private readonly int _fetchMinBytes = config.FetchMinBytes;
        private readonly int _fetchMaxBytes = config.FetchMaxBytes;
        private readonly sbyte _isolationLevel = (sbyte)config.IsolationLevel;
        private readonly string _clientRack = config.ClientRack;
        private readonly int _maxPartitionFetchBytes = config.MaxPartitionFetchBytes;
        private readonly ILogger _logger = logger;

        public async Task Run(
            INodeLink connection,
            ImmutableTopicPartitionMap<TopicPartitionReadState> topicPartitionOffsets,
            ConcurrentQueue<FetchResult> queue,
            ManualResetEventSlim resetEvent,
            CancellationToken cancellationToken
        )
        {
            _logger.FetchLoopStart(_nodeId);
            try
            {
                var buildSequence = topicPartitionOffsets
                    .Values
                    .GroupBy(g => g.Key.Topic, TopicCompare.Equality)
                    .Select(r =>
                        new KeyValuePair<Topic, ImmutableArray<KeyValuePair<Partition, TopicPartitionReadState>>>(
                            r.Key,
                            r.OrderBy(o => o.Key.Partition.Value)
                                .Select(r => new KeyValuePair<Partition, TopicPartitionReadState>(r.Key.Partition, r.Value))
                                .ToImmutableArray()
                        )
                    )
                    .ToImmutableArray()
                ;
                var fetchRequest = CreateFetchRequest(
                    buildSequence
                );
                while (!cancellationToken.IsCancellationRequested)
                {
                    var fetchResponse = await connection.Fetch(
                        fetchRequest,
                        cancellationToken
                    ).ConfigureAwait(false);

                    var (offsetsProcessed, records) = ProcessFetchResponse(
                        fetchResponse,
                        topicPartitionOffsets
                    );

                    if (records.Count > 0)
                    {
                        var taskCompletionSource = new TaskCompletionSource(
                            TaskCreationOptions.RunContinuationsAsynchronously
                        );
                        var result = new FetchResult(records, taskCompletionSource);
                        queue.Enqueue(result);
                        resetEvent.Set();
                        await taskCompletionSource
                            .Task
                            .WaitAsync(cancellationToken)
                            .ConfigureAwait(false)
                        ;
                    }

                    if (offsetsProcessed > 0)
                        fetchRequest = CreateFetchRequest(
                            buildSequence
                        );
                }
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                _logger.FetchLoopException(_nodeId, ex);
                throw;
            }
            finally
            {
                _logger.FetchLoopStop(_nodeId);
            }
        }

        private static FetchResponseProcessResult ProcessFetchResponse(
            in FetchResponseData fetchResponse,
            in ImmutableTopicPartitionMap<TopicPartitionReadState> topicPartitionOffsets
        )
        {
            if (fetchResponse.ResponsesField.IsDefaultOrEmpty)
                return FetchResponseProcessResult.Empty;
            var totalOffsetsProcessed = 0;
            var topicRecordsBuilder = ImmutableArray.CreateBuilder<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>();
            for (int i = 0; i < fetchResponse.ResponsesField.Length; i++)
            {
                var topicResponse = fetchResponse.ResponsesField[i];
                var topic = new Topic(topicResponse.TopicIdField, topicResponse.TopicField);
                var processedOffsets = ProcessTopicResponse(
                    topic,
                    topicResponse,
                    topicRecordsBuilder,
                    topicPartitionOffsets
                );
                totalOffsetsProcessed += processedOffsets;
            }
            return new(totalOffsetsProcessed, topicRecordsBuilder.ToImmutable());
        }

        private static int ProcessTopicResponse(
            in Topic topic,
            in FetchResponseData.FetchableTopicResponse topicResponse,
            in ImmutableArray<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>.Builder topicRecordsBuilder,
            in ImmutableTopicPartitionMap<TopicPartitionReadState> topicPartitionOffsets
        )
        {
            var offsetsProcessed = 0;
            for (int i = 0; i < topicResponse.PartitionsField.Length; i++)
            {
                var partition = topicResponse.PartitionsField[i];
                var topicPartition = new TopicPartition(topic, partition.PartitionIndexField);
                if (!topicPartitionOffsets.Get(topicPartition, out var readState))
                    throw new InvalidOperationException($"State not avilabile for {topicPartition}");
                if (partition.ErrorCodeField != 0)
                {
                    var watermark = readState.Value.GetOffset();
                    var error = ApiErrors.Translate(partition.ErrorCodeField);
                    var errorRecord = new ReadRecord(
                        topicPartition,
                        watermark,
                        Timestamp.None,
                        null,
                        null,
                        ImmutableArray<RecordHeader>.Empty,
                        error
                    );
                    topicRecordsBuilder.Add(new(
                        new(topic, Partition.Unassigned),
                        [errorRecord]
                    ));
                    continue;
                }
                var partitionRecordsBuilder = ImmutableArray.CreateBuilder<ReadRecord>();
                var totalRecordsProcessed = ProcessPartitionResponse(
                    readState,
                    partition,
                    partitionRecordsBuilder
                );
                topicRecordsBuilder.Add(new(
                    topicPartition,
                    partitionRecordsBuilder.ToImmutable()
                ));
                offsetsProcessed += totalRecordsProcessed;
            }
            return offsetsProcessed;
        }

        private static int ProcessPartitionResponse(
            in KeyValuePair<TopicPartition, TopicPartitionReadState> state,
            in FetchResponseData.FetchableTopicResponse.PartitionData partition,
            in ImmutableArray<ReadRecord>.Builder recordsBuilder
        )
        {
            // Skip empty records.
            if (partition.RecordsField.IsDefaultOrEmpty)
                return 0;

            var offsetsProcessed = 0;
            var watermark = state.Value.GetOffset();
            for (int i = 0; i < partition.RecordsField.Length; i++)
            {
                var recordBatch = partition.RecordsField[i];
                offsetsProcessed += recordBatch.Records.Count;
                var offset = recordBatch.BaseOffset;

                // Control batches are expected to have exactly one record.
                if (recordBatch.Attributes.HasFlag(Attributes.IsControlBatch))
                {
                    state.Value.SetOffset(
                        offset + recordBatch.Records.Count
                    );
                    continue;
                }

                for (int j = 0; j < recordBatch.Records.Count; j++, offset++)
                {
                    if (offset < watermark)
                        continue;

                    var record = recordBatch.Records[j];
                    var timestampMs = recordBatch.BaseTimestamp + record.TimestampDelta;
                    var timestamp = recordBatch.Attributes.HasFlag(Attributes.LogAppendTime) ?
                        Timestamp.LogAppend(timestampMs) :
                        Timestamp.Created(timestampMs)
                    ;

                    var readRecord = new ReadRecord(
                        TopicPartition: state.Key,
                        Offset: offset,
                        Timestamp: timestamp,
                        Key: record.Key,
                        Value: record.Value,
                        Headers: record.Headers,
                        Error: ApiError.None
                    );
                    recordsBuilder.Add(readRecord);
                }
                state.Value.SetOffset(
                    offset
                );
            }
            return offsetsProcessed;
        }

        private FetchRequestData CreateFetchRequest(
            in ImmutableArray<KeyValuePair<Topic, ImmutableArray<KeyValuePair<Partition, TopicPartitionReadState>>>> buildSequence
        )
        {
            var fetchTopicsBuilder = ImmutableArray.CreateBuilder<FetchRequestData.FetchTopic>();
            var fetchPartitionsBuilder = ImmutableArray.CreateBuilder<FetchRequestData.FetchTopic.FetchPartition>();
            for (int i = 0; i < buildSequence.Length; i++)
            {
                var (topic, partitions) = buildSequence[i];
                for (int j = 0; j < partitions.Length; j++)
                {
                    var (partition, state) = partitions[j];
                    var fetchPartition = new FetchRequestData.FetchTopic.FetchPartition(
                        PartitionField: partition,
                        CurrentLeaderEpochField: -1,
                        FetchOffsetField: state.GetOffset(),
                        LastFetchedEpochField: -1,
                        LogStartOffsetField: -1,
                        PartitionMaxBytesField: _maxPartitionFetchBytes,
                        []
                    );
                    fetchPartitionsBuilder.Add(fetchPartition);
                }
                var fetchPartitions = fetchPartitionsBuilder.DrainToImmutable();
                var fetchTopic = new FetchRequestData.FetchTopic(
                    topic.TopicName,
                    topic.TopicId,
                    fetchPartitions,
                    []
                );
                fetchTopicsBuilder.Add(fetchTopic);
            }
            var fetchTopics = fetchTopicsBuilder.ToImmutable();
            return new(
                ClusterIdField: null,
                ReplicaIdField: -1,
                ReplicaStateField: FetchRequestData.ReplicaState.Empty,
                MaxWaitMsField: _fetchMaxWaitMs,
                MinBytesField: _fetchMinBytes,
                MaxBytesField: _fetchMaxBytes,
                IsolationLevelField: _isolationLevel,
                SessionIdField: 0,
                SessionEpochField: -1,
                TopicsField: fetchTopics,
                ForgottenTopicsDataField: [],
                RackIdField: _clientRack,
                []
            );
        }
    }
}
