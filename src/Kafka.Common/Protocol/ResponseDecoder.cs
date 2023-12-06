using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class ResponseDecoder<THeader, TMessage>(
        ApiKey apiKey,
        VersionRange apiVersions,
        VersionRange flexibleVersions,
        DecodeValue<THeader> headerDecoder,
        DecodeValue<TMessage> messageDecoder
    ) :
        MessageCodec(apiKey, apiVersions, flexibleVersions),
        IResponseDecoder<THeader, TMessage>
        where THeader : notnull, ResponseHeader
        where TMessage : notnull, ResponseMessage
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
