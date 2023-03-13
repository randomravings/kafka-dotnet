using Kafka.Client.Clients.Consumer.Logging;
using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class FetchResultEnumerator<TKey, TValue> :
        IFetchResult<TKey, TValue>
    {
        private readonly FetchResponse _fetchResponse;
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly Action<TopicPartition, Offset> _onRead;
        private readonly Error _error;

        public FetchResultEnumerator(
            FetchResponse fetchResponse,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            Action<TopicPartition, Offset> onRead
        )
        {
            _fetchResponse = fetchResponse;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _onRead = onRead;
            _error = _fetchResponse.ErrorCodeField switch
            {
                0 => Errors.Known.NONE,
                _ => Errors.Translate(_fetchResponse.ErrorCodeField)
            };
        }

        Error IFetchResult<TKey, TValue>.Error => _error;

        IEnumerator<ConsumerRecord<TKey, TValue>> IEnumerable<ConsumerRecord<TKey, TValue>>.GetEnumerator()
        {
            if (_error.Code != 0)
                throw new ApiException(_error);

            var allBatches = _fetchResponse
                .ResponsesField
                .SelectMany(t => t.PartitionsField.Select(p =>
                    (new TopicPartition(t.TopicField, p.PartitionIndexField), p.RecordsField, p.ErrorCodeField)
                ))
            ;

            foreach ((var topicPartition, var records, var errorCode) in allBatches)
            {
                switch ((records, errorCode))
                {
                    case (ImmutableArray<IRecords> recordBatches, 0):
                        foreach (var recordBatch in recordBatches)
                        {
                            if (recordBatch.Attributes.HasFlag(Attributes.IsControlBatch))
                                _onRead(topicPartition, recordBatch.Offset + 1);
                            else
                                foreach (var record in EnumerateRecords(topicPartition, recordBatch, _keyDeserializer, _valueDeserializer))
                                {
                                    _onRead(topicPartition, recordBatch.Offset + 1);
                                    yield return record;
                                }
                        }
                        break;
                    case (null, _):
                        break;
                    default:
                        var error = Errors.Translate(errorCode);
                        throw new ApiException(error);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable<ConsumerRecord<TKey, TValue>>)this).GetEnumerator()
        ;

        public static IEnumerable<ConsumerRecord<TKey, TValue>> EnumerateRecords(
            TopicPartition topicPartition,
            IRecords records,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {

            var offset = records.Offset;
            foreach (var record in records)
            {
                offset += record.OffsetDelta;
                var timestamp = records.BaseTimestamp + record.TimestampDelta;
                var key = keyDeserializer.Read(record.Key);
                var value = valueDeserializer.Read(record.Value);
                yield return new ConsumerRecord<TKey, TValue>(
                    TopicPartition: topicPartition,
                    Offset: offset,
                    Timestamp: records.Attributes.HasFlag(Attributes.LogAppendTime) ? Timestamp.LogAppend(timestamp) : Timestamp.Created(timestamp),
                    Key: key,
                    Value: value,
                    Headers: record.Headers
                );
            }
        }
    }
}
