using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicPartitions = Kafka.Client.Messages.ElectLeadersRequest.TopicPartitions;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ElectionTypeField">Type of elections to conduct for the partition. A value of '0' elects the preferred replica. A value of '1' elects the first live replica if there are no in-sync replica.</param>
    /// <param name="TopicPartitionsField">The topic partitions to elect leaders.</param>
    /// <param name="TimeoutMsField">The time in ms to wait for the election to complete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ElectLeadersRequest (
        sbyte ElectionTypeField,
        ImmutableArray<TopicPartitions>? TopicPartitionsField,
        int TimeoutMsField
    )
    {
        public static ElectLeadersRequest Empty { get; } = new(
            default(sbyte),
            default(ImmutableArray<TopicPartitions>?),
            default(int)
        );
        /// <summary>
        /// <param name="TopicField">The name of a topic.</param>
        /// <param name="PartitionsField">The partitions of this topic whose leader should be elected.</param>
        /// </summary>
        public sealed record TopicPartitions (
            string TopicField,
            ImmutableArray<int> PartitionsField
        )
        {
            public static TopicPartitions Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty
            );
        };
    };
}