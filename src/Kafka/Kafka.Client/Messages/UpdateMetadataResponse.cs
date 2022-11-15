using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UpdateMetadataResponse (
        short ErrorCodeField
    )
    {
        public static UpdateMetadataResponse Empty { get; } = new(
            default(short)
        );
    };
}