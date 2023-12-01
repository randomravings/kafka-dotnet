using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ClientSoftwareNameField">The name of the client.</param>
    /// <param name="ClientSoftwareVersionField">The version of the client.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record ApiVersionsRequestData (
        string ClientSoftwareNameField,
        string ClientSoftwareVersionField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static ApiVersionsRequestData Empty { get; } = new(
            "",
            "",
            ImmutableArray<TaggedField>.Empty
        );
    };
}
