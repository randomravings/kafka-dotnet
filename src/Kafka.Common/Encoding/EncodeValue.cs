using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Encoding
{
    public delegate int EncodeValue<TItem>(
        [NotNull] in byte[] buffer,
        in int index,
        in TItem item
    );
}
