using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic.DeleteRecordsPartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField">Each topic that we want to delete records from.</param>
    /// <param name="TimeoutMsField">How long to wait for the deletion to complete, in milliseconds.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteRecordsRequest (
        ImmutableArray<DeleteRecordsTopic> TopicsField,
        int TimeoutMsField
    )
    {
        public static DeleteRecordsRequest Empty { get; } = new(
            ImmutableArray<DeleteRecordsTopic>.Empty,
            default(int)
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">Each partition that we want to delete records from.</param>
        /// </summary>
        public sealed record DeleteRecordsTopic (
            string NameField,
            ImmutableArray<DeleteRecordsPartition> PartitionsField
        )
        {
            public static DeleteRecordsTopic Empty { get; } = new(
                "",
                ImmutableArray<DeleteRecordsPartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="OffsetField">The deletion offset.</param>
            /// </summary>
            public sealed record DeleteRecordsPartition (
                int PartitionIndexField,
                long OffsetField
            )
            {
                public static DeleteRecordsPartition Empty { get; } = new(
                    default(int),
                    default(long)
                );
            };
        };
    };
}