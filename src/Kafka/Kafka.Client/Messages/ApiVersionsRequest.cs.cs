using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ClientSoftwareNameField">The name of the client.</param>
    /// <param name="ClientSoftwareVersionField">The version of the client.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ApiVersionsRequest (
        string ClientSoftwareNameField,
        string ClientSoftwareVersionField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IRequest
    {
        public static ApiVersionsRequest Empty { get; } = new(
            "",
            "",
            ImmutableArray<TaggedField>.Empty

        );
    };
}