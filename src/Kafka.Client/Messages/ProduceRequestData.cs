using Kafka.Common.Model;
using Kafka.Common.Records;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequestData.TopicProduceData.PartitionProduceData;
using TopicProduceData = Kafka.Client.Messages.ProduceRequestData.TopicProduceData;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="TransactionalIdField">The transactional ID, or null if the producer is not transactional.</param>
    /// <param name="AcksField">The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.</param>
    /// <param name="TimeoutMsField">The timeout to await a response in milliseconds.</param>
    /// <param name="TopicDataField">Each topic to produce to.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record ProduceRequestData (
        string? TransactionalIdField,
        short AcksField,
        int TimeoutMsField,
        ImmutableArray<TopicProduceData> TopicDataField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static ProduceRequestData Empty { get; } = new(
            default(string?),
            default(short),
            default(int),
            ImmutableArray<TopicProduceData>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionDataField">Each partition to produce to.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record TopicProduceData (
            string NameField,
            ImmutableArray<PartitionProduceData> PartitionDataField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static TopicProduceData Empty { get; } = new(
                "",
                ImmutableArray<PartitionProduceData>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="IndexField">The partition index.</param>
            /// <param name="RecordsField">The record data to be produced.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record PartitionProduceData (
                int IndexField,
                ImmutableArray<IRecords> RecordsField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static PartitionProduceData Empty { get; } = new(
                    default(int),
                    default(ImmutableArray<IRecords>),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
