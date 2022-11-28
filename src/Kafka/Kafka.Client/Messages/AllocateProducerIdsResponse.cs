using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top level response error code</param>
    /// <param name="ProducerIdStartField">The first producer ID in this range, inclusive</param>
    /// <param name="ProducerIdLenField">The number of producer IDs in this range</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AllocateProducerIdsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        long ProducerIdStartField,
        int ProducerIdLenField
    ) : Response(67)
    {
        public static AllocateProducerIdsResponse Empty { get; } = new(
            default(int),
            default(short),
            default(long),
            default(int)
        );
    };
}