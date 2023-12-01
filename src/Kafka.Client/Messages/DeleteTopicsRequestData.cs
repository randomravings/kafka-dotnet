using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequestData.DeleteTopicState;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="TopicsField">The name or topic ID of the topic</param>
    /// <param name="TopicNamesField">The names of the topics to delete</param>
    /// <param name="TimeoutMsField">The length of time in milliseconds to wait for the deletions to complete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DeleteTopicsRequestData (
        ImmutableArray<DeleteTopicState> TopicsField,
        ImmutableArray<string> TopicNamesField,
        int TimeoutMsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static DeleteTopicsRequestData Empty { get; } = new(
            ImmutableArray<DeleteTopicState>.Empty,
            ImmutableArray<string>.Empty,
            default(int),
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="TopicIdField">The unique topic ID</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DeleteTopicState (
            string? NameField,
            Guid TopicIdField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DeleteTopicState Empty { get; } = new(
                default(string?),
                default(Guid),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
