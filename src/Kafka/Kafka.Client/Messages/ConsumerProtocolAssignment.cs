using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolAssignment.TopicPartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="AssignedPartitionsField"></param>
    /// <param name="UserDataField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ConsumerProtocolAssignment (
        ImmutableArray<TopicPartition> AssignedPartitionsField,
        ReadOnlyMemory<byte>? UserDataField
    )
    {
        public static ConsumerProtocolAssignment Empty { get; } = new(
            ImmutableArray<TopicPartition>.Empty,
            default(ReadOnlyMemory<byte>?)
        );
        /// <summary>
        /// <param name="TopicField"></param>
        /// <param name="PartitionsField"></param>
        /// </summary>
        public sealed record TopicPartition (
            string TopicField,
            ImmutableArray<int> PartitionsField
        )
        {
            public static TopicPartition Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty
            );
        };
    };
}