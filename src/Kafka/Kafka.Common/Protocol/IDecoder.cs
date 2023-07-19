using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public interface IDecoder
    {
        ApiKey ApiKey { get; }
        Model.Version ApiVersion { get; }
        bool Flexible { get; }
    }

    public interface IDecoder<THeader, TPayload> :
        IDecoder
    {
        (int Offset, THeader Header) ReadHeader(byte[] buffer, int offset);
        (int Offset, TPayload Payload) ReadPayload(byte[] buffer, int offset);
    }
}
