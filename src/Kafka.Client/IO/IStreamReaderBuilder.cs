using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IStreamReaderBuilder
    {
        IStreamReaderBuilder WithLogger(ILogger logger);
        IStreamReader Build();
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
        IStreamReader<TKey, TValue> Build();
    }
}
