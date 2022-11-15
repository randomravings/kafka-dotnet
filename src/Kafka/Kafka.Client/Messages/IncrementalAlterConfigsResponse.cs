using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AlterConfigsResourceResponse = Kafka.Client.Messages.IncrementalAlterConfigsResponse.AlterConfigsResourceResponse;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResponsesField">The responses for each resource.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record IncrementalAlterConfigsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<AlterConfigsResourceResponse> ResponsesField
    )
    {
        public static IncrementalAlterConfigsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<AlterConfigsResourceResponse>.Empty
        );
        /// <summary>
        /// <param name="ErrorCodeField">The resource error code.</param>
        /// <param name="ErrorMessageField">The resource error message, or null if there was no error.</param>
        /// <param name="ResourceTypeField">The resource type.</param>
        /// <param name="ResourceNameField">The resource name.</param>
        /// </summary>
        public sealed record AlterConfigsResourceResponse (
            short ErrorCodeField,
            string? ErrorMessageField,
            sbyte ResourceTypeField,
            string ResourceNameField
        )
        {
            public static AlterConfigsResourceResponse Empty { get; } = new(
                default(short),
                default(string?),
                default(sbyte),
                ""
            );
        };
    };
}