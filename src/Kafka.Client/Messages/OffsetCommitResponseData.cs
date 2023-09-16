using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetCommitResponseTopic = Kafka.Client.Messages.OffsetCommitResponseData.OffsetCommitResponseTopic;
using OffsetCommitResponsePartition = Kafka.Client.Messages.OffsetCommitResponseData.OffsetCommitResponseTopic.OffsetCommitResponsePartition;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">The responses for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetCommitResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<OffsetCommitResponseTopic> TopicsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        public static OffsetCommitResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<OffsetCommitResponseTopic>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The responses for each partition in the topic.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record OffsetCommitResponseTopic (
            string NameField,
            ImmutableArray<OffsetCommitResponsePartition> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static OffsetCommitResponseTopic Empty { get; } = new(
                "",
                ImmutableArray<OffsetCommitResponsePartition>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record OffsetCommitResponsePartition (
                int PartitionIndexField,
                short ErrorCodeField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                public static OffsetCommitResponsePartition Empty { get; } = new(
                    default(int),
                    default(short),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
