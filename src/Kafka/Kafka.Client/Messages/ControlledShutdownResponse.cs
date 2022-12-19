using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using RemainingPartition = Kafka.Client.Messages.ControlledShutdownResponse.RemainingPartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The top-level error code.</param>
    /// <param name="RemainingPartitionsField">The partitions that the broker still leads.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ControlledShutdownResponse (
        short ErrorCodeField,
        ImmutableArray<RemainingPartition> RemainingPartitionsField
    ) : Response(7)
    {
        public static ControlledShutdownResponse Empty { get; } = new(
            default(short),
            ImmutableArray<RemainingPartition>.Empty
        );
        public static short FlexibleVersion { get; } = 3;
        /// <summary>
        /// <param name="TopicNameField">The name of the topic.</param>
        /// <param name="PartitionIndexField">The index of the partition.</param>
        /// </summary>
        public sealed record RemainingPartition (
            string TopicNameField,
            int PartitionIndexField
        )
        {
            public static RemainingPartition Empty { get; } = new(
                "",
                default(int)
            );
        };
    };
}