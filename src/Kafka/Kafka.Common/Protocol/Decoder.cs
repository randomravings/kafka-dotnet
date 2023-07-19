using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class Decoder :
        IDecoder
    {
        private readonly ApiKey _apiKey;
        private readonly Model.Version _apiVersion;
        private readonly bool _flexible;

        public Decoder(
            ApiKey apiKey,
            Model.Version apiVersion,
            bool flexible
        )
        {
            _apiKey = apiKey;
            _apiVersion = apiVersion;
            _flexible = flexible;
        }

        ApiKey IDecoder.ApiKey => _apiKey;

        Model.Version IDecoder.ApiVersion => _apiVersion;

        bool IDecoder.Flexible => _flexible;
    }

    public sealed class Decoder<THeader, TPayload> :
        Decoder,
        IDecoder<THeader, TPayload>
    {
        private readonly DecodeDelegate<THeader> _headerDecoder;
        private readonly DecodeDelegate<TPayload> _payloadDecoder;

        public Decoder(
            ApiKey apiKey,
            Model.Version apiVersion,
            bool flexible,
            DecodeDelegate<THeader> headerDecoder,
            DecodeDelegate<TPayload> payloadDecoder
        ) : base(apiKey, apiVersion, flexible)
        {
            _headerDecoder = headerDecoder;
            _payloadDecoder = payloadDecoder;
        }

        (int Offset, THeader Header) IDecoder<THeader, TPayload>.ReadHeader(byte[] buffer, int offset) =>
            _headerDecoder(buffer, offset)
        ;
        (int Offset, TPayload Payload) IDecoder<THeader, TPayload>.ReadPayload(byte[] buffer, int offset) =>
            _payloadDecoder(buffer, offset)
        ;
    }
}
