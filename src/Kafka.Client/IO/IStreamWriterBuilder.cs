using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IStreamWriterBuilder
    {
        IStreamWriterBuilder WithLogger(
            ILogger logger
        );
        IStreamWriterBuilder WithPartitioner(
            IPartitioner partitioner
        );
        IStreamWriterBuilder<TKey> WithKey<TKey>(
            ISerializer<TKey> keySerialzier
        );
        IStreamWriter Build();
    }

    public interface IStreamWriterBuilder<TKey>
    {
        IStreamWriterBuilder<TKey, TValue> WithValue<TValue>(
            ISerializer<TValue> valueSerialzier
        );
    }

    public interface IStreamWriterBuilder<TKey, TValue>
    {
        IStreamWriter<TKey, TValue> Build();
    }
}
