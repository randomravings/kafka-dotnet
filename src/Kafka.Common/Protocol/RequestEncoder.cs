using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class RequestEncoder<THeader, TMessage> :
        MessageCodec,
        IRequestEncoder<THeader, TMessage>
        where THeader : notnull, RequestHeader
        where TMessage : notnull, RequestMessage
    {
        private EncodeValue<THeader> _headerEncoder;
        private EncodeValue<TMessage> _messageEncoder;

        protected RequestEncoder(
            ApiKey apiKey,
            VersionRange apiVersions,
            VersionRange flexibleVersions,
            EncodeValue<THeader> headerEncoder,
            EncodeValue<TMessage> messageEncoder
        ) : base(apiKey, apiVersions, flexibleVersions)
        {
            _headerEncoder = headerEncoder;
            _messageEncoder = messageEncoder;
        }

        public int WriteHeader(
            byte[] buffer,
            int offset,
            THeader header
        ) =>
            _headerEncoder(buffer, offset, header)
        ;

        public int WriteMessage(
            byte[] buffer,
            int offset,
            TMessage message
        ) =>
            _messageEncoder(buffer, offset, message)
        ;

        protected override void NewApiVersion(short apiVersion)
        {
            _headerEncoder = GetHeaderEncoder(apiVersion);
            _messageEncoder = GetMessageEncoder(apiVersion);
        }

        protected abstract EncodeValue<THeader> GetHeaderEncoder(short apiVersion);
        protected abstract EncodeValue<TMessage> GetMessageEncoder(short apiVersion);
    }
}
