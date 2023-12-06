using Kafka.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Encoding
{
    public delegate DecodeResult<TItem> DecodeValue<TItem>(
        [NotNull] in byte[] buffer,
        in int index
    );
}
