using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TypeField">The principal type</param>
    /// <param name="NameField">The principal name</param>
    /// <param name="TokenAuthenticatedField">Whether the principal was authenticated by a delegation token on the forwarding broker.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DefaultPrincipalData (
        string TypeField,
        string NameField,
        bool TokenAuthenticatedField
    )
    {
        public static DefaultPrincipalData Empty { get; } = new(
            "",
            "",
            default(bool)
        );
    };
}