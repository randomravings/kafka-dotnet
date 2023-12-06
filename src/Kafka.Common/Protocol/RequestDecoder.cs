using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class RequestDecoder<THeader, TMessage>(
        ApiKey apiKey,
        VersionRange apiVersions,
        VersionRange flexibleVersions,
        DecodeValue<THeader> headerDecoder,
        DecodeValue<TMessage> messageDecoder
    ) :
        MessageCodec(apiKey, apiVersions, flexibleVersions),
        IRequestDecoder<THeader, TMessage>
        where THeader : notnull, RequestHeader
        where TMessage : notnull, RequestMessage
    {
        private DecodeValue<THeader> _headerDecoder = headerDecoder;
        private DecodeValue<TMessage> _messageDecoder = messageDecoder;

        public DecodeResult<THeader> ReadHeader(
            byte[] buffer,
            int offset
        ) =>
            _headerDecoder(buffer, offset)
        ;

        public DecodeResult<TMessage> ReadMessage(
            byte[] buffer,
            int offset
        ) =>
            _messageDecoder(buffer, offset)
        ;

        protected override void NewApiVersion(short apiVersion)
        {
            _headerDecoder = GetHeaderDecoder(apiVersion);
            _messageDecoder = GetMessageDecoder(apiVersion);
        }

        protected abstract DecodeValue<THeader> GetHeaderDecoder(short apiVersion);
        protected abstract DecodeValue<TMessage> GetMessageDecoder(short apiVersion);
    }
}
