using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record HeartbeatResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        public static HeartbeatResponseData Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<TaggedField>.Empty
        );
    };
}
