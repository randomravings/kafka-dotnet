using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolSubscription.TopicPartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField"></param>
    /// <param name="UserDataField"></param>
    /// <param name="OwnedPartitionsField"></param>
    /// <param name="GenerationIdField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ConsumerProtocolSubscription (
        ImmutableArray<string> TopicsField,
        ReadOnlyMemory<byte>? UserDataField,
        ImmutableArray<TopicPartition> OwnedPartitionsField,
        int GenerationIdField
    )
    {
        public static ConsumerProtocolSubscription Empty { get; } = new(
            ImmutableArray<string>.Empty,
            default(ReadOnlyMemory<byte>?),
            ImmutableArray<TopicPartition>.Empty,
            default(int)
        );
        public static short FlexibleVersion { get; } = 32767;
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