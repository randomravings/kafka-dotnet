using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteRecordsPartitionResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult.DeleteRecordsPartitionResult;
using DeleteRecordsTopicResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">Each topic that we wanted to delete records from.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteRecordsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<DeleteRecordsTopicResult> TopicsField
    )
    {
        public static DeleteRecordsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<DeleteRecordsTopicResult>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">Each partition that we wanted to delete records from.</param>
        /// </summary>
        public sealed record DeleteRecordsTopicResult (
            string NameField,
            ImmutableArray<DeleteRecordsPartitionResult> PartitionsField
        )
        {
            public static DeleteRecordsTopicResult Empty { get; } = new(
                "",
                ImmutableArray<DeleteRecordsPartitionResult>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="LowWatermarkField">The partition low water mark.</param>
            /// <param name="ErrorCodeField">The deletion error code, or 0 if the deletion succeeded.</param>
            /// </summary>
            public sealed record DeleteRecordsPartitionResult (
                int PartitionIndexField,
                long LowWatermarkField,
                short ErrorCodeField
            )
            {
                public static DeleteRecordsPartitionResult Empty { get; } = new(
                    default(int),
                    default(long),
                    default(short)
                );
            };
        };
    };
}