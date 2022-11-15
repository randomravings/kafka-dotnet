using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolSubscription.TopicPartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField"></param>
    /// <param name="UserDataField"></param>
    /// <param name="OwnedPartitionsField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ConsumerProtocolSubscription (
        ImmutableArray<string> TopicsField,
        byte[]? UserDataField,
        ImmutableArray<TopicPartition> OwnedPartitionsField
    )
    {
        public static ConsumerProtocolSubscription Empty { get; } = new(
            ImmutableArray<string>.Empty,
            default(byte[]?),
            ImmutableArray<TopicPartition>.Empty
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