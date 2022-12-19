using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponse.DeletableTopicResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResponsesField">The results for each topic we tried to delete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteTopicsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<DeletableTopicResult> ResponsesField
    ) : Response(20)
    {
        public static DeleteTopicsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<DeletableTopicResult>.Empty
        );
        public static short FlexibleVersion { get; } = 4;
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="TopicIdField">the unique topic ID</param>
        /// <param name="ErrorCodeField">The deletion error, or 0 if the deletion succeeded.</param>
        /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
        /// </summary>
        public sealed record DeletableTopicResult (
            string? NameField,
            Guid TopicIdField,
            short ErrorCodeField,
            string? ErrorMessageField
        )
        {
            public static DeletableTopicResult Empty { get; } = new(
                default(string?),
                default(Guid),
                default(short),
                default(string?)
            );
        };
    };
}