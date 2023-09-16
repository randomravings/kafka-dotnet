using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class ResponseEncoder<THeader, TMessage> :
        MessageCodec,
        IResponseEncoder<THeader, TMessage>
        where THeader : notnull, ResponseHeader
        where TMessage : notnull, ResponseMessage
    {
        private EncodeDelegate<THeader> _headerEncoder;
        private EncodeDelegate<TMessage> _messageEncoder;

        public ResponseEncoder(
            ApiKey apiKey,
            VersionRange apiVersions,
            VersionRange flexibleVersions,
            EncodeDelegate<THeader> headerEncoder,
            EncodeDelegate<TMessage> messageEncoder
        ) : base(apiKey, apiVersions, flexibleVersions)
        {
            _headerEncoder = headerEncoder;
            _messageEncoder = messageEncoder;
        }

        int IResponseEncoder<THeader, TMessage>.WriteHeader(
            byte[] buffer,
            int offset,
            THeader header
        ) =>
            _headerEncoder(buffer, offset, header)
        ;

        int IResponseEncoder<THeader, TMessage>.WriteMessage(
            byte[] buffer,
            int offset,
            TMessage message
        ) =>
            _messageEncoder(buffer, offset, message)
        ;

        protected override void SetApiVersion(short apiVersion)
        {
            _headerEncoder = GetHeaderEncoder(apiVersion);
            _messageEncoder = GetMessageEncoder(apiVersion);
        }
        protected abstract EncodeDelegate<THeader> GetHeaderEncoder(short apiVersion);
        protected abstract EncodeDelegate<TMessage> GetMessageEncoder(short apiVersion);
    }
}
