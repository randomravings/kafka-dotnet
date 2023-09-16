using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public interface IRequestEncoder<TRequestHeader, TRequestMessage> :
        IMessageCodec
        where TRequestHeader : notnull, RequestHeader
        where TRequestMessage : notnull, RequestMessage
    {
        public int WriteHeader(byte[] buffer, int offset, TRequestHeader header);
        public int WriteMessage(byte[] buffer, int offset, TRequestMessage message);
    }
}
