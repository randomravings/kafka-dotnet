using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class ResponseDecoder<THeader, TMessage> :
        MessageCodec,
        IResponseDecoder<THeader, TMessage>
        where THeader : notnull, ResponseHeader
        where TMessage : notnull, ResponseMessage
    {
        private DecodeDelegate<THeader> _headerDecoder;
        private DecodeDelegate<TMessage> _messageDecoder;

        public ResponseDecoder(
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

        DecodeResult<THeader> IResponseDecoder<THeader, TMessage>.ReadHeader(
            byte[] buffer,
            int offset
        ) =>
            _headerDecoder(buffer, offset)
        ;

        DecodeResult<TMessage> IResponseDecoder<THeader, TMessage>.ReadMessage(
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
