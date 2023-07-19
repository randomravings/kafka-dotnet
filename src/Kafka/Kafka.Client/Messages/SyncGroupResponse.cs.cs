using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ProtocolTypeField">The group protocol type.</param>
    /// <param name="ProtocolNameField">The group protocol name.</param>
    /// <param name="AssignmentField">The member assignment.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SyncGroupResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ProtocolTypeField,
        string? ProtocolNameField,
        ReadOnlyMemory<byte> AssignmentField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponse
    {
        public static SyncGroupResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            default(string?),
            ReadOnlyMemory<byte>.Empty,
            ImmutableArray<TaggedField>.Empty

        );
    };
}