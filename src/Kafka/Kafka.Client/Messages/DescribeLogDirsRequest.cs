using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DescribableLogDirTopic = Kafka.Client.Messages.DescribeLogDirsRequest.DescribableLogDirTopic;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField">Each topic that we want to describe log directories for, or null for all topics.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeLogDirsRequest (
        ImmutableArray<DescribableLogDirTopic>? TopicsField
    )
    {
        public static DescribeLogDirsRequest Empty { get; } = new(
            default(ImmutableArray<DescribableLogDirTopic>?)
        );
        /// <summary>
        /// <param name="TopicField">The topic name</param>
        /// <param name="PartitionsField">The partition indexes.</param>
        /// </summary>
        public sealed record DescribableLogDirTopic (
            string TopicField,
            ImmutableArray<int> PartitionsField
        )
        {
            public static DescribableLogDirTopic Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty
            );
        };
    };
}