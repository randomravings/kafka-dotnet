using Kafka.Common.Encoding;
using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public abstract class Encoder :
        IEncoder
    {
        private readonly ApiKey _apiKey;
        private readonly Model.Version _apiVersion;
        private readonly bool _flexible;

        public Encoder(
            ApiKey apiKey,
            Model.Version apiVersion,
            bool flexible
        )
        {
            _apiKey = apiKey;
            _apiVersion = apiVersion;
            _flexible = flexible;
        }

        ApiKey IEncoder.ApiKey => _apiKey;

        Model.Version IEncoder.ApiVersion => _apiVersion;

        bool IEncoder.Flexible => _flexible;
    }

    public sealed class Encoder<THeader, TPayload> :
        Encoder,
        IEncoder<THeader, TPayload>
        where THeader : notnull
        where TPayload : notnull
    {
        private readonly EncodeDelegate<THeader> _headerEncoder;
        private readonly EncodeDelegate<TPayload> _payloadEncoder;

        public Encoder(
            ApiKey apiKey,
            Model.Version apiVersion,
            bool flexible,
            EncodeDelegate<THeader> headerEncoder,
            EncodeDelegate<TPayload> payloadEncoder
        ) : base(apiKey, apiVersion, flexible)
        {
            _headerEncoder = headerEncoder;
            _payloadEncoder = payloadEncoder;
        }

        int IEncoder<THeader, TPayload>.WriteHeader(byte[] buffer, int offset, THeader header) =>
            _headerEncoder(buffer, offset, header)
        ;

        int IEncoder<THeader, TPayload>.WritePayload(byte[] buffer, int offset, TPayload payload) =>
            _payloadEncoder(buffer, offset, payload)
        ;
    }
}
