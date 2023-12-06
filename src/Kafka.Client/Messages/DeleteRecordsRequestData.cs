using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequestData.DeleteRecordsTopic.DeleteRecordsPartition;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequestData.DeleteRecordsTopic;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="TopicsField">Each topic that we want to delete records from.</param>
    /// <param name="TimeoutMsField">How long to wait for the deletion to complete, in milliseconds.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DeleteRecordsRequestData (
        ImmutableArray<DeleteRecordsTopic> TopicsField,
        int TimeoutMsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static DeleteRecordsRequestData Empty { get; } = new(
            ImmutableArray<DeleteRecordsTopic>.Empty,
            default(int),
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">Each partition that we want to delete records from.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DeleteRecordsTopic (
            string NameField,
            ImmutableArray<DeleteRecordsPartition> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DeleteRecordsTopic Empty { get; } = new(
                "",
                ImmutableArray<DeleteRecordsPartition>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="OffsetField">The deletion offset.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record DeleteRecordsPartition (
                int PartitionIndexField,
                long OffsetField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static DeleteRecordsPartition Empty { get; } = new(
                    default(int),
                    default(long),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
