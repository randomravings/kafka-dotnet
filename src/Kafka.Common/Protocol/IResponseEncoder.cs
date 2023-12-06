using Kafka.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Protocol
{
    public interface IResponseEncoder<TResponseHeader, TResponseMessage> :
        IMessageCodec
        where TResponseHeader : notnull, ResponseHeader
        where TResponseMessage : notnull, ResponseMessage
    {
        public int WriteHeader([NotNull] in byte[] buffer, in int index, [NotNull] in TResponseHeader header);
        public int WriteMessage([NotNull] in byte[] buffer, in int index, [NotNull] in TResponseMessage message);
    }
}
