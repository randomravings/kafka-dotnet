using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponseData.DeletableTopicResult;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResponsesField">The results for each topic we tried to delete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteTopicsResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<DeletableTopicResult> ResponsesField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        public static DeleteTopicsResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<DeletableTopicResult>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="TopicIdField">the unique topic ID</param>
        /// <param name="ErrorCodeField">The deletion error, or 0 if the deletion succeeded.</param>
        /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record DeletableTopicResult (
            string? NameField,
            Guid TopicIdField,
            short ErrorCodeField,
            string? ErrorMessageField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static DeletableTopicResult Empty { get; } = new(
                default(string?),
                default(Guid),
                default(short),
                default(string?),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
