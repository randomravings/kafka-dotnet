using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public interface IResponseEncoder<TResponseHeader, TResponseMessage> :
        IMessageCodec
        where TResponseHeader : notnull, ResponseHeader
        where TResponseMessage : notnull, ResponseMessage
    {
        public int WriteHeader(byte[] buffer, int offset, TResponseHeader header);
        public int WriteMessage(byte[] buffer, int offset, TResponseMessage  header);
    }
}
