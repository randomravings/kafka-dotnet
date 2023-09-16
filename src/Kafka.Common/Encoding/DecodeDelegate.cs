using Kafka.Common.Model;

namespace Kafka.Common.Encoding
{
    public delegate DecodeResult<TItem> DecodeDelegate<TItem>(
        byte[] buffer,
        int index
    );
}
