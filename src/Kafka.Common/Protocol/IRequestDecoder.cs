using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public interface IRequestDecoder<TRequestHeader, TRequestMessage> :
        IMessageCodec
        where TRequestHeader : notnull, RequestHeader
        where TRequestMessage : notnull, RequestMessage
    {
        public DecodeResult<TRequestHeader> ReadHeader(byte[] buffer, int offset);
        public DecodeResult<TRequestMessage> ReadMessage(byte[] buffer, int offset);
    }
}
