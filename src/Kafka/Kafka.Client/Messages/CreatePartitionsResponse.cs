using System.CodeDom.Compiler;
using System.Collections.Immutable;
using CreatePartitionsTopicResult = Kafka.Client.Messages.CreatePartitionsResponse.CreatePartitionsTopicResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The partition creation results for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreatePartitionsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<CreatePartitionsTopicResult> ResultsField
    )
    {
        public static CreatePartitionsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<CreatePartitionsTopicResult>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="ErrorCodeField">The result error, or zero if there was no error.</param>
        /// <param name="ErrorMessageField">The result message, or null if there was no error.</param>
        /// </summary>
        public sealed record CreatePartitionsTopicResult (
            string NameField,
            short ErrorCodeField,
            string? ErrorMessageField
        )
        {
            public static CreatePartitionsTopicResult Empty { get; } = new(
                "",
                default(short),
                default(string?)
            );
        };
    };
}