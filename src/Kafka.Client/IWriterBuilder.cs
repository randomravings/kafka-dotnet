using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client
{
    public interface IWriterBuilder
    {
        IWriterBuilder WithLogger(
            ILogger logger
        );
        IWriterBuilder WithPartitioner(
            IPartitioner partitioner
        );
        IStreamWriterBuilder<TKey> WithKey<TKey>(
            ISerializer<TKey> keySerialzier
        );
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
