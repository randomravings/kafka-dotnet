using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Exceptions;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public sealed class SubscribedConsumer<TKey, TValue> :
        Client<ConsumerConfig>,
        IConsumer<TKey, TValue>
    {
        private string _memberId = "";
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private SortedSet<TopicName> _topics = new();
        public SubscribedConsumer(
            ConsumerConfig config
        ) : base(config)
        {
            _keyDeserializer = GetKeyDeserializer(config);
            _valueDeserializer = GetValueDeserializer(config);
        }

        public SubscribedConsumer(
            ConsumerConfig config,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        ) : base(config)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        async ValueTask<ConsumeResult<TKey, TValue>> IConsumer<TKey, TValue>.Poll(CancellationToken cancellationToken)
        {
            var fetchTopics = ImmutableArray<FetchRequest.FetchTopic>.Empty;
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                if (_topics.Count != 0)
                {
                    var fetchTopicBuilder = ImmutableArray.CreateBuilder<FetchRequest.FetchTopic>(_topics.Count);
                    foreach (var topic in _topics)
                    {
                        fetchTopicBuilder.Add(
                            new FetchRequest.FetchTopic(
                                topic.Value ?? "",
                                Guid.Empty,
                                new[]
                                {
                                    new FetchRequest.FetchTopic.FetchPartition(
                                        PartitionField: 0,
                                        CurrentLeaderEpochField: -1,
                                        FetchOffsetField: 5,
                                        LastFetchedEpochField: -1,
                                        LogStartOffsetField: -1,
                                        PartitionMaxBytesField: 1048576
                                    )
                                }.ToImmutableArray()
                            )
                        );
                    }
                    fetchTopics = fetchTopicBuilder.ToImmutable();
                }
            }
            finally
            {
                _semaphore.Release();
            }
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
            var recordsBuilder = ImmutableArray.CreateBuilder<ConsumerRecord<TKey, TValue>>();
            foreach (var topic in response.ResponsesField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    if (partition.RecordsField == null)
                        continue;
                    foreach (var record in partition.RecordsField)
                    {
                        var key = _keyDeserializer.Read(record.Key);
                        var value = _valueDeserializer.Read(record.Value);
                        recordsBuilder.Add(
                            new(
                                new(topic.TopicField, new(partition.PartitionIndexField, partition.RecordsField.Offset + record.OffsetDelta)),
                                new(Common.Records.TimestampType.CreateTime, partition.RecordsField.BaseTimestamp + record.TimestampDelta),
                                record.Headers,
                                key,
                                value,
                                ClusterInfo.Empty
                            )
                        );
                    }
                }
            }
            return new(
                recordsBuilder.ToImmutable()
            );
        }
        async ValueTask IConsumer<TKey, TValue>.Subscribe(
            TopicName topic,
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                _topics.Add(topic);
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
                _topics.Remove(topic);
            }
            finally
            {
                _semaphore.Release();
            }
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


        private async ValueTask JoinGroup(
            CancellationToken cancellationToken
        )
        {
            var request = CreateJoinRequest();
            var response = await HandleRequest(
                request,
                JoinGroupRequestSerde.Write,
                JoinGroupResponseSerde.Read,
                cancellationToken
            );
            if (response.ErrorCodeField == (short)ErrorCode.MEMBER_ID_REQUIRED)
            {
                _memberId = response.MemberIdField;
                request = CreateJoinRequest();
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

        private JoinGroupRequest CreateJoinRequest()
        {
            return new JoinGroupRequest(
                _config.GroupId,
                45000,
                300000,
                _memberId,
                null,
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
                _config.GroupId,
                _memberId,
                ImmutableArray<LeaveGroupRequest.MemberIdentity>.Empty
            );
        }
    }
}
