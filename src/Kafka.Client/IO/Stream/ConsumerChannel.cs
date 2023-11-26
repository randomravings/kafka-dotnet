using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Stream
{
    internal sealed class ConsumerChannel(
        InputStreamConfig config,
        ILogger logger
    )
    {
        private readonly int _fetchMaxWaitMs = config.FetchMaxWaitMs;
        private readonly int _fetchMinBytes = config.FetchMinBytes;
        private readonly int _fetchMaxBytes = config.FetchMaxBytes;
        private readonly sbyte _isolationLevel = (sbyte)config.IsolationLevel;
        private readonly string _clientRack = config.ClientRack;
        private readonly int _maxPartitionFetchBytes = config.MaxPartitionFetchBytes;
        private readonly ILogger _logger = logger;

        public async Task Run(
            IClientConnection connection,
            TopicPartitionDictionary<Offset> topicPartitionOffsets,
            ConcurrentQueue<FetchResult> queue,
            ManualResetEventSlim resetEvent,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var fetchRequest = CreateFetchRequest(topicPartitionOffsets);
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

                    if (records.Length > 0)
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
                        fetchRequest = CreateFetchRequest(topicPartitionOffsets);
                }
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
        }

        private static (int offsetsProcessed, ImmutableArray<ConsumerRecord> Records) ProcessFetchResponse(
            in FetchResponseData fetchResponse,
            in TopicPartitionDictionary<Offset> watermarks
        )
        {
            var totalOffsetsProcessed = 0;
            var recordsBuilder = ImmutableArray.CreateBuilder<ConsumerRecord>();
            for (int i = 0; i < fetchResponse.ResponsesField.Length; i++)
            {
                var topicResponse = fetchResponse.ResponsesField[i];
                var topic = new Topic(topicResponse.TopicIdField, topicResponse.TopicField);
                var processedOffsets = ProcessTopicResponse(
                    topic,
                    topicResponse,
                    recordsBuilder,
                    watermarks
                );
                totalOffsetsProcessed += processedOffsets;
            }
            return (totalOffsetsProcessed, recordsBuilder.ToImmutable());
        }

        private static int ProcessTopicResponse(
            in Topic topic,
            in FetchResponseData.FetchableTopicResponse topicResponse,
            in ImmutableArray<ConsumerRecord>.Builder recordsBuilder,
            in TopicPartitionDictionary<Offset> watermarks
        )
        {
            var offsetsProcessed = 0;
            for (int i = 0; i < topicResponse.PartitionsField.Length; i++)
            {
                var partition = topicResponse.PartitionsField[i];
                var topicPartition = new TopicPartition(topic, partition.PartitionIndexField);
                if (partition.ErrorCodeField != 0)
                {
                    var watermark = watermarks[topicPartition];
                    var error = Errors.Translate(partition.ErrorCodeField);
                    var errorRecord = new ConsumerRecord(
                        topicPartition,
                        watermark,
                        Timestamp.None,
                        null,
                        null,
                        ImmutableArray<RecordHeader>.Empty,
                        error
                    );
                    recordsBuilder.Add(errorRecord);
                    continue;
                }
                var totalRecordsProcessed = ProcessPartitionResponse(
                    topicPartition,
                    partition,
                    recordsBuilder,
                    watermarks
                );
                offsetsProcessed += totalRecordsProcessed;
            }
            return offsetsProcessed;
        }

        private static int ProcessPartitionResponse(
            in TopicPartition topicPartition,
            in FetchResponseData.FetchableTopicResponse.PartitionData partition,
            in ImmutableArray<ConsumerRecord>.Builder recordsBuilder,
            in TopicPartitionDictionary<Offset> watermarks
        )
        {
            // Skip empty records.
            var recordBatches = partition.RecordsField.GetValueOrDefault([]);
            if (recordBatches.Length == 0)
                return 0;

            var offsetsProcessed = 0;
            var watermark = watermarks[topicPartition];
            for (int i = 0; i < recordBatches.Length; i++)
            {
                var recordBatch = recordBatches[i];
                offsetsProcessed += recordBatch.Records.Count;
                var offset = recordBatch.BaseOffset;

                // Control batches are expected to have exactly one record.
                if (recordBatch.Attributes.HasFlag(Attributes.IsControlBatch))
                {
                    watermarks.Set(
                        topicPartition,
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

                    var rawConsumerRecord = new ConsumerRecord(
                        TopicPartition: topicPartition,
                        Offset: offset,
                        Timestamp: timestamp,
                        Key: record.Key,
                        Value: record.Value,
                        Headers: record.Headers,
                        Error: Errors.Known.NONE
                    );
                    recordsBuilder.Add(rawConsumerRecord);
                }
                watermarks.Set(
                    topicPartition,
                    offset
                );
            }
            return offsetsProcessed;
        }

        private FetchRequestData CreateFetchRequest(
            in TopicPartitionDictionary<Offset> topicPartitionOffsets
        )
        {
            var items = topicPartitionOffsets.CopyItems();
            if(items.Length == 0)
                return FetchRequestData.Empty;
            var fetchTopicsBuilder = ImmutableArray.CreateBuilder<FetchRequestData.FetchTopic>();
            var fetchPartitionsBuilder = ImmutableArray.CreateBuilder<FetchRequestData.FetchTopic.FetchPartition>();
            var index = 0;
            var length = items.Length;
            var currentTopic = items[0].Key.Topic;
            while (index < length)
            {
                (var (topic, partition), var offset) = items[index];
                var fetchPartition = new FetchRequestData.FetchTopic.FetchPartition(
                    PartitionField: partition,
                    CurrentLeaderEpochField: -1,
                    FetchOffsetField: offset,
                    LastFetchedEpochField: -1,
                    LogStartOffsetField: -1,
                    PartitionMaxBytesField: _maxPartitionFetchBytes,
                    []
                );
                fetchPartitionsBuilder.Add(fetchPartition);
                index++;
                if (currentTopic != topic || index == length)
                {
                    var fetchPartitions = fetchPartitionsBuilder.DrainToImmutable();
                    var fetchTopic = new FetchRequestData.FetchTopic(
                        currentTopic.TopicName,
                        currentTopic.TopicId,
                        fetchPartitions,
                        []
                    );
                    fetchTopicsBuilder.Add(fetchTopic);
                    currentTopic = topic;
                }
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
