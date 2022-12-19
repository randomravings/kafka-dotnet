using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using OffsetDeleteResponseTopic = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic;
using OffsetDeleteResponsePartition = Kafka.Client.Messages.OffsetDeleteResponse.OffsetDeleteResponseTopic.OffsetDeleteResponsePartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The top-level error code, or 0 if there was no error.</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">The responses for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetDeleteResponse (
        short ErrorCodeField,
        int ThrottleTimeMsField,
        ImmutableArray<OffsetDeleteResponseTopic> TopicsField
    ) : Response(47)
    {
        public static OffsetDeleteResponse Empty { get; } = new(
            default(short),
            default(int),
            ImmutableArray<OffsetDeleteResponseTopic>.Empty
        );
        public static short FlexibleVersion { get; } = 32767;
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The responses for each partition in the topic.</param>
        /// </summary>
        public sealed record OffsetDeleteResponseTopic (
            string NameField,
            ImmutableArray<OffsetDeleteResponsePartition> PartitionsField
        )
        {
            public static OffsetDeleteResponseTopic Empty { get; } = new(
                "",
                ImmutableArray<OffsetDeleteResponsePartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// </summary>
            public sealed record OffsetDeleteResponsePartition (
                int PartitionIndexField,
                short ErrorCodeField
            )
            {
                public static OffsetDeleteResponsePartition Empty { get; } = new(
                    default(int),
                    default(short)
                );
            };
        };
    };
}