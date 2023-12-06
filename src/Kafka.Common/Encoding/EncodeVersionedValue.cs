using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Encoding
{
    public delegate int EncodeVersionedValue<TItem>(
        [NotNull] in byte[] buffer,
        int index,
        in short version,
        in TItem item
    );
}
