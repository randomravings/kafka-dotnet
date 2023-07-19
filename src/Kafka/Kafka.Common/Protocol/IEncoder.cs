using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public interface IEncoder
    {
        ApiKey ApiKey { get; }
        Model.Version ApiVersion { get; }
        bool Flexible { get; }
    }

    public interface IEncoder<THeader, TPayload> :
        IEncoder
        where THeader : notnull
        where TPayload : notnull
    {
        int WriteHeader(byte[] buffer, int offset, THeader header);
        int WritePayload(byte[] buffer, int offset, TPayload payload);
    }
}
