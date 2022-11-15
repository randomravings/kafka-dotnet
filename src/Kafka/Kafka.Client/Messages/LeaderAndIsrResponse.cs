using System.CodeDom.Compiler;
using System.Collections.Immutable;
using LeaderAndIsrTopicError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrTopicError;
using LeaderAndIsrPartitionError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrPartitionError;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="PartitionErrorsField">Each partition in v0 to v4 message.</param>
    /// <param name="TopicsField">Each topic</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaderAndIsrResponse (
        short ErrorCodeField,
        ImmutableArray<LeaderAndIsrPartitionError> PartitionErrorsField,
        ImmutableArray<LeaderAndIsrTopicError> TopicsField
    )
    {
        public static LeaderAndIsrResponse Empty { get; } = new(
            default(short),
            ImmutableArray<LeaderAndIsrPartitionError>.Empty,
            ImmutableArray<LeaderAndIsrTopicError>.Empty
        );
        /// <summary>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// <param name="PartitionErrorsField">Each partition.</param>
        /// </summary>
        public sealed record LeaderAndIsrTopicError (
            Guid TopicIdField,
            ImmutableArray<LeaderAndIsrPartitionError> PartitionErrorsField
        )
        {
            public static LeaderAndIsrTopicError Empty { get; } = new(
                default(Guid),
                ImmutableArray<LeaderAndIsrPartitionError>.Empty
            );
        };
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionIndexField">The partition index.</param>
        /// <param name="ErrorCodeField">The partition error code, or 0 if there was no error.</param>
        /// </summary>
        public sealed record LeaderAndIsrPartitionError (
            string TopicNameField,
            int PartitionIndexField,
            short ErrorCodeField
        )
        {
            public static LeaderAndIsrPartitionError Empty { get; } = new(
                "",
                default(int),
                default(short)
            );
        };
    };
}