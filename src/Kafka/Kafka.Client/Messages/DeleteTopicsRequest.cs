using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequest.DeleteTopicState;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField">The name or topic ID of the topic</param>
    /// <param name="TopicNamesField">The names of the topics to delete</param>
    /// <param name="TimeoutMsField">The length of time in milliseconds to wait for the deletions to complete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteTopicsRequest (
        ImmutableArray<DeleteTopicState> TopicsField,
        ImmutableArray<string> TopicNamesField,
        int TimeoutMsField
    ) : Request(20,0,6,4)
    {
        public static DeleteTopicsRequest Empty { get; } = new(
            ImmutableArray<DeleteTopicState>.Empty,
            ImmutableArray<string>.Empty,
            default(int)
        );
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// </summary>
        public sealed record DeleteTopicState (
            string? NameField,
            Guid TopicIdField
        )
        {
            public static DeleteTopicState Empty { get; } = new(
                default(string?),
                default(Guid)
            );
        };
    };
}