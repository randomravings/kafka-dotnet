using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Encoding
{
    public delegate (int Offset, TItem Value) DecodeVersionedValue<TItem>(
        [NotNull] in byte[] buffer,
        in int index,
        in short version
    );
}
