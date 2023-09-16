using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public interface IResponseDecoder<TResponseHeader, TResponseMessage> :
        IMessageCodec
        where TResponseHeader : notnull, ResponseHeader
        where TResponseMessage : notnull, ResponseMessage
    {
        public DecodeResult<TResponseHeader> ReadHeader(byte[] buffer, int offset);
        public DecodeResult<TResponseMessage> ReadMessage(byte[] buffer, int offset);
    }
}
