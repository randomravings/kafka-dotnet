using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class RequestDecoder<THeader, TMessage> :
        MessageCodec,
        IRequestDecoder<THeader, TMessage>
        where THeader : notnull, RequestHeader
        where TMessage : notnull, RequestMessage
    {
        private DecodeDelegate<THeader> _headerDecoder;
        private DecodeDelegate<TMessage> _messageDecoder;

        public RequestDecoder(
            ApiKey apiKey,
            VersionRange apiVersions,
            VersionRange flexibleVersions,
            DecodeDelegate<THeader> headerDecoder,
            DecodeDelegate<TMessage> messageDecoder
        ) : base(apiKey, apiVersions, flexibleVersions)
        {
            _headerDecoder = headerDecoder;
            _messageDecoder = messageDecoder;
        }

        DecodeResult<THeader> IRequestDecoder<THeader, TMessage>.ReadHeader(
            byte[] buffer,
            int offset
        ) =>
            _headerDecoder(buffer, offset)
        ;

        DecodeResult<TMessage> IRequestDecoder<THeader, TMessage>.ReadMessage(
            byte[] buffer,
            int offset
        ) =>
            _messageDecoder(buffer, offset)
        ;

        protected override void SetApiVersion(short apiVersion)
        {
            _headerDecoder = GetHeaderDecoder(apiVersion);
            _messageDecoder = GetMessageDecoder(apiVersion);
        }

        protected abstract DecodeDelegate<THeader> GetHeaderDecoder(short apiVersion);
        protected abstract DecodeDelegate<TMessage> GetMessageDecoder(short apiVersion);
    }
}
