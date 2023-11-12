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
    internal sealed class ConsumerChannel
    {
        private readonly int _fetchMaxWaitMs;
        private readonly int _fetchMinBytes;
        private readonly int _fetchMaxBytes;
        private readonly sbyte _isolationLevel;
        private readonly string _clientRack;
        private readonly int _maxPartitionFetchBytes;
        private readonly ILogger _logger;

        public ConsumerChannel(
            InputStreamConfig config,
            ILogger logger
        )
        {
            _fetchMaxWaitMs = config.FetchMaxWaitMs;
            _fetchMinBytes = config.FetchMinBytes;
            _fetchMaxBytes = config.FetchMaxBytes;
            _isolationLevel = (sbyte)config.IsolationLevel;
            _clientRack = config.ClientRack;
            _maxPartitionFetchBytes = config.MaxPartitionFetchBytes;
            _logger = logger;
        }

        public async Task Run(
            IClientConnection connection,
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
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
                    await Task.Yield();

                    var (offsetsProcessed, records) = ProcessFetchResponse(
                        fetchResponse,
                        topicPartitionOffsets
                    );

                    if (records.Length > 0)
                    {
                        var taskCompletionSource = new TaskCompletionSource();
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
            in IDictionary<TopicPartition, Offset> watermarks
        )
        {
            var totalOffsetsProcessed = 0;
            var recordsBuilder = ImmutableArray.CreateBuilder<ConsumerRecord>();
            foreach (var topicResponse in fetchResponse.ResponsesField)
            {
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
            in IDictionary<TopicPartition, Offset> watermarks
        )
        {
            var offsetsProcessed = 0;
            foreach (var partition in topicResponse.PartitionsField)
            {
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
            in IDictionary<TopicPartition, Offset> watermarks
        )
        {
            // Skip empty records.
            if (partition.RecordsField == null)
                return 0;

            var offsetsProcessed = 0;
            var watermark = watermarks[topicPartition];
            foreach (var recordBatch in partition.RecordsField)
            {
                offsetsProcessed += recordBatch.Records.Count;
                var offset = recordBatch.BaseOffset;

                // Control batches are expected to have exactly one record.
                if (recordBatch.Attributes.HasFlag(Attributes.IsControlBatch))
                {
                    watermarks[topicPartition] = offset + recordBatch.Records.Count;
                    continue;
                }

                for (int i = 0; i < recordBatch.Records.Count; i++, offset++)
                {
                    if (offset < watermark)
                        continue;

                    var record = recordBatch.Records[i];
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
                watermarks[topicPartition] = offset;
            }
            return offsetsProcessed;
        }

        private FetchRequestData CreateFetchRequest(
            in IDictionary<TopicPartition, Offset> topicPartitionOffsets
        )
        {
            var fetchTopics = topicPartitionOffsets
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
                ForgottenTopicsDataField: ImmutableArray<FetchRequestData.ForgottenTopic>.Empty,
                RackIdField: _clientRack,
                ImmutableArray<TaggedField>.Empty
            );
        }
    }
}
