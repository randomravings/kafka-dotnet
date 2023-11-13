using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IStreamWriterBuilder
    {
        IStreamWriterBuilder<TKey> WithKey<TKey>(ISerializer<TKey> keySerialzier);
    }

    public interface IStreamWriterBuilder<TKey>
    {
        IStreamWriterBuilder<TKey, TValue> WithValue<TValue>(ISerializer<TValue> valueSerialzier);
    }

    public interface IStreamWriterBuilder<TKey, TValue>
    {
        IStreamWriterBuilder<TKey, TValue> WithPartitioner(IPartitioner partitioner);
        IStreamWriterBuilder<TKey, TValue> WithLogger(ILogger<IKafkaClient> logger);
        IStreamWriter<TKey, TValue> Build();
    }
}
