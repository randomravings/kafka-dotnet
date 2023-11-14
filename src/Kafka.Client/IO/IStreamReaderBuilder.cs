using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IStreamReaderBuilder
    {
        IStreamReaderBuilder<TKey> WithKey<TKey>(
            IDeserializer<TKey> keyDeserializer
        );
    }

    public interface IStreamReaderBuilder<TKey>
    {
        IStreamReaderBuilder<TKey, TValue> WithValue<TValue>(
            IDeserializer<TValue> valueDeserializer
        );
    }

    public interface IStreamReaderBuilder<TKey, TValue>
    {
        IStreamReaderBuilder<TKey, TValue> WithLogger(ILogger logger);
        IStreamReader<TKey, TValue> Build();
    }
}
