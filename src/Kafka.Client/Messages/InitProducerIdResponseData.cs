using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ProducerIdField">The current producer id.</param>
    /// <param name="ProducerEpochField">The current epoch associated with the producer id.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record InitProducerIdResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        long ProducerIdField,
        short ProducerEpochField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        public static InitProducerIdResponseData Empty { get; } = new(
            default(int),
            default(short),
            default(long),
            default(short),
            ImmutableArray<TaggedField>.Empty
        );
    };
}
