using Kafka.Common.Encoding;
using Kafka.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Protocol
{
    public abstract class ResponseEncoder<THeader, TMessage> :
        MessageCodec,
        IResponseEncoder<THeader, TMessage>
        where THeader : notnull, ResponseHeader
        where TMessage : notnull, ResponseMessage
    {
        private EncodeValue<THeader> _headerEncoder;
        private EncodeValue<TMessage> _messageEncoder;

        protected ResponseEncoder(
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
            [NotNull] in byte[] buffer,
            in int index,
            [NotNull] in THeader header
        ) =>
            _headerEncoder(buffer, index, header)
        ;

        public int WriteMessage(
            [NotNull] in byte[] buffer,
            in int index,
            [NotNull] in TMessage message
        ) =>
            _messageEncoder(buffer, index, message)
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
