using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Records;
using Kafka.Common.Protocol;
using TopicProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData.PartitionProduceData;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TransactionalIdField">The transactional ID, or null if the producer is not transactional.</param>
    /// <param name="AcksField">The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.</param>
    /// <param name="TimeoutMsField">The timeout to await a response in milliseconds.</param>
    /// <param name="TopicDataField">Each topic to produce to.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ProduceRequest (
        string? TransactionalIdField,
        short AcksField,
        int TimeoutMsField,
        ImmutableArray<TopicProduceData> TopicDataField
    ) : Request(0,0,9,9)
    {
        public static ProduceRequest Empty { get; } = new(
            default(string?),
            default(short),
            default(int),
            ImmutableArray<TopicProduceData>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionDataField">Each partition to produce to.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record TopicProduceData (
            string NameField,
            ImmutableArray<PartitionProduceData> PartitionDataField
        )
        {
            public static TopicProduceData Empty { get; } = new(
                "",
                ImmutableArray<PartitionProduceData>.Empty
            );
            /// <summary>
            /// <param name="IndexField">The partition index.</param>
            /// <param name="RecordsField">The record data to be produced.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record PartitionProduceData (
                int IndexField,
                ImmutableArray<IRecords>? RecordsField
            )
            {
                public static PartitionProduceData Empty { get; } = new(
                    default(int),
                    default(ImmutableArray<IRecords>)
                );
            };
        };
    };
}