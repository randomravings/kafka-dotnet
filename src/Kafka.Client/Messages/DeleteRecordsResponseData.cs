using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteRecordsPartitionResult = Kafka.Client.Messages.DeleteRecordsResponseData.DeleteRecordsTopicResult.DeleteRecordsPartitionResult;
using DeleteRecordsTopicResult = Kafka.Client.Messages.DeleteRecordsResponseData.DeleteRecordsTopicResult;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">Each topic that we wanted to delete records from.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DeleteRecordsResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<DeleteRecordsTopicResult> TopicsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static DeleteRecordsResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<DeleteRecordsTopicResult>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">Each partition that we wanted to delete records from.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DeleteRecordsTopicResult (
            string NameField,
            ImmutableArray<DeleteRecordsPartitionResult> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DeleteRecordsTopicResult Empty { get; } = new(
                "",
                ImmutableArray<DeleteRecordsPartitionResult>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="LowWatermarkField">The partition low water mark.</param>
            /// <param name="ErrorCodeField">The deletion error code, or 0 if the deletion succeeded.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record DeleteRecordsPartitionResult (
                int PartitionIndexField,
                long LowWatermarkField,
                short ErrorCodeField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static DeleteRecordsPartitionResult Empty { get; } = new(
                    default(int),
                    default(long),
                    default(short),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
